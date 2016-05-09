using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFTest
{
    [TestClass]
    public class TestParentChildRelationship
    {
        private TestContext _context;
        private string _file;

        [TestInitialize]
        public void SetUp()
        {
            _file = Path.GetTempFileName();
            _context = new TestContext(_file);
            _context.Initialize();
        }

        [TestCleanup]
        public void TearDown()
        {
            File.Delete(_file);
        }

        [TestMethod]
        public void AllAtOnce()
        {
            var mark = _context.Add(new Parent { Name = "Mark" });
            var tom = _context.Add(new Child { Name = "Tom" });
            var sally = _context.Add(new Child { Name = "Sally" });
            mark.Entity.Children = new List<Child> { tom.Entity, sally.Entity };
            mark.Entity.FavoriteChild = sally.Entity;
            _context.SaveChanges();

            Assert.AreEqual(1, _context.Parents.Count());
            Assert.AreEqual(2, _context.Parents.First().Children.Count);
            Assert.AreEqual("Sally", _context.Parents.First().FavoriteChild.Name);
        }

        [TestMethod]
        public void TwoStep()
        {
            var mark = _context.Add(new Parent { Name = "Mark" });
            var tom = _context.Add(new Child { Name = "Tom" });
            var sally = _context.Add(new Child { Name = "Sally" });
            mark.Entity.Children = new List<Child> { tom.Entity, sally.Entity };
            _context.SaveChanges();
            mark.Entity.FavoriteChild = sally.Entity;
            _context.SaveChanges();

            Assert.AreEqual(1, _context.Parents.Count());
            Assert.AreEqual(2, _context.Parents.First().Children.Count);
            Assert.AreEqual("Sally", _context.Parents.First().FavoriteChild.Name);
        }
    }
}
