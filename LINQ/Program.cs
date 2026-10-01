namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var outofstocks = ListGenerators.ProductList.First(p => p.UnitsInStock == 0).ProductName;
            Console.WriteLine(outofstocks);
            //////////////////////////////
            var firstproducts = ListGenerators.ProductList.FirstOrDefault(x => x.UnitPrice > 1000);
            Console.WriteLine(firstproducts);
            ///////////////////
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var greterss = Arr.Where(x => x > 5).Skip(1).First();
            Console.WriteLine(greterss);
            ////////////////////
            var sortname = ListGenerators.ProductList.OrderBy(x => x.ProductName);
            foreach (var item in sortname)
            {
                Console.WriteLine(item);
            }
            ///////////////////
            string[] Arr2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var comparrersort = Arr2.OrderBy(x => x, StringComparer.OrdinalIgnoreCase);
            foreach (var item in comparrersort)
            {
                Console.WriteLine(item);
            }
            //////////////////
            var sortproductsbyunits = ListGenerators.ProductList.OrderByDescending(x => x.UnitsInStock);
            foreach (var item in sortproductsbyunits) { Console.WriteLine(item); }
            /////////////////
            string[] Arr3 = { "zero", "one", "two", "three", "four", "five", "six", "seven",
"eight", "nine" };
            var sortbylength = Arr3.OrderBy(x => x.Length).ThenBy(x => x);
            foreach (var item in sortbylength) { Console.WriteLine(item); }

            //////////////////
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortwords = words.OrderBy(x => x.Length).ThenBy(x => x, StringComparer.OrdinalIgnoreCase);
            foreach (var item in sortwords) { Console.WriteLine(item); }
            //////////////////
            var sortbycatogry = ListGenerators.ProductList.OrderBy(x => x.Category).ThenByDescending(x => x.UnitPrice);
            foreach (var item in sortbycatogry) { Console.WriteLine(item); }
            ////////////////
            string[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortlength = Arr4.OrderBy(x => x.Length).ThenByDescending(x => x, StringComparer.OrdinalIgnoreCase);
            foreach (var item in sortlength) { Console.WriteLine(item); }
            ////////////
            string[] Arr5 = { "zero", "one", "two", "three", "four", "five", "six", "seven",
"eight", "nine" };
            var findi = Arr5.Where(x => x[1] == 'i').Reverse().ToList();
            foreach (var item in findi) { Console.WriteLine(item); }

            ////////////////////////

            var listofsequence = ListGenerators.ProductList.Select(x => x.ProductName);
            foreach (var item in listofsequence) { Console.WriteLine(item); }
            ///////////////
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var wordsupperandlow = words2.Select(x => new
            {
                lower = x.ToLower(),
                upper = x.ToUpper(),
            });
            foreach (var item in wordsupperandlow)
            {
                Console.WriteLine($"Upper: {item.upper}, Lower: {item.lower}");
            }
            /////////////////
            var productproparties = ListGenerators.ProductList.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                Price = x.UnitPrice
            });
            foreach (var item in productproparties)
            {
                Console.WriteLine($"{item.ProductName} - {item.Price}");

            }
            ////////////////
            int[] Arr6 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var ifmatch = Arr6.Select((value, index) => new
            {
                Number = value,
                InPlace = value == index
            });
            foreach (var item in ifmatch) { Console.WriteLine($"{item.Number}: {item.InPlace}"); }
            /////////////////
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var result = numbersA.SelectMany(a => numbersB
            .Where(b => a < b)
            .Select(b => new
            {
                A = a,
                B = b
            }));
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.A} is less than {pair.B}");
            }
            ///////////////////
            var allorders = ListGenerators.CustomerList.SelectMany(x => x.Orders).Where(x => x.Total < 500);
            foreach (var order in allorders) { Console.WriteLine(order); }

            ///////////////
            var allordersdate = ListGenerators.CustomerList.SelectMany(x => x.Orders).Where(x => x.OrderDate >= new DateTime(1998));
            foreach (var order in allordersdate) { Console.WriteLine(order); }

            ////////////////
            var uniqe = ListGenerators.ProductList.Select(p => p.Category)
    .Distinct();
            foreach (var item in uniqe)
            {
                Console.WriteLine(item);
            }
            ////////////////////
            var uniqefirst = ListGenerators.ProductList.Select(x => x.ProductName[0]).Union(
                ListGenerators.CustomerList.Select(x => x.CustomerName[0]));
            foreach (var item in uniqefirst) { Console.WriteLine(item); }
            ////////////////////
            var uniqeintersect = ListGenerators.ProductList.Select(x => x.ProductName[0]).Intersect(
               ListGenerators.CustomerList.Select(x => x.CustomerName[0]));
            foreach (var item in uniqeintersect) { Console.WriteLine(item); }
            //////////////////
            var uniqeexept = ListGenerators.ProductList.Select(x => x.ProductName[0]).Except(
               ListGenerators.CustomerList.Select(x => x.CustomerName[0]));
            foreach (var item in uniqeexept) { Console.WriteLine(item); }
            //////////////////
            var result3 = ListGenerators.CustomerList
    .Select(c => c.CustomerName.Substring(c.CustomerName.Length - 3))
    .Concat(
        ListGenerators.ProductList
            .Select(p => p.ProductName.Substring(p.ProductName.Length - 3))
    );

            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
            /////////////////////////
            var totalunits = ListGenerators.ProductList.GroupBy(x => x.Category).Select(
                x => new
                {
                    category = x.Key,
                    totalunitstock = x.Sum(x => x.UnitsInStock)
                });
            foreach (var item in totalunits)
            {
                Console.WriteLine($"{item.category}: {item.totalunitstock}");
            }
            ///////////////////////
            var totalmin = ListGenerators.ProductList.GroupBy(x => x.Category).Select(
               x => new
               {
                   category = x.Key,
                   minunitstock = x.Min(x => x.UnitsInStock)
               });
            foreach (var item in totalmin)
            {
                Console.WriteLine($"{item.category}: {item.minunitstock}");
            }
            //////////////////////
            var cheapproduct =
    from p in ListGenerators.ProductList
    group p by p.Category into g
    let minPrice = g.Min(p => p.UnitPrice)
    from p in g
    where p.UnitPrice == minPrice
    select new
    {
        Category = g.Key,
        ProductName = p.ProductName,
        Price = p.UnitPrice
    };

            foreach (var item in cheapproduct)
            {
                Console.WriteLine($"{item.Category} - {item.ProductName} - {item.Price}");
            }
            //////////////////////////
            var totalmax = ListGenerators.ProductList.GroupBy(x => x.Category).Select(
              x => new
              {
                  category = x.Key,
                  maxunitstock = x.Max(x => x.UnitsInStock)
              });
            foreach (var item in totalmax)
            {
                Console.WriteLine($"{item.category}: {item.maxunitstock}");
            }
            //////////////////////////
            var mostexpensive = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .SelectMany(g =>
    {
        var maxPrice = g.Max(p => p.UnitPrice);

        return g
            .Where(p => p.UnitPrice == maxPrice)
            .Select(p => new
            {
                Category = g.Key,
                ProductName = p.ProductName,
                Price = p.UnitPrice
            });
    });

            foreach (var item in mostexpensive)
            {
                Console.WriteLine($"{item.Category} - {item.ProductName} - {item.Price}");
            }
            /////////////////////////////////////
            var avregeunit = ListGenerators.ProductList.GroupBy(x => x.Category).Select(
                x => new
                {
                    category = x.Key,
                    avregeunitstock = x.Average(x => x.UnitsInStock)
                });
            foreach (var item in avregeunit)
            {
                Console.WriteLine($"{item.category}: {item.avregeunitstock}");
            }
            /////////////////////////////
            string[] dicts =
{
    "receive",
    "believe",
    "friend",
    "height",
    "science",
    "hello"
};

            bool solver = dicts.Any(w => w.Contains("ei"));

            Console.WriteLine(solver);
            //////////////////////////////////////
            var groupedlist = ListGenerators.ProductList.GroupBy(x => x.Category).Where(x => x.All(x => x.UnitsInStock > 0));
            foreach (var category in groupedlist)
            {
                Console.WriteLine($"Category: {category.Key}");

                foreach (var product in category)
                {
                    Console.WriteLine($"  {product.ProductName} - Stock: {product.UnitsInStock}");
                }
            }
            //////////////////////////
        }
        
    }
}
