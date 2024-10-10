namespace HtmlCrawler2._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string htmlDoc = "/Users/ivan/Desktop/tusofiarepo/Technical-University-Sofia-Exercises/Second_year/Coursework_HtmlCrawler/HtmlCrawler/HtmlCrawler2.2/testweb.html";
            ConsoleHandler handler = new ConsoleHandler(htmlDoc);
            handler.Run();
        }
    }
}