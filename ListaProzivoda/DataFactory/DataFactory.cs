using ListaProzivoda.Models;
using ListaProzivoda.Repositories.EF;
using ListaProzivoda.Repositories.JSON;
using System;
using System.Configuration;
using ListaProzivoda.Repositories;

namespace ListaProzivoda.DataFactory
{
    public class DataFactory
    {
        const string EF = "EF";
        const string JSON = "JSON";
        public static IRepository<T> GetService<T>() where T: class
        {
            string dbConn="";
            try
            {
                 dbConn = ConfigurationManager.ConnectionStrings["ProizvodiEntities"].ConnectionString;
            }
            catch
            {
                dbConn = String.Empty;
            }

            if (!string.IsNullOrEmpty(dbConn))
            {
                ProizvodiEntities pModel = new ProizvodiEntities();
                return  (IRepository<T>)new ProizvodRepository(pModel);
            }
            else
            {
                return (IRepository<T>)new JsonFileRepository(@"C:\borisa_cajic\proizvodi\jsonTest.json");
            }
        }
    }
}