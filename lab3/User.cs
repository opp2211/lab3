using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public bool access { get; set; } = true;
        public bool passNum { get; set; } = false;
        public bool passUpper { get; set; } = false;
        public bool passLower { get; set; } = false;
        public bool passSymb { get; set; } = false;
        public int passMinLength { get; set; } = 0;
    }
}
