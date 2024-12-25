using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager
{
    class Cont
    {
        public static List<Cont> Conturi = new List<Cont>();
        public string email;
        public string parola;
        public string site;
        public string notite;

        public Cont(string _email, string _parola, string _site, string _notite)
        {
            email = _email;
            parola = _parola;
            site = _site;
            notite = _notite;
        }
    }
}
