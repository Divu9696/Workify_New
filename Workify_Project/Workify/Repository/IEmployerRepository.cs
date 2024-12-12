using System;
using Workify.Models;

namespace Workify.Repository;

public interface IEmployerRepository : IRepository<Employer>
{
    Task<Employer?> GetByUserIdAsync(int userId);
}

