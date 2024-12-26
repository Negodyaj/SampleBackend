using Microsoft.AspNetCore.Mvc;
using SimpleBackend.Application;
using SimpleBackend.Application.Models;

namespace SampleBackend.Controllers;

[Route("api/delivery")]
[ApiController]
public class DeliveryController(IDeliveryService deliveryService) : ControllerBase
{
    [HttpPost]
    public void SendDelivery()
    {
        // validate the data
        deliveryService.SendDelivery(new Order { UserId = 5 });
        // send a response
    }
}
