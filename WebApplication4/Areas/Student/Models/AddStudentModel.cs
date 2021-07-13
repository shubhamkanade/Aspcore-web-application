using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Interfaces;
using Entities = Domain.Entities;

namespace WebApplication4.Areas.Student.Models
{
    public class AddStudentModel : IModelConverter<Entities.Student, AddStudentModel>
    {
        public string Name { get; set; }

        public Guid? ClassRoomId { get; set; }

        public Entities.Student ConvertFrom(AddStudentModel model) => new Entities.Student
        {
            Name = model.Name,
            ClassRoomId = model?.ClassRoomId
        };

        public AddStudentModel ConvertTo(Entities.Student model) => new AddStudentModel
        {
            Name = model.Name,
            ClassRoomId = model?.ClassRoomId
        };
    }
}
