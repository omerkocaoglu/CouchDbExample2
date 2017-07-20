using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveSeat;
using System.Configuration;

namespace CouchDbApplication
{
    public class BaseConnection
    {
        private CouchClient couchDbClient;
        public BaseConnection()
        {
            if (couchDbClient == null)
            {
                couchDbClient = new CouchClient(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            }
        }
        public CouchClient CouchDbClient
        {
            get
            {
                return couchDbClient;
            }
        }

        private CouchDatabase db;
        public CouchDatabase Db
        {
            get
            {
                CouchDbClient.CreateDatabase(ConfigurationManager.AppSettings["databasename"]);
                db = CouchDbClient.GetDatabase(ConfigurationManager.AppSettings["databasename"]);
                return db;
            }
        }
    }
}
