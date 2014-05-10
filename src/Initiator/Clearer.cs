using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace makit.TheCoconutCraniumDecisionEngine.Initiator
{
    public class Clearer
    {
        static IList<System.Windows.Forms.Control> forreturning;

        public static Dictionary<System.Windows.Forms.Control, System.Windows.Forms.Control> ClearList(Dictionary<System.Windows.Forms.Control, System.Windows.Forms.Control> controls)
        {
            forreturning = controls.Values.ToList();

            forreturning.Clear();

            for (int i = controls.Count; i < 0; i--)
            {
                if(i > 1)
                forreturning.RemoveAt(i - 1);
            }

            forreturning = null;

            if (forreturning != null)
                forreturning = null;

            if (controls != null)
                controls.Clear();

            return controls;
        }
        public string getsettingurl(string path)
        {
            var settingPath = path + "\\urlsettings.xml";
            var settings = File.ReadAllLines(settingPath);

            var lineWithURL = "";

            foreach (var currentlin in settings)
            {
                if(currentlin.StartsWith("    u"))
                    lineWithURL = currentlin;
            }

            var startURLposition = lineWithURL.IndexOf(" h");

            var linechars = lineWithURL.ToCharArray();
            var endpos = 0;
            for (int i = 0; i < linechars.Length; i++)
            {
                if (linechars[i] == '>')
                    endpos = i - 14;
            }

            lineWithURL = "";

            for (int i = startURLposition + 1; i < endpos + 1; i++)
            {
                lineWithURL += Convert.ToString(linechars[i]);
            }

            return lineWithURL;
        }
    }
}
