using System;
using AutoMapper;
using Workify.DTOs;
using Workify.Models;

namespace Workify.Mapping;

// using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User Mappings
        CreateMap<User, UserResponseDTO>();
        CreateMap<RegisterUserDTO, User>();

        // Employer Mappings
        CreateMap<Employer, EmployerResponseDTO>();
        CreateMap<Employer, EmployerDTO>();
        CreateMap<EmployerDTO, Employer>();

        // Job Seeker Mappings
        CreateMap<JobSeeker, JobSeekerResponseDTO>();
        CreateMap<JobSeekerDTO, JobSeeker>();

        // Job Listing Mappings
        CreateMap<JobListing, JobListingDTO>();
        CreateMap<JobListing, JobListingResponseDTO>();
        CreateMap<JobListingDTO, JobListing>();
        CreateMap<JobListing, JobListingResponseDTO>()
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Employer.CompanyName));

        // Application Mappings
        CreateMap<Application, ApplicationResponseDTO>();
        CreateMap<ApplicationDTO, Application>();

        // Notification Mappings
        CreateMap<Notification, NotificationResponseDTO>();
    }
}
