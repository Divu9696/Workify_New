using System;
using Workify.DTOs;

namespace Workify.Services;

public interface IEmployerService
{
    Task<EmployerResponseDTO?> GetEmployerByIdAsync(int id);
    Task<EmployerResponseDTO?> GetEmployerByUserIdAsync(int userId);
    Task AddEmployerAsync(EmployerDTO employerDto);
    Task UpdateEmployerAsync(int id, EmployerDTO employerDto);
    Task DeleteEmployerAsync(int id);
    Task<IEnumerable<EmployerDTO>> GetAllEmployersAsync();
}
