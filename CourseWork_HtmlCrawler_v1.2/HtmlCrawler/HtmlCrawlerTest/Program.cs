using HtmlCrawler2._2;

namespace HtmlCrawlerTest
{

    public class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\kasap\\Documents\\Repositories\\CourseWork_HtmlCrawler_v1.2\\HtmlCrawler\\HtmlCrawlerTest\\testweb.html";
            string content = "";
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }
            content = File.ReadAllText(path);
            DocParser parser = new DocParser(content);
            parser.ParseHtmlFile();
            Console.WriteLine("hey");
        }
    }
}