using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Entities = Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Interfaces;
using WebApplication4.Areas.Teacher.Models;

namespace WebApplication4.Areas.Teacher.Controllers
{
    
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private IDataService<Entities.Teacher> _teacher;
        private IModelConverter<Entities.Teacher, Teachermodel> Converter<Teachermodel>() => 
            Activator.CreateInstance<Teachermodel>() as IModelConverter<Entities.Teacher, Teachermodel>;

        private IModelConverter<Entities.Teacher, TeacherModel> converter;

        private IModelConverter<Entities.Teacher, AddTeacherModel> converter1;

        public TeachersController(IDataService<Entities.Teacher> teacher)
        {
             converter = Converter<TeacherModel>();
            _teacher = teacher;
            converter1 = Converter<AddTeacherModel>();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetTeachers()
        {

            var result = await _teacher.GetAll();

            if (result == null)
                return NotFound("Teachers not found");
            
            var response = result.Select(x => converter.ConvertTo(x)).ToList();
            
            return Ok(response);
   
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetTeacher(Guid id)
        {
            var result = await _teacher.Get(id);

            if(result == null)
                return NotFound("Teacher not found");

            return Ok(converter.ConvertTo(result));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddTeacher(AddTeacherModel teacher)
        {
            
            if(!ModelState.IsValid)
                return BadRequest();
            
            var entity = converter1.ConvertFrom(teacher);
            var response = await _teacher.Insert(entity);

            return Ok(new { id = response });
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateTeacher(Guid id,TeacherModel teacher)
        {
            
            if(!ModelState.IsValid)
                return BadRequest();

            teacher.Id = id;
            var entity = converter.ConvertFrom(teacher);
            var response = await _teacher.Update(entity);

            return Ok(new { id = response });
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            var result = await _teacher.Get(id);

            if (result == null)
                return NotFound("Teacher not found");

            await _teacher.Delete(id);

            return Ok("Teacher deleted successfully");
        }
    }
}
