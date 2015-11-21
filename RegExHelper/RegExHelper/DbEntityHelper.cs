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

       public void putUserDataFromFormGlobalConstant(string dbName, string globalPattern, string classDbName )
       {
           using (var db = new MainDbHelper())
           {
               var list = db.ItemsSavedData.Where(e => e.Id >= 0).ToList<ItemSavedData>();

               if (list.Count == 0)
               {
                   ItemSavedData item = new ItemSavedData();
                   item.LastDbName = dbName;
                   item.GlobalConstPattern = globalPattern;
                   item.LastClassName = classDbName;

                   db.ItemsSavedData.Add(item);
               }
               else
               {
                   ItemSavedData item = list[0];

                   item.LastDbName = dbName;
                   item.GlobalConstPattern = globalPattern;
                   item.LastClassName = classDbName;
               }

               db.SaveChanges();
           }
       }

       public ItemSavedData getUserSavedData()
       {
           ItemSavedData item = null;
           using (var db = new MainDbHelper())
           {
               var list = db.ItemsSavedData.Where(e => e.Id >= 0).ToList<ItemSavedData>();

               if (list.Count > 0)
               {
                   item = list[0];
               }
           }
           return item;
       }

       public void putUserDataFromFormLocalConstant(string dbName, string localPattern, string classDbName)
       {
           using (var db = new MainDbHelper())
           {
               var list = db.ItemsSavedData.Where(e => e.Id >= 0).ToList<ItemSavedData>(); 

               if (list.Count == 0)
               {
                   ItemSavedData item = new ItemSavedData();
                   item.LastDbName = dbName;
                   item.LocalConstPattern = localPattern;
                   item.LastClassName = classDbName;

                   db.ItemsSavedData.Add(item);
               }
               else
               {
                   ItemSavedData item = list[0];

                   item.LastDbName = dbName;
                   item.LocalConstPattern = localPattern;
                   item.LastClassName = classDbName;
               }

               db.SaveChanges();
           }
         
       }

       public string getConstantsByDbName(string dbName)
       {
           using (var db = new MainDbHelper())
           {
               var rw = db.ResultItemWorks.Where(e => e.DbName == dbName);

               if (rw.Count() == 0)
               {
                   return null;
               }
               else
               {
                   return rw.First<ResultItemWork>().ConstantsValues;
               }
           }
       }


       public List<string> getDbNames()
       {
           List<string> listNames = new List<string>();
           using (var db = new MainDbHelper())
           {
               var list = db.ResultItemWorks.Where(e => e.Id >= 0).ToList<ResultItemWork>();

               foreach (var item in list)
               {
                  listNames.Add(item.DbName);
               }
           }

           return listNames;
       }

       public List<string> getLastDbNames()
       {
           List<string> listNames = new List<string>();
           using (var db = new MainDbHelper())
           {
               var list = db.ResultItemWorks.Where(e => e.Id >= 0).ToList<ResultItemWork>();

               foreach (var item in list)
               {
                   listNames.Add(item.ClassName);
               }
           }

           return listNames;
       }
       public void addResultWork(string dbName, string resultValue, string dbClassName)
       {
           ResultItemWork item = new ResultItemWork();
           item.DbName = dbName;
           item.ConstantsValues = resultValue;
           item.ClassName = dbClassName;

           if (!wasUpdateResultWork(item))
           {
               using (var db = new MainDbHelper())
               {
                   db.ResultItemWorks.Add(item);
                   db.SaveChanges();
               }
           }
       }


       private bool wasUpdateResultWork(ResultItemWork item)
       {
           using (var db = new MainDbHelper())
           {
               var rw = db.ResultItemWorks.Where(e => e.DbName == item.DbName);

               if (rw.Count() == 0)
               {
                   return false;
               }
               else
               {
                   rw.First<ResultItemWork>().ConstantsValues = item.ConstantsValues;
                   db.SaveChanges();
                   return true;
               }
           }

       }
    }
}
