using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudmysql.Models
{
    
    public class PacienteModel
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public PacienteModel()
        {
        }

        public PacienteModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
