using AutoMapper;
using Flights.API.Domain.Models;
using Flights.API.Domain.Models.Queries;
using Flights.API.Resources;

namespace Flights.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Airplane, AirplaneResource>();
            CreateMap<Airport, AirportResource>();
            CreateMap<Flight, FlightResource>();
            CreateMap<Flight, SaveFlightResource>();
            CreateMap<FlightsQuery, FlightsQueryResource>();
            CreateMap<QueryResult<Flight>, QueryResultResource<FlightResource>>();
            CreateMap<Passenger, PassengerResource>();
            CreateMap<FlightPassenger, FlightPassengerResource>();
        }
    }
}