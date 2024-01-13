using App;
namespace AppTest

{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void EllipsisTest()
        {
            StringHelper stringHelper = new();
            Assert.IsNotNull(stringHelper, "New StringHelper should be Non-Null");
            Assert.AreEqual("Hello...", stringHelper
                .Ellipsis("Hello world!", false, 5),
                "'Hello world!' -> 'Hello...'"
                );
        }

        [TestMethod]
        public void UrlCombineTest()
        {
            StringHelper stringHelper = new StringHelper();
            Assert.IsNotNull(stringHelper, "New StringHelper should be Non-Null");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("/home/", "/index/"),
                "UrlCombine('/home/', '/index/') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("home", "index"),
                "UrlCombine('home', 'index') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("/home/", "/index/"),
                "UrlCombine('/home/', '/index/') with trailing slashes should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("/home", "index"),
                "UrlCombine('/home', 'index') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("home/", "index"),
                "UrlCombine('home/', 'index') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("", ""),
                "UrlCombine('', '') should be '/home/index'");
        }
    }
}