using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExHelper
{
   public class DbEntityHelper
    {
       private DbEntityHelper() { }

       private static DbEntityHelper instance;

       public static DbEntityHelper getInstance()
       {
           if (instance == null)
           {
               instance = new DbEntityHelper();
           }
           return instance;
       }

       public string getConstantsByDbName(string dbName)
       {
           using (var db = new MyContext())
           {
               var rw = db.ResultWorks.Where(e => e.DbName == dbName);

               if (rw.Count() == 0)
               {
                   return null;
               }
               else
               {
                   return rw.First<ResultWorkItem>().ConstantsValues;
               }
           }
       }


       public List<string> getDbNames()
       {
           List<string> listNames = new List<string>();
           using (var db = new MyContext())
           {
               var list = db.ResultWorks.Where(e => e.Id >= 0).ToList<ResultWorkItem>();

               foreach (var item in list)
               {
                  listNames.Add(item.DbName);
               }
           }

           return listNames;
       }
       public void addResultWork( string dbName, string resultValue )
       {
           ResultWorkItem item = new ResultWorkItem();
           item.DbName = dbName;
           item.ConstantsValues = resultValue;

           if (!wasUpdateResultWork(item))
           {
               using (var db = new MyContext())
               {
                   db.ResultWorks.Add(item);
                   db.SaveChanges();
               }
           }
       }


       private bool wasUpdateResultWork(ResultWorkItem item)
       {
           using (var db = new MyContext())
           {
               var rw = db.ResultWorks.Where(e => e.DbName == item.DbName);

               if (rw.Count() == 0)
               {
                   return false;
               }
               else
               {
                   rw.First<ResultWorkItem>().ConstantsValues = item.ConstantsValues;
                   db.SaveChanges();
                   return true;
               }
           }

       }
    }
}
