using Microsoft.AspNetCore.Mvc;
using Moq;
using Krvko_API.Controllers;

namespace Krvko_API.test.Controllers;

[TestClass]
public class DonorsControllerTests
{
    private Mock<IDonorService> _serviceMock;
    private DonorsController _controller;

    [TestInitialize]
    public void Setup()
    {
        _serviceMock = new Mock<IDonorService>();
        _controller = new DonorsController(_serviceMock.Object);
    }

    [TestMethod]
    public void GetById_UnknownId_ReturnsNotFound()
    {
        _serviceMock.Setup(s => s.GetById(99)).Returns((Donor?)null);

        var result = _controller.GetById(99);

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }
}