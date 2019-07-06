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

        void convert()
        {
            // remove namespace for simpler processing
            fpl.Descendants()
            .Attributes()
            .Where(x => x.IsNamespaceDeclaration)
            .Remove();

            foreach (var elem in fpl.Descendants())
                elem.Name = elem.Name.LocalName;

            var waypoints = (from wp in fpl.Root.Descendants()
                             where wp.Name == "waypoint"
                             select wp).ToList();

            List<XElement> airports = new List<XElement>();

            foreach (var w in waypoints)
            {
                if (w.Element("type").Value == "AIRPORT")
                {
                    airports.Add(w);
                }
            }

            XElement dep = null;
            XElement des = null;
            var wpCount = waypoints.Count();

            // setup departure and destination as per first and last waypoints being airports
            if (waypoints.First().Element("type").Value == "AIRPORT")
            {
                dep = waypoints.First();
                ++wpCount;
            }
            if (waypoints.Last().Element("type").Value == "AIRPORT")
            {
                des = waypoints.Last();
                ++wpCount;
            }

            // setup fms header 
            textBox_fms.Clear();
            textBox_fms.AppendText("I" + Environment.NewLine);
            textBox_fms.AppendText("1100 Version" + Environment.NewLine);
            textBox_fms.AppendText("CYCLE 1708" + Environment.NewLine);

            // setup departure block
            if (dep != null)
            {
                textBox_fms.AppendText("ADEP " + dep.Element("identifier").Value.ToString() + Environment.NewLine);
            }
            else if( waypoints.Count > 0)
            {
                textBox_fms.AppendText("DEP " + waypoints.First().Element("identifier").Value.ToString() + Environment.NewLine);
            }
            // setup destination block
            if (des != null)
            {
                textBox_fms.AppendText("ADES " + des.Element("identifier").Value.ToString() + Environment.NewLine);
            }
            else if( waypoints.Count > 1)
            {
                textBox_fms.AppendText("DES " + waypoints.Last().Element("identifier").Value.ToString() + Environment.NewLine);
            }
            textBox_fms.AppendText(String.Format("NUMENR {0}{1}", wpCount, Environment.NewLine));

            // setup waypoints
            if (dep != null)
            {
                textBox_fms.AppendText( getAirport( dep, " ADEP "));
            }
            foreach (var w in waypoints)
            {
                textBox_fms.AppendText(getWaypoint( w));
            }

            if (des != null)
            {
                textBox_fms.AppendText( getAirport( des, " ADES "));
            }
        }

        // for adding dep and dest airport waypoints
        string getAirport( XElement w, string ident)
        {
            string s1 = "";
            {
                if (w.Element("type").Value == "AIRPORT")
                {
                    s1 = "1 " + w.Element("identifier").Value.ToString() + ident;
                }

                s1 += "0.000000 ";
                s1 += w.Element("lat").Value.ToString() + " ";
                s1 += w.Element("lon").Value.ToString() + " ";
                s1 += Environment.NewLine;
            }
            return s1;
        }
        private static string getWaypoint( XElement w)
        {
            string s1 = "";
            
                if (w.Element("type").Value == "NDB")
                {
                    s1 = "2 " + w.Element("identifier").Value.ToString() + " DRCT ";
                }
                else if (w.Element("type").Value == "VOR")
                {
                    s1 = "3 " + w.Element("identifier").Value.ToString() + " DRCT ";
                }
                else if (w.Element("type").Value == "INT")
                {
                    s1 = "11 " + w.Element("identifier").Value.ToString() + " DRCT ";
                }
                else if (w.Element("type").Value == "AIRPORT")
                {
                    s1 = "11 " + w.Element("identifier").Value.ToString() + " DRCT ";
                }
                else
                {
                    s1 = "28 " + w.Element("identifier").Value.ToString() + " DRCT ";
                }

                s1 += "0.000000 ";
                s1 += w.Element("lat").Value.ToString() + " ";
                s1 += w.Element("lon").Value.ToString() + " ";
                s1 += Environment.NewLine;

            return s1;
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
