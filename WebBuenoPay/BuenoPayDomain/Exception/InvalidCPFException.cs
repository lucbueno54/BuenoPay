using System;
using System.Collections.Generic;
using System.Text;

namespace BuenoPayDomain.Exception
{
    public class InvalidCPFException: System.Exception
    {
        public InvalidCPFException()
            :base("CPF Inválido")
        {

        }
    }
}
