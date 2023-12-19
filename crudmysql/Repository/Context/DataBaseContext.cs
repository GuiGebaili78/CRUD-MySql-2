

using crudmysql.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDMysql.Repository.Context.DataBaseContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DataBaseContext()
        {
        }

        public DbSet<PacienteModel> PacienteModel { get; set; }
    }


}
