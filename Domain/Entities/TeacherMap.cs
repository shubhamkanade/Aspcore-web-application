using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeacherMap
    {
        public TeacherMap(EntityTypeBuilder <Teacher> entityBuider)
        {
            entityBuider.HasKey(t => t.Id);
            entityBuider.Property(t => t.Subname).IsRequired();
        }
    }
}
