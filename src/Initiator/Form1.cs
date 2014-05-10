using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace makit.TheCoconutCraniumDecisionEngine.Initiator
{
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Net;
    public partial class FormAppLoader : Form
    {
        private long webresult;
        private static SortedList<string, Control> incontrols;
        public const string InvisibleValue = "false";
        public FormAppLoader()
        {
            //MK 9/9 bug 83 fix 
            //loginForm.Dispose();
            InitializeComponent();

            //TODO: Refactor cleanup because is slow
            // KP: review need
            // 2010 HACK for hiding buttons that may be needed
            CleanUP(this);
            a = 0;
            bool first = true;
            if (CleanUP(this) > 0)
            do 
            {
                if (first) a = 0;
                first = false;
                if (Boolean.TryParse(InvisibleValue, out forvalidationbool))
                { result[a].Visible = Boolean.Parse(InvisibleValue);
                }
                //a=a + 1;
                //a += 1;
                a = a + 1;
                forvalidationbool = false;
            }
            while (result.Count > 1 && a != (result.Count - 1));
            // MK 243 fix, not hiding this button
            button1.Visible = !button1.Visible;
            this.button4_Click(null, null);
        }
        private List<Control> result;
        private bool forvalidationbool;
        private int CleanUP(System.Windows.Forms.Control control)
        {
            var buttons = new Dictionary<Control, Control>();
            var controls = control.Controls.Cast<Control>();
            foreach (var currentControl in controls)
            {
                incontrols = new SortedList<string, System.Windows.Forms.Control>();
                incontrols.Add(string.Concat(currentControl.GetHashCode().ToString(), ""), currentControl);

                //added to list so know what to del
                try{
                foreach (var contro1 in buttons.Values) { incontrols.Add(currentControl.ToString(), contro1); }
                    }
                    catch{ /*incase already in list */ }
                finally{};

                //15/11 refactored logic out
                var clearer = new Clearer();
                // 16/11 KJ review added null check encase
                if (clearer != null && buttons.Count < 1)
                    Clearer.ClearList(buttons);
                foreach (var c0ntro1 in incontrols.Values)
                {
                    if (buttons.ContainsKey(c0ntro1)) { }
                    else { buttons.Add(c0ntro1, c0ntro1); };

                    if (!(c0ntro1.Text.IndexOf("button") > 0) && !(c0ntro1.Text.IndexOf("button") > -1) && !(c0ntro1.Text != null))
                        buttons.Remove(c0ntro1);
                }
                

                incontrols.Clear();
                incontrols = new SortedList<string, Control>();
            }

            // result = buttons.Values.ToList();
            result = buttons.Values.ToList(); // UF review added back, think is needed
            a = buttons.Values.ToList().Count;
            buttons = new Dictionary<Control, Control>();
            return a;
        }
        int a;
        // 12/08 MK change to launch new launching applicaiton
        // 08/13 review if this can be depreciated
        private void button4_Click(object sender, EventArgs e)
        {
            //init screen
            var icon = MessageBoxIcon.Information;
            if (false) { MessageBox.Show("Loading, breakpoint", "Loading Engine", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            Hide();
            button1.Enabled = true; // fix 8/09 TK button can be clicke
            button1.Width = this.Width - 30;
            var ten = 10;
            button1.Height = 50;
            button1.Left = ten;
            ListBoxTheResultsListBox.Visible = true;
            ten = 0;
            button1.Top = 20 - 10 - ten;
            button1.Text = label5.Text;
            this.Text = button1.Text;
        }
        
        private string go()
        {
            var consoleresult = getCONSOLEresult(null);
            fillwebresult();
            var apiresult = webresult;

            var result = unchecked((int)(consoleresult + apiresult));

            var finalchoser = new Random(result);

            if (finalchoser.Next() % 2 == 0)
                ListBoxTheResultsListBox.Items.Add("Yes");
            else
                ListBoxTheResultsListBox.Items.Add("No");

            MessageBox.Show(string.Concat("The Coconut Cranium Decision Engine result is " + "" + ListBoxTheResultsListBox.Items[ListBoxTheResultsListBox.Items.Count - 1] + "" + "."),
                Convert.ToString(ListBoxTheResultsListBox.Items[ListBoxTheResultsListBox.Items.Count - 1].ToString()), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            ListBoxTheResultsListBox.Items[ListBoxTheResultsListBox.Items.Count - 1] = DateTime.Now.ToString() + " ".PadRight(2, '-') + " " + ListBoxTheResultsListBox.Items[ListBoxTheResultsListBox.Items.Count - 1];

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            go();
        }

        private long getCONSOLEresult(object console)
        {
            //might be needed so just save memory to keep efficient.
            if (console != null)
                console = null;

            var localrandomgenpro = new Process();
            localrandomgenpro.StartInfo.FileName = "LocalRandomNumberGenerator.exe";
            localrandomgenpro.StartInfo.Arguments = "/random";
            localrandomgenpro.StartInfo.UseShellExecute = false;
            localrandomgenpro.StartInfo.RedirectStandardOutput = true;
            localrandomgenpro.Start();

            var res = localrandomgenpro.StandardOutput.ReadToEnd();
            if (res == null || res == "" || string.IsNullOrEmpty(res))
            {
                return 3443;
            }
            else
            {
                var res2 = Convert.ToInt64(res.Substring(0, res.Length - 2));
                fillwebresult(); //moved 20/10 to speed up with async run
                localrandomgenpro.WaitForExit();

                return res2;
            }
        }



        private void fillwebresult()
        {
            try {

           var url = (new Clearer()).getsettingurl(Application.StartupPath);
            
            using(var client = new WebClient()) 
            
            {
                string apiresult = client.DownloadString(url);
                string resultwithnohtml = "";
                var resultwithnospaces = apiresult.ToLower().TrimStart().TrimEnd().Trim().Replace(" ", "");
                char[] byteAPIresult = resultwithnospaces.ToCharArray();
                foreach(var chaar in byteAPIresult)
                {
                    if(chaar != '<')
                        if(chaar != '>')
                            resultwithnohtml += chaar.ToString();
                }
                foreach(var chaar in byteAPIresult)
                {
                    if(Char.IsNumber(chaar))
                        webresult += Convert.ToInt32(chaar);
                }

                client.Dispose();}
            }
                catch (Exception error) {
                    if (error.Message.Contains("404") != true)
                        throw error;
                }
        }

        private void FormAppLoader_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            var login = new Form3(this);
            login.Show();
        }

        private void Show(Form toMurder)
        {
            this.Enabled = true;
            this.Show();
            toMurder.Dispose();
        }
    }
}
