using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExHelper
{
   public class ItemSavedData
    {
        public int Id { get; set; }

        public string LastDbName { get; set; }

        public string GlobalConstPattern { get; set; }

        public string LocalConstPattern { get; set; }
    }
}
