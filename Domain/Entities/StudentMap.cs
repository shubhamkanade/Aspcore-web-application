using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentMap
    {
        public StudentMap(EntityTypeBuilder <Student> entityBuider)
        {
            entityBuider.HasKey(s => s.Id);
            entityBuider.Property(s => s.Name).IsRequired();
        }
    }
}
