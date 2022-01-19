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
        public DbSet<Models.Home> Home { get; set; }
        public DbSet<Models.Room> Room { get; set; }
        public DbSet<Models.DecorationIdea> DecorationIdea { get; set; }
        public DbSet<Models.Room_DecorationIdea> Room_DecorationIdea { get; set; }

        public DreamHouseContext(DbContextOptions<DreamHouseContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // ONE TO MANY
            builder.Entity<Models.Home>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Home);

            // MANY TO MANY
            builder.Entity<Room_DecorationIdea>()
                .HasKey(rdi => new { rdi.RoomId, rdi.DecorationIdeaId });

            builder.Entity<Room_DecorationIdea>()
                .HasOne<Room>(rdi => rdi.Room)
                .WithMany(r => r.Room_DecorationIdeas)
                .HasForeignKey(rdi => rdi.RoomId);

            builder.Entity<Room_DecorationIdea>()
                .HasOne<DecorationIdea>(rdi => rdi.DecorationIdea)
                .WithMany(di => di.Room_DecorationIdeas)
                .HasForeignKey(rdi => rdi.DecorationIdeaId);

            base.OnModelCreating(builder);
        }
    }
}
