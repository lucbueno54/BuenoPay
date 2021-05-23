using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BuenoPayDomain.Exception;

namespace BuenoPayDomain.structs
{
    struct Name
    {
        readonly string FirstName;
        readonly string LastName;
        readonly string MiddleName;
        public Name(string FullName)
        {
            FirstName = null;
            MiddleName = string.Empty;
            LastName = null;

            var partsfTheName = splitName(FullName);
            LastName = partsfTheName.FirstOrDefault();
            LastName = partsfTheName.LastOrDefault();
            MiddleName = ExtractMiddleName(partsfTheName);

        }
        private List<string> splitName(string FullName)
        {
            var partsfTheName = FullName.Trim().Split(" ").ToList();
            if (partsfTheName.Count < 2)
            {
                throw new NameMustBeFullException();
            }
            return partsfTheName;
        }
        private void ValidateFullName(string FullName)
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                throw new NameCannotBeEmptyOrNullException();
            }
        }

        private string ExtractMiddleName(List<string> partsfTheName)
        {
            partsfTheName.RemoveAt(0);
            partsfTheName.Reverse();
            partsfTheName.RemoveAt(0);
            partsfTheName.Reverse();
            return partsfTheName.Count > 0 ? string.Join(' ', partsfTheName) : string.Empty;
        }

    }
}
