using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;

namespace Wynn.Itinerary
{
    public class Itinerary
    {
        private readonly ILogger<Itinerary> _logger;

        public Itinerary(ILogger<Itinerary> logger)
        {
            _logger = logger;
        }

        [Function("Itinerary")]
        [OpenApiOperation(operationId: "Itinerary", tags: "Itinerary", Summary = "Itinerary", Description = "Get the reservation info")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ItineraryResponseModel), Summary = "Response Success", Description = "Return the reservation info")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "GET", Route = "wynnapi/itin/v1/itinerary")] HttpRequest req)
        {
            RoomReservationsModel roomReservationsModel = new RoomReservationsModel() {
                CheckinDate = "06-12-2014",
                CheckoutDate = "06-12-2014",
                Name = "Reservation Name",
                RoomCode = "EKD"
            };
            ItineraryResponseModel itineraryResponseModel = new ItineraryResponseModel() {
                RoomReservations = roomReservationsModel
            };
            return new OkObjectResult(itineraryResponseModel);
        }
    }
}
