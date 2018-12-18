using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IRS_Preparers
{
    class Preparer : IEquatable<Preparer>, IComparable<Preparer>
    {
        Regex _regex = new Regex(@"");

        public string _businessName, _address, _location, _name, _lastName, _phoneNumber, _title;
        public int _preparerOrder;
        static int _count;

        public Preparer (string preparer)
        {
            string[] lines = Regex.Split(preparer, "\r\n|\r|\n");

            _businessName = FormatString(lines[0]);
            _address = FormatString(lines[1]);
            _location = FormatString(lines[2]);
            _name = FormatName(lines[3]);
            _lastName = FormatLastName(lines[3]);
            _phoneNumber = FormatPhoneNumber(lines[4]);
            _title = FormatString(lines[5]);

            _count++;

            _preparerOrder = _count;

            //if (_count == 2)
            //{
            //    Console.WriteLine("business name is: " + _businessName);
            //    Console.WriteLine("address is: " + _address);
            //    Console.WriteLine("location is: " + _location);
            //    Console.WriteLine("name is: " + _name);
            //    Console.WriteLine("last name is: " + _lastName);
            //    Console.WriteLine("phone number is: " + _phoneNumber);
            //    Console.WriteLine("title is: " + _title);
            //}
        }

        // required by IEquatable
        public bool Equals(Preparer other)
        {
            if (other == null) return false;
            return (this._preparerOrder.Equals(other._preparerOrder));
        }

        // required by IComparable
        public int CompareTo(Preparer comparePreparer)
        {
            // A null value means that this object is greater.
            if (comparePreparer == null)
                return 1;

            else
                return this._preparerOrder.CompareTo(comparePreparer._preparerOrder);
        }

        string FormatString (string str)
        {
            while (str.EndsWith("<br>"))
            {
                str = str.Substring(0, str.Length - 4);
            }

            if (str.Contains("<br>"))
            {
                int pos = str.IndexOf('<');
                str = str.Remove(pos, 4);
                str = str.Insert(pos, " ");
            }

            if (str.Contains("&"))
            {
                int pos = str.IndexOf('&');
                str = str.Remove(pos + 1, 4);
            }

            if (str.Contains(","))
            {
                str = str.Replace(',', ' ');
            }



            return str;
        }

        string FormatForCommas(string str)
        {
            str = FormatString(str);

            if (str.Contains(","))
            {
                str = str.Replace(',', ' ');
            }

            return str;
        }

        string FormatPhoneNumber (string str)
        {
            str = FormatString(str);

            while (str.StartsWith("<a>("))
            {
                str = str.Substring(4);
            }

            while (str.EndsWith("</a>"))
            {
                str = str.Substring(0, str.Length - 4);
            }

            str = str.Insert(str.Length - 4, "-");
            str = str.Insert(3, "-");

            return str;
        }

        string FormatName(string str)
        {
            str = FormatString(str);

            int i = str.IndexOf(" ");
            str = str.Substring(0, i);

            return str;
        }

        string FormatLastName (string str)
        {
            str = FormatString(str);

            int i = str.IndexOf(" ");
            str = str.Substring(i + 1, str.Length - i - 1);

            return str;
        }
    }
}
