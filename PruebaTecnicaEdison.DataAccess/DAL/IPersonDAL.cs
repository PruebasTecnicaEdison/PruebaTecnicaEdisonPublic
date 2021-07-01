using PruebaTecnicaEdison.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaTecnicaEdison.DataAccess.DAL
{
    public interface IPersonDAL
    {
        Task<IList<Person>> GetAllAsync(Expression<Func<Person, bool>> filter);
        Task<Person> AddPerson(Person entity);
    }
}
