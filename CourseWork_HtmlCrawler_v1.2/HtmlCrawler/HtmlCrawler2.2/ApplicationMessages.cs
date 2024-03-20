using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawler2._2
{
    public class ApplicationMessages
    {
        public const string ENTER_FILE_PATH_MSG = "Enter the full file path of the HTML document.";
        public const string README = "An application that gets the content of a HTML file.\n" +
                            "You could perform different queries with XTML like prompts";
        public const string COMMAND_EXAMPLE = "To perform a query you should start with PRINT (for output from the selected document)\n" +
                            "You could try out PRINT //html to output the whole document\n" +
                            "if there is a <p> tag in the body with \"Text\" in it you could try\n" +
                            "PRINT //html/body/p - which will output every <p> tag content ";
        public const string RUNNING_APP = "Application started...\nWrite some prompts to see how it's working\n";
        public const string QUIT_APP = "Quitting now...";

        public static string ActionsPerformed(int actions)
        {
            return "You have performed " + actions.ToString() + " actions";
        }
    }
}
