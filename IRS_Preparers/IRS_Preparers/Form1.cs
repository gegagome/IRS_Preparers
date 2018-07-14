using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRS_Preparers
{
    public partial class IRS_Preparer_Tool : Form
    {
        // results are stored here
        string _finalStr = Environment.NewLine + "START" + Environment.NewLine;

        PreparerCollection _preparers = new PreparerCollection();


        public IRS_Preparer_Tool()
        {
            InitializeComponent();

            // subscribe to load/complete event
            _web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(GrabDataFromTables);

            _web.Navigate(WebObject.URL_ADDRESS);

            // populate combobox
            _comboBox1.Items.Add("By Business");
            _comboBox1.Items.Add("By Name");
            _comboBox1.Items.Add("By Last Name");
            _comboBox1.Items.Add("By Phone Number");
        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {
            string enteredZip = textField.Text;                                 // grab zip code entered

            if (_web.Document != null)
            {
                HtmlElement field_zip_code = _web.Document.GetElementById("edit-zip");    // reference zip code text field
                
                field_zip_code.SetAttribute("value", enteredZip);                         // set page's zip code to entered one
                ApplyButton();
            }
        }

        void GrabDataFromTables (object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection trCollection = _web.Document.GetElementsByTagName("tr");

            if (trCollection != null)
            {
                foreach (HtmlElement tr in trCollection)
                {
                    HtmlElementCollection tdCollection = tr.GetElementsByTagName("td");

                    // format string

                    _finalStr += Environment.NewLine + tdCollection[1].InnerHtml + Environment.NewLine;
                    _preparers.AddPreparer(tdCollection[1].InnerHtml);

                    // finalStr += tr.InnerHtml + "\n";
                }
            }
            else
            {
                Console.WriteLine("Nothing to print");
            }
            IsNextPage();

            //finalStr += Environment.NewLine + "END" + Environment.NewLine;

            //_webPage.StoreWebContent(_finalStr);
            //Console.WriteLine(_collection._collection.Count);
        }

        void ApplyButton ()
        {
            HtmlElement btnApplyZipCode = _web.Document.GetElementById("edit-submit-pup-efile-index-search");

            if (_web.ReadyState == WebBrowserReadyState.Complete)
            {
                btnApplyZipCode.InvokeMember("click");
            } else
            {
                Console.WriteLine("Try again");
            }
        }

        // delete
        void GrabTableRows (string str)
        {
            Console.WriteLine("ddd");
            HtmlElementCollection tableElem = _web.Document.GetElementsByTagName("table");
            if (tableElem != null)
            {
                foreach (HtmlElement tr in tableElem)
                {
                    if (tr.InnerText != null)
                    {
                        Console.WriteLine(tr.InnerText);
                    }
                }
            }
        }

        void IsNextPage ()
        {
            bool shouldContinueToNextPage = false;

            HtmlElement btnNext = null;

            HtmlElementCollection navCollection = _web.Document.GetElementsByTagName("nav");

            if (navCollection != null)
            {
                foreach (HtmlElement nav in navCollection)
                {
                    //HtmlElementCollection li.GetElementsByTagName
                    if (nav.GetAttribute("area-labelledby") != null)
                    {
                        HtmlElementCollection aTagCollection = nav.GetElementsByTagName("a");
                        foreach(HtmlElement a in aTagCollection)
                        {
                            if (a.GetAttribute("title") == "Go to next page")
                            {
                                btnNext = a;
                                shouldContinueToNextPage = true;
                            }
                        }
                    }
                }
            }

            if (btnNext != null)
            {
                btnNext.InvokeMember("click");
            }
            else
            {
                // store raw file
                WebObject.StoreWebContent(_finalStr, "raw.txt");
            }
        }

        // need to delete this but things may break
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        public int SortByNameAscending (string str1, string str2)
        {
            return str1.CompareTo(str2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_comboBox1.SelectedItem.ToString() == "By Business")
            {
                _preparers.SortCollectionByBusinessName(true);
            }
            else if (_comboBox1.SelectedItem.ToString() == "By Name")
            {
                _preparers.SortCollectionByName(true);
            }
            else if (_comboBox1.SelectedItem.ToString() == "By Last Name")
            {
                _preparers.SortCollectionByLastName(true);
            }
            else if (_comboBox1.SelectedItem.ToString() == "By Phone Number")
            {
                _preparers.SortCollectionByPhoneNumber(true);
            }

            string fileName = _comboBox1.SelectedItem.ToString();
            _preparers.ExportPreparers(fileName + ".csv");

            foreach (var item in _preparers._collection)
            {
                Console.WriteLine(Environment.NewLine + "business name is: " + item._businessName);
                Console.WriteLine("name is: " + item._name);
                Console.WriteLine("last name is: " + item._lastName);
                Console.WriteLine("phone number is: " + item._phoneNumber);
            }
        }
    }
}