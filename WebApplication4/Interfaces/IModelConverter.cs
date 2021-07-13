using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Areas.Student.Models;

namespace WebApplication4.Interfaces
{
    public interface IModelConverter<T, M>
    {
        M ConvertTo(T model);
        T ConvertFrom(M model);
    }
}
