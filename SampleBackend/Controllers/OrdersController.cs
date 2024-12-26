using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleBackend.Configuration;
using SampleBackend.Models;
using SampleBackend.Models.Responses;
using System.Data;

namespace SampleBackend.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        [CustomAuthorize([UserRole.Manager, UserRole.SuperManager])]
        public ActionResult<List<OrderResponse>> GetOrders()
        {
            return Ok(new List<OrderResponse> { 
                new OrderResponse { Id = Guid.NewGuid() },
                new OrderResponse { Id = Guid.NewGuid() },
                new OrderResponse { Id = Guid.NewGuid() },
            });
        }
    }
}
