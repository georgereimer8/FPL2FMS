using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FPL2FMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XDocument fpl;
        private void button_load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    fpl = XDocument.Load(openFileDialog1.FileName, LoadOptions.PreserveWhitespace);
                    textBox_fpl.Text = fpl.Root.ToString();
                    textBox_load.Text = openFileDialog1.FileName;
                    convert();
                    textBox_save.Text = Path.ChangeExtension(openFileDialog1.FileName, "fms");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        string elementValue(XElement e, string name)
        {
            string value = "";
            var t = (from x in e.Descendants()
                     where x.Name.LocalName.Equals(name)
                     select x).ToList();
            if( t.Count > 0 )
            {
                value = t[0].Value;
            }
            return value;
        }

        string fms;
        bool convert()
        {
            bool result = false;
            textBox_fms.Clear();
            textBox_fms.AppendText("I" + Environment.NewLine);
            textBox_fms.AppendText("1100 Version" + Environment.NewLine);
            textBox_fms.AppendText("CYCLE 1708" + Environment.NewLine);

            var waypoints = (from wp in fpl.Root.Descendants()
                             where wp.Name.LocalName == "waypoint"
                             select wp).ToList();

            List<string> airports = new List<string>();
            var s = (String.Format("NUMENR {0}{1}", waypoints.Count, Environment.NewLine));
            bool depAdded = false;
            foreach (var w in waypoints)
            {
                var s1 = "";
                var t = elementValue(w, "type");
                if (t == "AIRPORT" ) 
                {
                    if (depAdded == false )
                    {
                        //s1 = "1 " + elementValue(w, "identifier") + " ADEP ";
                        s1 = "1 " + elementValue(w, "identifier") + " DRCT ";
                        depAdded = true;
                    }
                    else
                    {
                        //s1 = "1 " + elementValue(w, "identifier") + " ADES ";
                        s1 = "1 " + elementValue(w, "identifier") + " DRCT ";
                    }
                    airports.Add(elementValue(w, "identifier"));
                }
                else if (t == "NDB")
                {
                    s1 = "2 " + elementValue(w, "identifier") + " DRCT ";
                }
                else if (t == "VOR")
                {
                    s1 = "3 " + elementValue(w, "identifier") + " DRCT ";
                }
                else if (t == "INT")
                {
                    s1 = "11 " + elementValue(w, "identifier") + " DRCT ";
                }
                else
                {
                    s1 = "28 " + elementValue(w, "identifier") + " DRCT ";
                }

                s1 += "0.000000 ";
                s1 += elementValue(w, "lat") + " ";
                s1 += elementValue(w, "lon") + " ";
                s1 += Environment.NewLine;

                s += s1;
            }
            if (airports.Count > 0)
            {
                textBox_fms.AppendText("ADEP " + airports[0] + Environment.NewLine);
                textBox_fms.AppendText("ADES " + airports.Last() + Environment.NewLine);
            }
            textBox_fms.AppendText(s);
            return result;
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(textBox_save.Text);
            saveFileDialog1.FileName = textBox_save.Text;
            if( saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox_fms.Text);
            }
        }
    }
}
