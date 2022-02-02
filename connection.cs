using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;


namespace TinyLibraryManagementSystem
{
    internal class connection
    {
        public OracleConnection thisConnection = new OracleConnection("Data Source=XE;User ID=admin;Password=abrar;");
    }
}
