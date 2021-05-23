using System;
using System.Collections.Generic;
using System.Text;

namespace BuenoPayDomain.Exception
{    
    public class NameCannotBeEmptyOrNullException: System.Exception
    {
        public NameCannotBeEmptyOrNullException()
        :base("Nome não pode ser vazio ou null.")
        {
            
        }
    }
}
