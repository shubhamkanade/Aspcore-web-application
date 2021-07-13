using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassRoom : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Classname { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
