using System;
using System.Collections.Generic;
using System.Text;

namespace BuenoPayDomain.Exception
{
    public class NameMustBeFullException : System.Exception
    {
        public NameMustBeFullException() : base("Nome deve ser completo")
        {
            
        }
    }
}
