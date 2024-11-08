using LoyalCustomers.Test.Utilities;

namespace LoyalCustomers.Test;

[TestClass]
public static class CustomerAnalyzerTests
{
    [TestMethod]
    public static void SimpleTestCases()
    {
        var day1 = TestCaseLoader.LoadPageViews("TestCases/simple_day_1.csv");
        var day2 = TestCaseLoader.LoadPageViews("TestCases/simple_day_2.csv");

        var result = CustomerAnalyzer.FindLoyalCustomers(day1, day2);

        Assert.AreEqual(3, result.Count());
        Assert.IsTrue(result.Contains("customer_1"));
        Assert.IsTrue(result.Contains("customer_2"));
        Assert.IsTrue(result.Contains("customer_5"));
    }

    [TestMethod]
    public static void ComplexTestCases()
    {
        var day1 = TestCaseLoader.LoadPageViews("TestCases/complex_day_1.csv");
        var day2 = TestCaseLoader.LoadPageViews("TestCases/complex_day_2.csv");

        var start = DateTime.Now;
        var result = CustomerAnalyzer.FindLoyalCustomers(day1, day2);
        var end = DateTime.Now;

        Assert.AreEqual(5000, result.Count());
        Assert.IsTrue(end - start < TimeSpan.FromSeconds(1));
    }
}