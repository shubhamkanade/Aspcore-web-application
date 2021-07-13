using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher : IBaseEntity
    {
        public string Subname { get; set; }
        public Guid Id { get; set; }
    }
}

