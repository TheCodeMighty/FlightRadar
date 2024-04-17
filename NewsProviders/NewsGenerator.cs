using OOD_Project1.Entities;

namespace OOD_Project1
{
    public class NewsGenerator
    {
        private List<INewsProviderVisitor> newsProviders;
        private List<IReportable> reportables;

        public NewsGenerator(List<INewsProviderVisitor> newsProviders, List<IReportable> reportables)
        {
            this.newsProviders = newsProviders;
            this.reportables = reportables;
        }

        public IEnumerable<string> GenerateNextNews()
        {
            foreach (var newsProvider in newsProviders)
            {
                foreach (var reportable in reportables)
                {
                    string report = reportable.Accept(newsProvider);
                    yield return report;
                }
            }
        }

        public static void ReportCommand()
        {
            List<INewsProviderVisitor> newsProviders = new List<INewsProviderVisitor>
            {
                new Television { Name = "Abelian Television" },
                new Television { Name = "Channel TV-Tensor" },
                new Radio { Name = "Quantifier Radio" },
                new Radio { Name = "Shmen Radio" },
                new Newspaper { Name = "Categories Journal" },
                new Newspaper { Name = "Polytechnical Gazette" }
            };

            List<IReportable> reportables = PopulateReportables();

            NewsGenerator newsGenerator = new NewsGenerator(newsProviders, reportables);

            foreach (var news in newsGenerator.GenerateNextNews())
            {
                Console.WriteLine(news);
            }
        }

        private static List<IReportable> PopulateReportables()
        {
            var reportables = new List<IReportable>();

            EntityStorage storage = EntityStorage.GetInstance();

            reportables.AddRange(storage.Airports);
            reportables.AddRange(storage.PassengerPlanes);
            reportables.AddRange(storage.CargoPlanes);

            return reportables;
        }

        public static void PrintReports()
        {
            string command;
            while ((command = Console.ReadLine()) != "exit")
            {
                if (command == "report")
                {
                    NewsGenerator.ReportCommand();
                }
            }
        }
    }
}
