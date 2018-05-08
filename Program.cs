using System;
using HtmlAgilityPack;

namespace epic
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = @"https://epic.gsfc.nasa.gov/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var xpath = "//*[@id='info']/div[16]/span[1]/a";
            var node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
            Console.WriteLine(node.Attributes["href"].Value);
        }
    }
}