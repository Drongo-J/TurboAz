using ADO.NET_Task9.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Task9.DataAccess
{
    public class Database : DbContext
    {
        public Database()
            :base("Data Source=(localdb)\\ProjectModels;Initial Catalog=CarsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
