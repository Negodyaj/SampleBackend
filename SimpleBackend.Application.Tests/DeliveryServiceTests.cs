using AutoFixture;
using Moq;
using Moq.Protected;
using SimpleBackend.Application.Models;
using System.Net;
using System.Text.Json;

namespace SimpleBackend.Application.Tests;

public class DeliveryServiceTests
{
    private IDeliveryService _sut;
    private Mock<HttpMessageHandler> _messageHandlerMock = new Mock<HttpMessageHandler>();
    private const string _baseAddress = "https://jsonplaceholder.typicode.com/";

    public DeliveryServiceTests()
    {
        _sut = new DeliveryService(_messageHandlerMock.Object);
    }

    [Fact]
    public void SendDelivery_CorrectUserIdPassed_SuccessReceived()
    {
        // arrange
        var userId = 5;
        var apiEndpoint = $"users/{userId}";
        var fixture = new Fixture();
        var user = fixture.Create<User>();
        var response = JsonSerializer.Serialize(user);

        var mockedProtected = _messageHandlerMock.Protected();
        var setupApiRequest = mockedProtected
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(m => m.RequestUri!.Equals(_baseAddress + apiEndpoint)),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(response)
            });

        // act
        _sut.SendDelivery(new Order { UserId = userId }); 

        // assert
    }
}