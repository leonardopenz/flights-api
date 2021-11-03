using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Repositories;
using Flights.API.Domain.Services;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PassengerService(IPassengerRepository passengerRepository, IUnitOfWork unitOfWork)
        {
            _passengerRepository = passengerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Passenger>> ListAsync()
        {
            var passengers = await _passengerRepository.ListAsync();
            
            return passengers;
        }

        public async Task<PassengerResponse> SaveAsync(Passenger passenger)
        {
            try
            {
                await _passengerRepository.AddAsync(passenger);
                await _unitOfWork.CompleteAsync();

                return new PassengerResponse(passenger);
            }
            catch (Exception ex)
            {
                return new PassengerResponse($"An error occurred when saving the passenger: {ex.Message}");
            }
        }

        public async Task<PassengerResponse> UpdateAsync(string passport, Passenger passenger)
        {
            var existingPassenger = await _passengerRepository.FindByIdAsync(passport);

            if (existingPassenger == null)
                return new PassengerResponse("Passenger not found.");

            existingPassenger.Name = passenger.Name;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new PassengerResponse(existingPassenger);
            }
            catch (Exception ex)
            {
                return new PassengerResponse($"An error occurred when updating the passenger: {ex.Message}");
            }
        }

        public async Task<PassengerResponse> DeleteAsync(string passport)
        {
            var existingPassenger = await _passengerRepository.FindByIdAsync(passport);

            if (existingPassenger == null)
                return new PassengerResponse("Passenger not found.");

            try
            {
                _passengerRepository.Remove(existingPassenger);
                await _unitOfWork.CompleteAsync();

                return new PassengerResponse(existingPassenger);
            }
            catch (Exception ex)
            {
                return new PassengerResponse($"An error occurred when deleting the passenger: {ex.Message}");
            }
        }
    }
}