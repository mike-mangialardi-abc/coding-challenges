using LoyalCustomers.Models;

namespace LoyalCustomers;
/*
 * The CustomerAnalyzer class provides methods to analyze customer data.
 * The FindLoyalCustomers method identifies customers who have visited the site on both days.
 */
public static class CustomerAnalyzer
{
    public static IEnumerable<string> FindLoyalCustomers(IEnumerable<PageView> day1, IEnumerable<PageView> day2)
    {
        return new List<string>();
    }
}
