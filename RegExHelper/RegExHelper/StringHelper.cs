﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExHelper
{
    public class StringHelper
    {

        public static string getSqlQueryByMap(Dictionary<string, string> map, string sqlValue)
        {
            foreach (string key in map.Keys)
            {
                string replace = "";

                replace += " \"";
                replace += " + ";
                replace += key;
                replace += " + ";
                replace += "\" ";

                string pat = @"\b" + map[key] + @"\b";
                Regex rgx = new Regex(pat);

                sqlValue = rgx.Replace(sqlValue, replace);
            }

            sqlValue = sqlValue.Replace(" . ", ".");

            sqlValue = "String query = \"" + sqlValue + "\";";

            return sqlValue;
        }

        public static Dictionary<string, string> getConstantsMap(string sqlValue, string input )
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            string pattern1 = @"\b\w+\s*\=\s*\|\b\w+\|\;";          

            input = input.Replace("\"", "|");

            map.Clear();

            string pattern2 = @"\w+";

            foreach (Match match in Regex.Matches(input, pattern1, RegexOptions.IgnoreCase))
            {
                string key = null;
                string value = null;

                foreach (Match match1 in Regex.Matches(match.Value, pattern2, RegexOptions.IgnoreCase))
                {
                    if (key == null)
                    {
                        key = match1.Value;
                    }
                    else if (value == null)
                    {
                        value = match1.Value;
                    }

                }

                if (!map.ContainsKey(key))
                {
                    map.Add(key, value);
                }
            }

           return map;

        }

        public static string convertSqlQueryToConstants(string dbName, string patternConst)
        {
            string resultValue = "";

            List<string> listTableNames = DbMysqlHelper.getInstance().getTableNames(dbName);

            // output tables
            foreach (string tableName in listTableNames)
            {
                resultValue += patternConst + " " + (tableName + "_table").ToUpper() + " = " + "\"" + tableName + "\"" + ";" + "\n";
            }

            resultValue += "\n";

            Dictionary<string, string> map = DbMysqlHelper.getInstance().getMapColumns(listTableNames, dbName, patternConst);
            
            //output columns
            foreach (string key in map.Keys)
            {
                resultValue += map[key];
            }

            // save or change date
            DbEntityHelper.getInstance().addResultWork(dbName, resultValue);

            return resultValue;

        }
    }
}
