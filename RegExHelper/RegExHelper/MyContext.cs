using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExHelper
{
    public class MyContext : DbContext
    {
        public DbSet<ResultWorkItem> ResultWorks { get; set; }
    }
}
