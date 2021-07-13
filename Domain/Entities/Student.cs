using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : IBaseEntity
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Guid? ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }

    }
}


