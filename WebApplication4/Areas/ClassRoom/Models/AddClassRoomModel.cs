using System;
using System.Collections.Generic;
using System.Linq;
using Entities = Domain.Entities;
using System.Threading.Tasks;
using WebApplication4.Interfaces;

namespace WebApplication4.Areas.ClassRoom.Models
{
    public class AddClassRoomModel :IModelConverter<Entities.ClassRoom, AddClassRoomModel>
    {
       
        public string Classname { get; set; }

        public Entities.ClassRoom ConvertFrom(AddClassRoomModel model) => new Entities.ClassRoom
        {
            Classname = model.Classname 
        };

        public AddClassRoomModel ConvertTo(Entities.ClassRoom model) => new AddClassRoomModel
        {
            Classname = model.Classname
        };
    }

}
