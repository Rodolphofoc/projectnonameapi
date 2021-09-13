using project.noname.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.noname.data.Helpers
{
    public static class Extensions
    {
        public static string SqlConnectionString(this DbSettings obj)
        {
            //return $"User ID={obj.Username};Password={obj.Password};Persist Security Info=False;Initial Catalog={obj.Database};Data Source={obj.Server};";
            return "Server=localhost\\SQLEXPRESS;Database=nonameproject;Trusted_Connection=True";
        }
    }
}
