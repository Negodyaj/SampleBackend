using SimpleBackend.Application.Exceptions;
using SimpleBackend.Application.Integrations;
using SimpleBackend.Application.Models;

namespace SimpleBackend.Application;

public class DeliveryService : IDeliveryService
{
    private readonly CommonHttpClient<User> _httpClient;

    public DeliveryService(HttpMessageHandler? handler = null)
    {
        _httpClient = new CommonHttpClient<User>("https://jsonplaceholder.typicode.com/", handler);
    }

    public void SendDelivery(Order order)
    {
        // check business rules against some order
        
        var user = _httpClient.SendGetRequest($"users/{order.UserId}");

        // process delivery
    }
}
