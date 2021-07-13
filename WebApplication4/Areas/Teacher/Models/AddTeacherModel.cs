using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Interfaces;
using Entities = Domain.Entities;

namespace WebApplication4.Areas.Teacher.Models
{
    public class AddTeacherModel : IModelConverter<Entities.Teacher, AddTeacherModel>
    {
        public string Subname { get; set; }

        public Entities.Teacher ConvertFrom(AddTeacherModel model) => new Entities.Teacher
        {
            Subname = model.Subname
        };

        public AddTeacherModel ConvertTo(Entities.Teacher model) => new AddTeacherModel
        {
            Subname = model.Subname
        };
    }
}
