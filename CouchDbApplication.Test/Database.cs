using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouchDbApplication;
using LoveSeat;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace CouchDbApplication.Test
{
    [TestClass]
    public class Database:BaseConnection
    {
        [TestMethod]
        public void DeleteDatabase()
        {
            CouchDbClient.DeleteDatabase(ConfigurationManager.AppSettings["databasename"]);
        }

        [TestMethod]
        public void CreateDatabase()
        {
            CarService carService = new CarService();
            List<Car> allCars = carService.CreateCars();
            foreach (Car item in allCars)
            {
                Db.CreateDocument(item);
            }
        }

        [TestMethod]
        public void CreateView()
        {
            StreamReader reader = new StreamReader(@"C: \Users\endst\Documents\Visual Studio 2015\Projects\CocuhDBTry3\CouchDbApplication\DesignDocument.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();
            Db.CreateDocument(jsonString);
            Db.SetDefaultDesignDoc(jsonString);
        }
    }
}
