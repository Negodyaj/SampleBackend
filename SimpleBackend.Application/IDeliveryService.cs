using SimpleBackend.Application.Models;

namespace SimpleBackend.Application
{
    public interface IDeliveryService
    {
        void SendDelivery(Order order);
    }
}