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

            // Basic cases
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

            Assert.AreEqual("/home/index", stringHelper.UrlCombine("///home//", "//index///"),
                "UrlCombine('///home//', '//index///') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("/home /", " / index "),
                "UrlCombine('/home /', ' / index ') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("/home$%#", "#index@!"),
                "UrlCombine('/home$%#', '#index@!') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("", "/home/index"),
                "UrlCombine('', '/home/index') should be '/home/index'");
            Assert.AreEqual("/home/index", stringHelper.UrlCombine("/home", ""),
                "UrlCombine('/home', '') should be '/home/index'");
            //Assert.AreEqual("/home/index", stringHelper.UrlCombine("", ""),
            //    "UrlCombine('', '') should be '/home/index'");
        }

        [TestMethod]
        public void SpacefyTest()
        {
            StringHelper stringHelper = new StringHelper();
            Assert.IsNotNull(stringHelper, "New StringHelper should be Non-Null");
            Assert.AreEqual("1 000", stringHelper.Spacefy(1000));

            Dictionary<double, String> testCases = new()
            {
                { 1101, "1 101" },
                { 10101, "10 101" },
                { 100101, "100 101" },
                { 1100101, "1 100 101" },
                { 10100101, "10 100 101" },
                { 100100101, "100 100 101" },
                { 1100100101, "1 100 100 101" },
                { 10100100101, "10 100 100 101" },
                { -10100100101, "-10 100 100 101" },
                { 100100100101, "100 100 100 101" },
                { -100100100101, "-100 100 100 101" },
                { 1010.1, "1 010.1" },
                { 1010.101, "1 010.101" },
                { 1010.101101, "1 010.101 101" },
            };

            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    stringHelper.Spacefy(testCase.Key),
                    $"Spacefy({testCase.Key})");
            }
        }

        [TestMethod]
        public void EllipsisErrorsTest()
        {
            StringHelper stringHelper = new();
            Assert.IsNotNull(stringHelper, "New StringHelper should be Non-Null");

            var ex = Assert.ThrowsException<ArgumentNullException>(
                () => stringHelper.Ellipsis(null!),
                "Ellipsis(null!) --> Exception"
            );
            Assert.IsTrue(
                ex.Message.Contains("input"));
            stringHelper.Ellipsis("123");
            try
            {
                stringHelper.Ellipsis("123", true, 20);
            }
            catch
            {
                Assert.Fail("Ellipsis('123', 20) must NOT throw exception");
            }
        }

    }
}