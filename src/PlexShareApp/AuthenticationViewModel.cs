using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthViewModel;

public class AuthenticationViewModel
{

    public AuthenticationViewModel()
    {
    }

    public bool AuthenticateUser(string smail)
    {
        int i = 0;
        for (i = 0; i < smail.Length; i++)
        {
            if (smail[i] == '@')
                break;
        }

        if (i == smail.Length || i == 0)
            return false;

        if (smail.Substring(i + 1) != "smail.iitpkd.ac.in")
            return false;

        else
            return true;
    }

}
