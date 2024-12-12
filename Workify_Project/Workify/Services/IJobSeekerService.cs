using System;
using Workify.DTOs;

namespace Workify.Services;

public interface IJobSeekerService
{
    Task<JobSeekerResponseDTO?> GetJobSeekerByIdAsync(int id);
    Task<JobSeekerResponseDTO?> GetJobSeekerByUserIdAsync(int userId);
    Task<IEnumerable<JobSeekerDTO>> GetAllJobSeekersAsync();
    Task AddJobSeekerAsync(JobSeekerDTO jobSeekerDto);
    Task UpdateJobSeekerAsync(int id, JobSeekerDTO jobSeekerDto);
    Task DeleteJobSeekerAsync(int id);
    Task<IEnumerable<JobListingDTO>> GetJobRecommendationsAsync(int jobSeekerId);
    Task<IEnumerable<JobSeekerDTO>> FilterCandidatesAsync(CandidateSearchCriteriaDTO criteria);
}
