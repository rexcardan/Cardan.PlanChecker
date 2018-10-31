using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cardan.PlanChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.Constraints;

namespace Cardan.PlanChecker.Tests
{
    [TestClass()]
    public class CTDateConstraintTests
    {
        [TestMethod()]
        public void ConstrainPassesTest()
        {
            var im =  new Image();
            im.CreationDateTime = DateTime.Now.AddDays(-59); //59 days ago
            var expected = ResultType.PASSED;
            var actual = new CTDateConstraint().Constrain(im).ResultType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConstrainFailsTest()
        {
            var im = new Image();
            im.CreationDateTime = DateTime.Now.AddDays(-61); //61 days ago
            var expected = ResultType.ACTION_LEVEL_3;
            var actual = new CTDateConstraint().Constrain(im).ResultType;
            Assert.AreEqual(expected, actual);
        }
    }
}