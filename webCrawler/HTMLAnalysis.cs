using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webCrawler
{
    public class HTMLAnalysis
    {
        private readonly HtmlDocument document = new HtmlDocument();

        public HTMLAnalysis(string html)
        {
            document.LoadHtml(html);
        }

        public HtmlDocument htmlDocument { get { return document; } }

        public void ExtractPageTitle()
        {

            var titleNode = document.DocumentNode.SelectSingleNode("//head/title");
            if (titleNode != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("==============================================");
                Console.WriteLine();
                Console.WriteLine($"Page Title: {titleNode.InnerText}");
                Console.WriteLine();
                Console.WriteLine("==============================================");
                Console.ResetColor();
            }

        }


        public void ExtractAllLinks()
        {

            var linkNodes = document.DocumentNode.SelectNodes("//a[@href]");
            if (linkNodes != null)
            {
                foreach (var linkNode in linkNodes)
                {
                    string href = linkNode.GetAttributeValue("href", string.Empty);
                    string text = linkNode.InnerText;
                    Console.WriteLine();
                    Console.WriteLine($"Link Text: {text}, URL: {href}");
                    Console.WriteLine();

                }
            }

        }


    }
}
