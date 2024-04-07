namespace HtmlCrawlerIndependentTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = "C:\\Users\\kasap\\Documents\\Repositories\\CourseWork_HtmlCrawler_v1.2\\HtmlCrawler\\HtmlCrawlerIndependentTest\\testweb.html";
            //string content = "";
            //if (!File.Exists(path))
            //{
            //    throw new FileNotFoundException("File not found");
            //}
            //content = File.ReadAllText(path);
            //DocParser parser = new DocParser();
            //parser.ParseHTML(content);
            //Node htmlNode = parser.GetRootNode();
            //QueryHandler handler = new QueryHandler(htmlNode);
            //handler.HandleQuery("PRINT //html");

            HtmlDocument document = new HtmlDocument();
            document.Text = @"<p>This is a paragraph tag.</p>";
            HtmlNode s = new HtmlNode(HtmlNodeType.Text, document, 2);
            string text = "This is a test text";
            s.OwnerDocument = document;
            s.SetName("p");
            Console.WriteLine(s.Name);

            //string document = parser.GetFullHtmlContent(htmlNode);
            //Console.WriteLine(document);

        }
    }
}