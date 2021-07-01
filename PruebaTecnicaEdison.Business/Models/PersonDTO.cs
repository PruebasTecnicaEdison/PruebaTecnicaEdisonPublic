using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaTecnicaEdison.Business.Models
{
    public class PersonDTO
    {
        [DisplayName("Numero de documento")]
        [Required]
        public int DocumentNumber { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Apellido")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Direccion")]
        [Required]
        public string Address { get; set; }

        [DisplayName("Numero de celular")]
        [Required]
        public string PhoneNumber { get; set; }

        [DisplayName("Correo")]
        [Required]
        public string Email { get; set; }
    }
}
