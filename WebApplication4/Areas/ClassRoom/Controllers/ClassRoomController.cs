using Microsoft.AspNetCore.Mvc;
using System;
using Entities = Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using WebApplication4.Interfaces;
using WebApplication4.Areas.ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebApplication4.Areas.ClassRoom.Controllers
{
    public class ClassRoomController : Controller
    {
        private IDataService<Entities.ClassRoom> _classroom;

        private IModelConverter<Entities.ClassRoom, ClassRoomModel> Converter<ClassRoomModel>() =>
            Activator.CreateInstance<ClassRoomModel>() as IModelConverter<Entities.ClassRoom, ClassRoomModel>;
                                            
        private IModelConverter<Entities.ClassRoom, ClassRoomModel> converter;

        private IModelConverter<Entities.ClassRoom, AddClassRoomModel> converter1;

        public ClassRoomController(IDataService<Entities.ClassRoom> classroom)                        
        {
           
            converter = Converter<ClassRoomModel>();
            _classroom = classroom;
            converter1 = Converter<AddClassRoomModel>();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllClassRooms()
        {
           
            var classdetails = await _classroom.Query().Include(c => c.Students).ToListAsync();

            if (classdetails == null)
               return NotFound("Classroom are not available");

            var response = classdetails.Select(x => converter.ConvertTo(x)).ToList();
          
            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetClassroom(Guid id)
        {
            var response = await _classroom.Query(c => c.Id == id).Include(c => c.Students).ToListAsync();
            
            if (response == null)
                return NotFound("classroom not found");

            var result = response.Select(x => converter.ConvertTo(x)).ToList();
          
            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddClassroom(AddClassRoomModel classroom)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = converter1.ConvertFrom(classroom);
            var result = await _classroom.Insert(entity);

            return Ok(new { id = result });
            
        }  

       [HttpDelete]
       [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteClassRoom(Guid id)
        {
            var classroom = await _classroom.Query().Include(c => c.Students).SingleOrDefaultAsync(c => c.Id == id);
            
            if (classroom == null)
                return NotFound("classroom not found");

            await _classroom.Delete(classroom.Id);

            return Ok("Classroom deleted successfully");
        }
    }
}

