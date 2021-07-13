using Domain.Interfaces;
using Entities = Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Areas.Student.Models;
using WebApplication4.Controllers;
using WebApplication4.Interfaces;
using System.Collections;
using WebApplication4.Areas.ClassRoom.Models;

namespace WebApplication4.Areas.Student.Controllers
{

    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IDataService<Entities.Student> _student;

        private IDataService<Entities.ClassRoom> _classroom;
        private IModelConverter<Entities.Student, StudentModel> Converter<StudentModel>() => 
            Activator.CreateInstance<StudentModel>() as IModelConverter<Entities.Student, StudentModel>;

        private IModelConverter<Entities.Student,StudentModel> converter;

        private IModelConverter<Entities.Student, AddStudentModel> converter1;
        public StudentsController(IDataService<Entities.Student> student, IDataService<Entities.ClassRoom> classroom)
        {
            converter = Converter<StudentModel>();
            _student = student;
            _classroom = classroom;
            converter1 = Converter<AddStudentModel>();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _student.GetAll();

            if (result == null)
                return NotFound("students not found");

            var response = result.Select(x => converter.ConvertTo(x)).ToList();

            return Ok(response);
          
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {

            var result = await _student.Get(id);
            
            if (result == null)
               return NotFound("Student not found");

            return Ok(converter.ConvertTo(result));
           
        }
        
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddStudent(AddStudentModel student)
        {
           if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (student.ClassRoomId != null)
            {
                var isClassroomValid = _classroom.Query().Any(c => c.Id == student.ClassRoomId);
                if(!isClassroomValid)
                return NotFound("Classroom not found");
            }

            var entity = converter1.ConvertFrom(student);
            var result = await _student.Insert(entity);

            return Ok(new { id = result });
        }
        
        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> UpdateStudent(StudentModel student)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (student.ClassRoomId != null)
            {
                var isClassroomValid = _classroom.Query().Any(c => c.Id == student.ClassRoomId);
                if (!isClassroomValid)
                    return NotFound("Classroom not found");
            }
           
            var entity = converter.ConvertFrom(student);
            var result = await _student.Insert(entity);

            return Ok( new { id = result });

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var studentInfo = await _student.Get(id);

            if (studentInfo == null)
                return NotFound("Student not found");

            await _student.Delete(id);

            return Ok("Student deleted successfully");
            
        }
    
    }

}
