using PruebaTecnicaEdison.Business.Models;
using PruebaTecnicaEdison.DataAccess.DAL;
using PruebaTecnicaEdison.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaEdison.Business.BL
{
    public class PersonBL : IPersonBL
    {
        private readonly IPersonDAL _personDAL;

        public PersonBL(IPersonDAL personDAL)
        {
            _personDAL = personDAL;
        }

        public async Task<IList<PersonDTO>> GetPeople(int documentNumber)
        {
            List<PersonDTO> response = new List<PersonDTO>();
            IList<Person> entities = await _personDAL.GetAllAsync(x => x.DocumentNumber ==
                (documentNumber != default(int) ? documentNumber : x.DocumentNumber));

            entities.ToList().Where(y => y.DocumentNumber != default(int)).ToList()
                .ForEach(x => response.Add(new PersonDTO()
                {
                    Address = x.Address,
                    DocumentNumber = x.DocumentNumber,
                    Email = x.Email,
                    LastName = x.LastName,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber
                }));
            return response;
        }

        public async Task AddPerson(PersonDTO model)
        {
            if (model.DocumentNumber != default(int))
                await _personDAL.AddPerson(new Person()
                {
                    Address = model.Address,
                    DocumentNumber = model.DocumentNumber,
                    Email = model.Email,
                    LastName = model.LastName,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                });
        }
    }
}
