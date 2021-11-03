using AutoMapper;
using Flights.API.Domain.Models;
using Flights.API.Domain.Models.Queries;
using Flights.API.Resources;

namespace Flights.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AirplaneResource, Airplane>();
            CreateMap<SaveAirplaneResource, Airplane>();

            CreateMap<AirportResource, Airport>();
            CreateMap<SaveAirportResource, Airport>();

            CreateMap<FlightResource, Flight>();
            CreateMap<SaveFlightResource, Flight>();

            CreateMap<PassengerResource, Passenger>();
            CreateMap<SavePassengerResource, Passenger>();

            CreateMap<FlightPassengerResource, FlightPassenger>();
            
            CreateMap<QueryResultResource<FlightResource>, QueryResult<Flight>>();
            CreateMap<FlightsQueryResource, FlightsQuery>();
        }
    }
}