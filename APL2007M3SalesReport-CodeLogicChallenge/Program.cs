namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
            // create a new instance of the class
            QuarterlyIncomeReport report = new QuarterlyIncomeReport();

            // call the GenerateSalesData method
            SalesData[] salesData = report.GenerateSalesData();


            // call the QuarterlySalesReport method
            report.QuarterlySalesReport(salesData);

        }

        /* public struct SalesData includes the following fields: date sold, department name, product ID, quantity sold, unit price */
        public struct SalesData
        {
            public DateOnly dateSold;
            public string departmentName;
            public string productID;
            public int quantitySold;
            public double unitPrice;
            public double baseCost;
            public int volumeDiscount;
        }

        public struct ProdDepartments
        {
            public static string[] departmentNames = { "Men's Clothing", "Women's Clothing", "Children's Clothing", "Accessories", "Footwear", "Outerwear", "Sportswear", "Undergarments" };
            public static string[] departmentAbbreviations = { "MENS", "WOMN", "CHLD", "ACCS", "FOOT", "OUTR", "SPRT", "UNDR" };
        }

        public struct ManufacturingSites
        {
            public static string[] manufacturingSites = { "US1", "US2", "US3", "UK1", "UK2", "UK3", "JP1", "JP2", "JP3", "CA1" };
        }

        /* the GenerateSalesData method returns 1000 SalesData records. It assigns random values to each field of the data structure */
        public SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                salesData[i].dateSold = new DateOnly(2023, random.Next(1, 13), random.Next(1, 29));
                salesData[i].departmentName = ProdDepartments.departmentNames[random.Next(0, ProdDepartments.departmentNames.Length)];

                int indexOfDept = Array.IndexOf(ProdDepartments.departmentNames, salesData[i].departmentName);
                string deptAbb = ProdDepartments.departmentAbbreviations[indexOfDept];
                string firstDigit = (indexOfDept + 1).ToString();
                string nextTwoDigits = random.Next(1, 100).ToString("D2");
                string sizeCode = new string[] { "XS", "S", "M", "L", "XL" }[random.Next(0, 5)];
                string colorCode = new string[] { "BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY" }[random.Next(0, 8)];
                string manufacturingSite = ManufacturingSites.manufacturingSites[random.Next(0, ManufacturingSites.manufacturingSites.Length)];

                salesData[i].productID = $"{deptAbb}-{firstDigit}{nextTwoDigits}-{sizeCode}-{colorCode}-{manufacturingSite}";
                salesData[i].quantitySold = random.Next(1, 101);
                salesData[i].unitPrice = random.Next(25, 300) + random.NextDouble();
                salesData[i].baseCost = salesData[i].unitPrice * (1 - (random.Next(5, 21) / 100.0));
                salesData[i].volumeDiscount = (int)(salesData[i].quantitySold * 0.1);

            }

            return salesData;
        }

        public void QuarterlySalesReport(SalesData[] salesData)
        {
            // create a dictionary to store the quarterly sales data
            Dictionary<string, Dictionary<string, (int unitsSold, double totalSales, double avgUnitCost, double totalProfit, double avgProfitPercentage)>> quarterlyProductSales = new Dictionary<string, Dictionary<string, (int, double, double, double, double)>>();

            // iterate through the sales data
            foreach (SalesData data in salesData)
            {
            // calculate the total sales for each quarter
            string quarter = GetQuarter(data.dateSold.Month);
            double totalSales = data.quantitySold * data.unitPrice;
            double totalCost = data.quantitySold * data.baseCost;
            double profit = totalSales - totalCost;
            double profitPercentage = (profit / totalSales) * 100;

            // deconstruct the product ID to get the serial number
            string[,] productDetails = DeconstructProductId(data.productID);
            string productSerialNumber = $"{productDetails[0, 1]}-{productDetails[1, 1]}-ss-cc-mmm";

            // initialize the dictionary for the quarter if it doesn't exist
            if (!quarterlyProductSales.ContainsKey(quarter))
            {
                quarterlyProductSales[quarter] = new Dictionary<string, (int, double, double, double, double)>();
            }

            // update the product sales data
            if (quarterlyProductSales[quarter].ContainsKey(productSerialNumber))
            {
                var currentData = quarterlyProductSales[quarter][productSerialNumber];
                int newUnitsSold = currentData.unitsSold + data.quantitySold;
                double newTotalSales = currentData.totalSales + totalSales;
                double newTotalProfit = currentData.totalProfit + profit;
                double newAvgUnitCost = (currentData.avgUnitCost * currentData.unitsSold + data.unitPrice * data.quantitySold) / newUnitsSold;
                double newAvgProfitPercentage = (currentData.avgProfitPercentage * currentData.unitsSold + profitPercentage * data.quantitySold) / newUnitsSold;

                quarterlyProductSales[quarter][productSerialNumber] = (newUnitsSold, newTotalSales, newAvgUnitCost, newTotalProfit, newAvgProfitPercentage);
            }
            else
            {
                quarterlyProductSales[quarter][productSerialNumber] = (data.quantitySold, totalSales, data.unitPrice, profit, profitPercentage);
            }
            }

            // display the quarterly sales report
            Console.WriteLine("Quarterly Sales Report");
            Console.WriteLine("----------------------");

            // sort the quarterly sales by key (quarter)
            var sortedQuarterlySales = quarterlyProductSales.OrderBy(q => q.Key);

            foreach (var quarter in sortedQuarterlySales)
            {
            Console.WriteLine($"{quarter.Key}:");

            // sort the product sales data by total profit in descending order
            var sortedProductSales = quarter.Value.OrderByDescending(p => p.Value.totalProfit).Take(3);

            // Print table headers
            Console.WriteLine("┌───────────────────────┬───────────────────┬───────────────────┬───────────────────┬───────────────────┬───────────────────┐");
            Console.WriteLine("│  Product Serial No.   │   Units Sold      │   Total Sales     │ Avg. Unit Cost    │   Total Profit    │ Avg. Profit %     │");
            Console.WriteLine("├───────────────────────┼───────────────────┼───────────────────┼───────────────────┼───────────────────┼───────────────────┤");

            foreach (var product in sortedProductSales)
            {
                Console.WriteLine("│ {0,-22}│ {1,17} │ {2,17} │ {3,17} │ {4,17} │ {5,17} │", product.Key, product.Value.unitsSold, product.Value.totalSales.ToString("C"), product.Value.avgUnitCost.ToString("C"), product.Value.totalProfit.ToString("C"), product.Value.avgProfitPercentage.ToString("F2"));
            }

            Console.WriteLine("└───────────────────────┴───────────────────┴───────────────────┴───────────────────┴───────────────────┴───────────────────┘");
            Console.WriteLine();
            }
        }

        public string GetQuarter(int month)
        {
            if (month >= 1 && month <= 3)
            {
                return "Q1";
            }
            else if (month >= 4 && month <= 6)
            {
                return "Q2";
            }
            else if (month >= 7 && month <= 9)
            {
                return "Q3";
            }
            else
            {
                return "Q4";
            }
        }

        public static string[,] DeconstructProductId(string productId)
    {
        // Divide o ID do produto em componentes usando o caractere '-' como delimitador
        string[] components = productId.Split('-');
    
        // Verifica se o ID do produto possui exatamente 5 componentes
        if (components.Length != 5)
        {
            throw new ArgumentException("O ID do produto deve conter exatamente 5 componentes separados por '-'.");
        }
    
        // Cria uma matriz bidimensional para armazenar a descrição e o valor de cada componente
        string[,] productDetails = new string[5, 2]
        {
            { "Department Abbreviation", components[0] },
            { "Product Serial Number", components[1] },
            { "Size Code", components[2] },
            { "Color Code", components[3] },
            { "Manufacturing Site", components[4] }
        };
    
        return productDetails;
    }

    }
}
