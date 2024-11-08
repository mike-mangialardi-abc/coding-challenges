using System.Globalization;
using LoyalCustomers.Models;

namespace LoyalCustomers.Test.Utilities
{
    public static class TestCaseLoader
    {
        public static IEnumerable<PageView> LoadPageViews(string path)
        {
            var pageViews = new List<PageView>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    var parts = line.Split(',');
                    pageViews.Add(new PageView
                    {
                        Date = DateTime.Parse(parts[0], new CultureInfo("en-US")),
                        CustomerId = parts[1],
                        PageId = parts[2]
                    });
                }
            }

            return pageViews;
        }
    }
}