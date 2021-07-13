using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Interfaces;
using Entities = Domain.Entities;

namespace WebApplication4.Areas.Student.Models
{
    public class StudentModel : IModelConverter<Entities.Student, StudentModel>
    {

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public Guid? ClassRoomId { get; set; }

        

        public StudentModel ConvertTo(Entities.Student model) => new StudentModel
        {
            Id = model.Id,
            Name = model.Name,
            ClassRoomId = model?.ClassRoomId
        };

        public Entities.Student ConvertFrom(StudentModel model) => new Entities.Student
        {
            Id = model.Id,
            Name = model.Name,
            ClassRoomId = model?.ClassRoomId
        };
   
    }
}
