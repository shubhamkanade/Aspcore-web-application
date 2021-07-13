using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = Domain.Entities;
using WebApplication4.Interfaces;
using WebApplication4.Areas.Student.Models;
using Domain.Interfaces;

namespace WebApplication4.Areas.ClassRoom.Models
{
    public class ClassRoomModel : IModelConverter<Entities.ClassRoom, ClassRoomModel> 
    {
        public Guid Id { get; set; }
        public string Classname { get; set; }
        public ICollection<StudentModel> Students { get; set; }
        private IModelConverter<Entities.Student, StudentModel> Converter<StudentModel>() =>
            Activator.CreateInstance<StudentModel>() as IModelConverter<Entities.Student, StudentModel>;

        public Entities.ClassRoom ConvertFrom(ClassRoomModel model) => new Entities.ClassRoom
        {
            Id = model.Id,
            Classname = model.Classname,
            Students = model.Students.Select(s => Converter<StudentModel>().ConvertFrom(s)).ToList()
        };

        public ClassRoomModel ConvertTo(Entities.ClassRoom model) => new ClassRoomModel
        {
            
            Id = model.Id,
            Classname  = model.Classname,
            Students = model.Students.Select(s => Converter<StudentModel>().ConvertTo(s)).ToList()
        };
    }
}
