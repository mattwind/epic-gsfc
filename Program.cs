using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace epic
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = "https://epic.gsfc.nasa.gov/api/natural";
            var imgPath = "https://epic.gsfc.nasa.gov/archive/natural";
            var imgType = "png";
            var Yesterday = DateTime.Today.AddDays(-1).ToString(@"yyyy/MM/dd");
            int index = 16;

            using (WebClient c = new WebClient())
            {
                string data = new WebClient().DownloadString(api);
                JArray jsonArray = JArray.Parse(data);
                string filename = jsonArray[index]["image"].ToString();
                string fullPath = string.Format("{0}/{1}/{3}/{2}.{3}", imgPath, Yesterday, filename, imgType);
                c.DownloadFile(fullPath, filename + "." + imgType);
                c.Dispose();
            }

        }

    }
}