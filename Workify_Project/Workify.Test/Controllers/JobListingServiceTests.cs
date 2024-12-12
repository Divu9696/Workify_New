using System;
using Moq;
using Workify.DTOs;
using Workify.Models;
using Workify.Repository;
using Workify.Services;

namespace Workify.Test.Controllers;

public class JobListingServiceTests
{
    private readonly Mock<IJobListingRepository> _jobListingRepositoryMock;
    private readonly JobListingService _jobListingService;

    public JobListingServiceTests()
    {
        _jobListingRepositoryMock = new Mock<IJobListingRepository>();
        _jobListingService = new JobListingService(_jobListingRepositoryMock.Object, null);
    }

    [Fact]
    public async Task FilterJobsAsync_ShouldReturnFilteredJobs_WhenCriteriaIsMatched()
    {
        // Arrange
        var criteria = new JobSearchCriteriaDTO
        {
            Title = "Software Engineer",
            Location = "New York",
            MinSalary = 50000,
            JobType = "Full-Time"
        };

        var mockJobListings = new List<JobListing>
        {
            new JobListing { Id = 1, Title = "Software Engineer", Location = "New York", Salary = 60000, JobType = "Full-Time" }
        };

        _jobListingRepositoryMock.Setup(repo => repo.SearchJobsAsync(criteria))
            .ReturnsAsync(mockJobListings);

        // Act
        var result = await _jobListingService.FilterJobsAsync(criteria);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }
}