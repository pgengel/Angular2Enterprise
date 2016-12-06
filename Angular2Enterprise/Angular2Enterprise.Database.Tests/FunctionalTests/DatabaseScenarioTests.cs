using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Angular2Enterprise.Database.Contexts;

namespace Angular2Enterprise.Database.Tests.FunctionalTests
{
    [TestClass]
    public class DatabaseScenarioTests
    {
        [TestMethod]
        public void CanCreateDatabase()
        {
            using (var db = new DataContext())
            {
                db.Database.Create();
            }

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            using (var db = new DataContext())
                if (db.Database.Exists())
                    db.Database.Delete();
        }
    }
}
