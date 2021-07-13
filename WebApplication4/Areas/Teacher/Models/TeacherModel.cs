using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Interfaces;
using Entities = Domain.Entities;

namespace WebApplication4.Areas.Teacher.Models
{
    public class TeacherModel : IModelConverter<Entities.Teacher, TeacherModel>
    {
        public Guid Id { get; set; }

        public string Subname { get; set; }

       public Entities.Teacher ConvertFrom(TeacherModel model) => new Entities.Teacher
        {
            Id = model.Id,
            Subname = model.Subname
        };

        public TeacherModel ConvertTo(Entities.Teacher model) => new TeacherModel
        {
            Id = model.Id,
            Subname = model.Subname
        };
    }
}
