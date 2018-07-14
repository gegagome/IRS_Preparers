using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRS_Preparers
{
    class PreparerCollection
    {
        public List<Preparer> _collection = new List<Preparer>();

        public void AddPreparer (string paragraph)
        {
            Preparer preparer = new Preparer(paragraph);
            _collection.Add(preparer);
        }

        public void SortCollectionByBusinessName(bool isAsc)
        {
            _collection.Sort(delegate (Preparer x, Preparer y) {
                if (x._businessName == null && y._businessName == null) return 0;
                else if (x._businessName == null) return -1;
                else if (y._businessName == null) return 1;
                else return x._businessName.CompareTo(y._businessName);
            });
        }

        public void SortCollectionByName (bool isAsc)
        {
            _collection.Sort(delegate (Preparer x, Preparer y) {
                if (x._name == null && y._name == null) return 0;
                else if (x._name == null) return -1;
                else if (y._name == null) return 1;
                else return x._name.CompareTo(y._name);
            });
        }

        public void SortCollectionByLastName(bool isAsc)
        {
            _collection.Sort(delegate (Preparer x, Preparer y) {
                if (x._lastName == null && y._lastName == null) return 0;
                else if (x._lastName == null) return -1;
                else if (y._lastName == null) return 1;
                else return x._lastName.CompareTo(y._lastName);
            });
        }

        public void SortCollectionByPhoneNumber(bool isAsc)
        {
            _collection.Sort(delegate (Preparer x, Preparer y) {
                if (x._phoneNumber == null && y._phoneNumber == null) return 0;
                else if (x._phoneNumber == null) return -1;
                else if (y._phoneNumber == null) return 1;
                else return x._phoneNumber.CompareTo(y._phoneNumber);
            });
        }

        public void ExportPreparers (string nameOfFile)
        {
            StringBuilder csv = new StringBuilder();

            string newLine = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                "Name of Business",
                "Address",
                "City State Zip",
                "First Name",
                "Last Name",
                "Telephone",
                "Type of Service"
                );

            csv.AppendLine(newLine);

            foreach (Preparer preparer in _collection)
            {
                newLine = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                preparer._businessName,
                preparer._address,
                preparer._location,
                preparer._name,
                preparer._lastName,
                preparer._phoneNumber,
                preparer._title
                );

                csv.AppendLine(newLine);
            }

            WebObject.StoreWebContent(csv, nameOfFile);
            //File.WriteAllText(WebObject.PATH, csv.ToString());
        }
    }
}
