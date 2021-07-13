using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public  DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public  DbSet<ClassRoom> ClassRooms { get; set; }

    }

}
