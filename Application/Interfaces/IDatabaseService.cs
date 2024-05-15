using Domain.Investors;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IDatabaseService
{
    DbSet<Investor> Investors { get; set; }
}