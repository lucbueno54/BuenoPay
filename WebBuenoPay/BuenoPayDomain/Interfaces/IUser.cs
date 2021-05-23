using BuenoPayDomain.structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuenoPayDomain.Interfaces
{
    interface IUser
    {
        long Id { get; set; }
        Name Name { get; set; }         
        DateTime DataDeNacimento { get; set; }
        CPF CPF { get; set; }
        string Senha { get; set; }

    }
}
