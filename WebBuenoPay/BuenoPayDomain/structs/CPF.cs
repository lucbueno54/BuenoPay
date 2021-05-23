using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BuenoPayDomain.Exception;

namespace BuenoPayDomain.structs
{
    public struct CPF
    {
        int[] CPFItens;
        public CPF(string cpf)
        {
            CPFItens = new int[11];
            if (CPFUtil.ValidateCPF(cpf, CPFItens))
            {
                throw new InvalidCPFException();
            }
        }

        public string Format()
            =>Convert.ToUInt64(string.Join(string.Empty, CPFItens)).ToString(@"000\.000\.000\-00");        
    }

    internal static class CPFUtil
    { 
        public static bool ValidateCPF(string cpf, int[] CPFItens)
        {
            if (String.IsNullOrWhiteSpace(cpf))
                return false;

            string CPFclear;
            int totalDigitoI = 0;
            int totalDigitoII = 0;
            int modI;
            int modII;
            int[] cpfArray = new int[11];

            CPFclear = cpf.Trim().Replace("-", "").Replace(".", "");

            if (CPFclear.Length != 11 || 
                CPFclear.Distinct().Count() == 1 ||
                CPFclear.Any(x => !char.IsNumber(x)))
            {
                return false;
            }

            for (int posicao = 0; posicao < CPFclear.Length; posicao++)
            {
                cpfArray[posicao] = int.Parse(CPFclear[posicao].ToString());
                if (posicao < cpfArray.Length - 2)
                {
                    totalDigitoI += cpfArray[posicao] * (10 - posicao);
                    totalDigitoII += cpfArray[posicao] * (11 - posicao);
                }
            }

            modI = totalDigitoI % 11;
            if (modI < 2)
            {
                modI = 0;
            }
            else
            {
                modI = 11 - modI;
            }

            if (cpfArray[9] != modI)
            {
                return false;
            }

            totalDigitoII += modI * 2;

            modII = totalDigitoII % 11;
            if (modII < 2)
            {
                modII = 0;
            }
            else
            {
                modII = 11 - modII;
            }
            if (cpfArray[10] != modII)
            {
                return false;
            }
            CPFItens = cpfArray;

            return true;
        }
    }
}
