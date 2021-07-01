using Microsoft.EntityFrameworkCore;
using PruebaTecnicaEdison.DataAccess.Context;
using PruebaTecnicaEdison.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaTecnicaEdison.DataAccess.DAL
{
    public class PersonDAL : IPersonDAL
    {
        private readonly DataContext _context;

        public PersonDAL(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<Person> AddPerson(Person entity)
        {
            await SetContext().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<Person>> GetAllAsync(Expression<Func<Person, bool>> filter)
        {
            return await SetContext().Where(filter).ToListAsync();
        }

        private DbSet<Person> SetContext()
        {
            return _context.Set<Person>();
        }
    }
}
