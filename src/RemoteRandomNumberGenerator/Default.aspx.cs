using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;

namespace makit.TheCoconutCraniumDecisionEngine.RemoteRandomNumberGenerator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long randomNumber = DateTime.Now.TimeOfDay.Ticks;

            var userIP = Request.ServerVariables["REMOTE_ADDR"];
            userIP = userIP.Replace(".", "");
            userIP = userIP.Replace(":", "");

            randomNumber -= Convert.ToInt64(userIP);
            randomNumber -= GetStringAsNumber(Request.ServerVariables["LOGON_USER"]);
            randomNumber -= GetStringAsNumber(Request.ServerVariables["HTTP_ACCEPT"]);
            randomNumber -= GetStringAsNumber(Request.ServerVariables["ALL_RAW"]);
            randomNumber -= GetStringAsNumber(Request.ServerVariables["SERVER_SOFTWARE"]);
            randomNumber -= GetRandomNumberFromGoogle();

            if (randomNumber < 0)
                randomNumber = -randomNumber;

            var outputNumber = new StringBuilder();
            outputNumber.Append(randomNumber.ToString());

            if (outputNumber.Length > 0 && outputNumber != null)
            {
                OutputLabel.Text = "[{0}]";
                OutputLabel.Text = OutputLabel.Text.Replace("{0}", outputNumber.ToString());
            }
        }

        private long GetStringAsNumber(string toConvert)
        {
            if (toConvert == null)
                return 0;

            long numberResult = 0;

            if (toConvert.Length > 0)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[0]);

            if (toConvert.Length > 1)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[1]);

            if (toConvert.Length > 2)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[2]);

            if (toConvert.Length > 3)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[3]);

            if (toConvert.Length > 4)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[4]);

            if (toConvert.Length > 5)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[5]);

            if (toConvert.Length > 6)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[6]);

            if (toConvert.Length > 7)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[7]);

            if (toConvert.Length > 8)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[8]);

            if (toConvert.Length > 9)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[9]);

            if (toConvert.Length > 10)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[10]);

            if (toConvert.Length > 11)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[11]);

            if (toConvert.Length > 13)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[13]);

            if (toConvert.Length > 14)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[14]);

            if (toConvert.Length > 15)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[15]);

            if (toConvert.Length > 16)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[16]);

            if (toConvert.Length > 17)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[17]);

            if (toConvert.Length > 18)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[18]);

            if (toConvert.Length > 19)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[19]);

            if (toConvert.Length > 20)
                numberResult += Convert.ToInt64(toConvert.ToCharArray()[20]);

            return numberResult;
        }

        private long GetRandomNumberFromGoogle()
        {
            long number = 0;

            var before = DateTime.Now.Ticks;

            // Cached performance
            if (Cache["google"] != null && Int64.TryParse(Cache["google"].ToString(), out number))
            {

            }
            else
            {

            try
            {

            using (var client = new WebClient())
            {

                var googleResponse = client.DownloadString("https://ajax.googleapis.com/ajax/services/search/web?q=donkeys&rsz=1&start=12&v=1.0");

                number += googleResponse.Length;

                var urlScrapeRegex = new Regex("unescapedUrl\\\":\\\"(.+?)\"");
                var url = urlScrapeRegex.Match(googleResponse);

                number += GetStringAsNumber(url.Groups[1].Value);

                Response.Write(url.Groups[1].Value);

                Cache.Insert("google", number, null, DateTime.UtcNow.AddMinutes(10), TimeSpan.Zero);
            }
            }
            catch { }
                }

            var after = DateTime.Now.Ticks;
            number += (after - before);

            return number;
        }
    }
}