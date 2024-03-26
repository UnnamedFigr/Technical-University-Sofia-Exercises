using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HtmlCrawler2._2
{
    public class ConsoleHandler
    {
        private HTMLParser? _parser;
        private QueryProcessor _queryProcessor;
        private Node? root;

        public ConsoleHandler(string htmlDocPath)
        {
            InitParser(htmlDocPath);
            _queryProcessor = new QueryProcessor();
            root = _parser.GetRootNode();
            _queryProcessor.RootNodeSet(root);
        }

        private void InitParser(string htmlDocPath)
        {
            _parser = new HTMLParser();
            if(!File.Exists(htmlDocPath))
            {
                throw new FileNotFoundException(htmlDocPath.ToString() + " File does not exist!",htmlDocPath);
            }
            string? content = File.ReadAllText(htmlDocPath);
            _parser.ParseHTML(content);
        }
        public void Run()
        {
            Console.WriteLine(ApplicationMessages.COMMAND_EXAMPLE);
            Console.WriteLine(ApplicationMessages.RUNNING_APP);
            int actionsCount = 0;
            while (true)
            {
                string? input = Console.ReadLine();
                actionsCount++;
                Console.WriteLine("Prompt: " + input);

                if(input.ToLower() == "quit")
                {
                    Console.WriteLine(ApplicationMessages.QUIT_APP);
                    Console.WriteLine(ApplicationMessages.ActionsPerformed(actionsCount)); 
                    break;
                }
               
                Console.WriteLine(ApplicationMessages.QUERY_RESULT_MSG);
                _queryProcessor.OutputQuery(input);              
            }
        }
    }
}
