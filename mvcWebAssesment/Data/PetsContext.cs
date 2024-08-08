using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelViewController.Models;

namespace mvcWebAssesment.Data
{
    public class PetsContext : DbContext
    {
        public PetsContext (DbContextOptions<PetsContext> options)
            : base(options)
        {
        }

        public DbSet<ModelViewController.Models.Dog> Dog { get; set; } = default!;
        public DbSet<ModelViewController.Models.Cat> Cat { get; set; } = default!;
    }
}
