using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Domain.Entities;

namespace Domain.Seeders
{
    public static class Seeder
    {
        public static void EnsureSeedDataForContext(this ApplicationDbContext context)
        {
            if (!context.Students.Any())
            {
                context.AddRange(students);
                context.SaveChanges();
            }

            if (!context.ClassRooms.Any())
            {
                context.AddRange(classRooms);
                context.SaveChanges();
            }

        }
        public static List<Entities.Student> students = new List<Entities.Student>
        {
            new Entities.Student
            {
                Name = "shubham"
            },
        };
        public static List<Entities.ClassRoom> classRooms = new List<Entities.ClassRoom>
        {
            new Entities.ClassRoom
            {
                Classname = "seventh class"     
            }
        };
    }
}
 