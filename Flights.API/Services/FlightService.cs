using System;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Models.Queries;
using Flights.API.Domain.Repositories;
using Flights.API.Domain.Services;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FlightService(IFlightRepository flightRepository, IPassengerRepository passengerRepository, IUnitOfWork unitOfWork)
        {
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QueryResult<Flight>> ListAsync(FlightsQuery query)
        {
            var flights = await _flightRepository.ListAsync(query);

            return flights;
        }

        public async Task<FlightResponse> SaveAsync(Flight flight)
        {
            try
            {
                if (flight.FlightPassengers.Count > 0) { //verifica se o passenger já existe na base
                    foreach (FlightPassenger item in flight.FlightPassengers)
                    {
                        var existingPassenger = await _passengerRepository.FindByIdAsync(item.PassportNumber);
                        if (existingPassenger != null)
                            item.Passenger = null;
                    }
                }

                await _flightRepository.AddAsync(flight);
                await _unitOfWork.CompleteAsync();

                return new FlightResponse(flight);
            }
            catch (Exception ex)
            {
                return new FlightResponse($"An error occurred when saving the flight: {ex.Message}");
            }
        }

        public async Task<FlightResponse> UpdateAsync(int id, Flight flight)
        {
            var existingFlight = await _flightRepository.FindByIdAsync(id);

            if (existingFlight == null)
                return new FlightResponse("Flight not found.");

            existingFlight.Number = flight.Number;
            //existingFlight.AirportOriginId = flight.AirportOriginId;
            //pass other data

            try
            {
                _flightRepository.Update(existingFlight);
                await _unitOfWork.CompleteAsync();

                return new FlightResponse(existingFlight);
            }
            catch (Exception ex)
            {
                return new FlightResponse($"An error occurred when updating the flight: {ex.Message}");
            }
        }

        public async Task<FlightResponse> DeleteAsync(int id)
        {
            var existingFlight = await _flightRepository.FindByIdAsync(id);

            if (existingFlight == null)
                return new FlightResponse("Flight not found.");

            try
            {
                _flightRepository.Remove(existingFlight);
                await _unitOfWork.CompleteAsync();

                return new FlightResponse(existingFlight);
            }
            catch (Exception ex)
            {
                return new FlightResponse($"An error occurred when deleting the flight: {ex.Message}");
            }
        }
    }
}