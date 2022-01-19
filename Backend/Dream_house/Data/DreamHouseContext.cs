using System;
using Dream_house.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dream_house.Controllers;

namespace Dream_house.Data
{
    public class DreamHouseContext: DbContext
    {
        public DbSet<DataBaseModel> DataBaseModels { get; set; }

        public DreamHouseContext(DbContextOptions<DreamHouseContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
