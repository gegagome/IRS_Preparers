using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IRS_Preparers
{
    class WebObject
    {
        public const string URL_ADDRESS = "http://www.irs.gov/uac/Authorized-IRS-e-file-Providers-for-Individuals";
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void StoreWebContent (string str, string fileName)
        {
            if (str != null)
            {
                if (!File.Exists(PATH))
                {
                    File.WriteAllText(PATH + "\\" + fileName, str);
                }

                //FileStream fileStream = File.Create(PATH + "\\str.txt");
                //str.CopyTo(fileStream);
                //BinaryFormatter bf = new BinaryFormatter();
                //fileToSave = new FileStream(PATH + "\\str.txt", FileMode.Open, FileAccess.ReadWrite);

                //bf.Serialize(f, str);
                //f.Close();
            }
        }

        internal static void StoreWebContent(StringBuilder csv, string v)
        {
            if (csv != null)
            {
                if (!File.Exists(PATH))
                {
                    File.WriteAllText(PATH + "\\" + v, csv.ToString());
                }
            }
        }
    }
}