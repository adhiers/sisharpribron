using System;
using Microsoft.EntityFrameworkCore;
using SampleASPMVCEF.Models;

namespace SampleASPMVCEF.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Car { get; set; } = null!;

}
