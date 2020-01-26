using LearningAsync.Models.DBTables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace LearningAsync.Repository.Models
{
    public class MyDB : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}
