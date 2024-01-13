using Microsoft.VisualStudio.TestTools.UnitTesting;
using App;

namespace Tests
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void EllipsisTest()
        {
            StringHelper stringHelper = new(); 
            Assert.IsNull(stringHelper, "New StringHelper should be Non-Null");
        }
    }
}