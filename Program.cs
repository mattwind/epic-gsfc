using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace epic
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = "https://epic.gsfc.nasa.gov/api/natural";
            //var api = "https://epic.gsfc.nasa.gov/api/natural/date"; // Historical data
            var imgPath = "https://epic.gsfc.nasa.gov/archive/natural";
            var imgType = "png";
            var sDate = DateTime.Now.ToString(@"yyyy-MM-dd");
            var DatePath = DateTime.Today.AddDays(-1).ToString(@"yyyy/MM/dd");
            int index = 16;

            string url = string.Format("{0}/", api);

            using (WebClient c = new WebClient())
            {
                string data = new WebClient().DownloadString(url);                

                JArray jsonArray = JArray.Parse(data);

                string filename = jsonArray[index]["image"].ToString();
                string fullPath = string.Format("{0}/{1}/{3}/{2}.{3}", imgPath, DatePath, filename, imgType);

                Console.WriteLine(url); // api url
                Console.WriteLine(filename);
                Console.WriteLine(fullPath); // link to image

                c.DownloadFile(fullPath, filename+"."+imgType); // Download image
                c.Dispose();
            }

        }

    }
}