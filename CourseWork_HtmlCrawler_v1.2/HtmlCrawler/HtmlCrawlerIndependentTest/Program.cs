namespace HtmlCrawlerIndependentTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\kasap\\Documents\\Repositories\\CourseWork_HtmlCrawler_v1.2\\HtmlCrawler\\HtmlCrawlerIndependentTest\\testweb.html";
            string content = "";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }
            content = File.ReadAllText(path);
            DocParser parser = new DocParser();
            parser.ParseHTML(content);
            Node htmlNode = parser.GetRootNode();
            QueryHandler handler = new QueryHandler(htmlNode);
<<<<<<< HEAD
<<<<<<< HEAD
            handler.HandleQuery("PRINT //");
=======
            handler.HandleQuery("PRINT //html");
>>>>>>> f0a4729 (Added new project)
=======
            handler.HandleQuery("PRINT //html");
>>>>>>> f0a4729 (Added new project)
            //string document = parser.GetFullHtmlContent(htmlNode);
            //Console.WriteLine(document);

        }
    }
}