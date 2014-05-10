using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace makit.TheCoconutCraniumDecisionEngine.Initiator
{
    class LoginButler
    {
        string isvalid;

        public LoginButler(string username, string password, string combiCode)
        {
            isvalid = "false";

            // Normalise
            username = username.ToUpper();
            password = password.ToUpper();
            combiCode = combiCode.ToUpper();

            var pChars = username.ToCharArray();
            Array.Reverse(pChars);
            username = new string(pChars);

            if (password.IndexOf(username) > 0)
            {
                if (password.Contains("1"))
                {
                    if (password.Contains("5") || (password.Contains("8")))
                    {
                        if (!password.Contains(" "))
                        {
                            password = password.Replace("J", "L");

                            if(password.StartsWith("L"))
                            {
                                isvalid = 1.ToString();
                            }
                        }
                    }
                }
            }
        }

        public bool IsValid()
        {
            return isvalid == "1";
        }
    }
}
