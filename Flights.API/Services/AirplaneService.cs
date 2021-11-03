using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Repositories;
using Flights.API.Domain.Services;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AirplaneService(IAirplaneRepository airplaneRepository, IUnitOfWork unitOfWork)
        {
            _airplaneRepository = airplaneRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Airplane>> ListAsync()
        {
            var airplanes = await _airplaneRepository.ListAsync();
            
            return airplanes;
        }

        public async Task<AirplaneResponse> SaveAsync(Airplane airplane)
        {
            try
            {
                await _airplaneRepository.AddAsync(airplane);
                await _unitOfWork.CompleteAsync();

                return new AirplaneResponse(airplane);
            }
            catch (Exception ex)
            {
                return new AirplaneResponse($"An error occurred when saving the airplane: {ex.Message}");
            }
        }

        public async Task<AirplaneResponse> UpdateAsync(int id, Airplane airplane)
        {
            var existingAirplane = await _airplaneRepository.FindByIdAsync(id);

            if (existingAirplane == null)
                return new AirplaneResponse("Airplane not found.");

            existingAirplane.Country = airplane.Country;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new AirplaneResponse(existingAirplane);
            }
            catch (Exception ex)
            {
                return new AirplaneResponse($"An error occurred when updating the airplane: {ex.Message}");
            }
        }

        public async Task<AirplaneResponse> DeleteAsync(int id)
        {
            var existingAirplane = await _airplaneRepository.FindByIdAsync(id);

            if (existingAirplane == null)
                return new AirplaneResponse("Airplane not found.");

            try
            {
                _airplaneRepository.Remove(existingAirplane);
                await _unitOfWork.CompleteAsync();

                return new AirplaneResponse(existingAirplane);
            }
            catch (Exception ex)
            {
                return new AirplaneResponse($"An error occurred when deleting the airplane: {ex.Message}");
            }
        }
    }
}