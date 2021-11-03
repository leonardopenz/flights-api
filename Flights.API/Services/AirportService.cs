using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Repositories;
using Flights.API.Domain.Services;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AirportService(IAirportRepository airportRepository, IUnitOfWork unitOfWork)
        {
            _airportRepository = airportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Airport>> ListAsync()
        {
            var airports = await _airportRepository.ListAsync();
            
            return airports;
        }

        public async Task<AirportResponse> SaveAsync(Airport airport)
        {
            try
            {
                await _airportRepository.AddAsync(airport);
                await _unitOfWork.CompleteAsync();

                return new AirportResponse(airport);
            }
            catch (Exception ex)
            {
                return new AirportResponse($"An error occurred when saving the airport: {ex.Message}");
            }
        }

        public async Task<AirportResponse> UpdateAsync(int id, Airport airport)
        {
            var existingAirport = await _airportRepository.FindByIdAsync(id);

            if (existingAirport == null)
                return new AirportResponse("Airport not found.");

            existingAirport.Name = airport.Name;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new AirportResponse(existingAirport);
            }
            catch (Exception ex)
            {
                return new AirportResponse($"An error occurred when updating the airport: {ex.Message}");
            }
        }

        public async Task<AirportResponse> DeleteAsync(int id)
        {
            var existingAirport = await _airportRepository.FindByIdAsync(id);

            if (existingAirport == null)
                return new AirportResponse("Airport not found.");

            try
            {
                _airportRepository.Remove(existingAirport);
                await _unitOfWork.CompleteAsync();

                return new AirportResponse(existingAirport);
            }
            catch (Exception ex)
            {
                return new AirportResponse($"An error occurred when deleting the airport: {ex.Message}");
            }
        }
    }
}