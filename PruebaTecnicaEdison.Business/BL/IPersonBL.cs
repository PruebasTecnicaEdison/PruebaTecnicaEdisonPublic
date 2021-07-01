using PruebaTecnicaEdison.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaEdison.Business.BL
{
    public interface IPersonBL
    {
        Task AddPerson(PersonDTO model);
        Task<IList<PersonDTO>> GetPeople(int documentNumber);
    }
}