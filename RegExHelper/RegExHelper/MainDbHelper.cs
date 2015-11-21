using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExHelper
{
    public class MainDbHelper : DbContext
    {
        public DbSet<ResultItemWork> ResultItemWorks { get; set; }
        public DbSet<ItemSavedData> ItemsSavedData { get; set; }
    }
}
