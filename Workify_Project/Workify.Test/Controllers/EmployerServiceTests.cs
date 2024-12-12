using System;
using AutoMapper;
using Moq;
using Workify.DTOs;
using Workify.Models;
using Workify.Repository;
using Workify.Services;

namespace Workify.Test.Controllers;

public class EmployerServiceTests
{
    private readonly Mock<IEmployerRepository> _employerRepositoryMock = new Mock<IEmployerRepository>();

    // private readonly Mock<IRepository<Employer>> _employerRepositoryMock;
    private readonly IMapper _mapperMock;
    private readonly EmployerService _employerService;

    public EmployerServiceTests()
    {
        _employerRepositoryMock = new Mock<IEmployerRepository>();
        // _employerRepositoryMock = new Mock<IRepository<Employer>>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Employer, EmployerDTO>();
        });
        _mapperMock = config.CreateMapper();

        _employerService = new EmployerService(_employerRepositoryMock.Object, _mapperMock);
    }

    [Fact]
    public async Task GetAllEmployersAsync_ShouldReturnAllEmployers()
    {
        // Arrange
        var mockEmployers = new List<Employer>
        {
            new Employer { Id = 1, CompanyName = "TechCorp", ContactEmail = "contact@techcorp.com" },
            new Employer { Id = 2, CompanyName = "BizGroup", ContactEmail = "info@bizgroup.com" }
        };
        _employerRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockEmployers);

        // Act
        var result = await _employerService.GetAllEmployersAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}

