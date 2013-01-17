using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proxy;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int totalInt = 20000;
            progressBar1.Maximum = totalInt;
            //const string filepath = @"D:\";
            //const string filename = @"logfile.txt";
            //FileInfo fInfo = new FileInfo(filepath + filename);
            //if (!fInfo.Exists)
            //    fInfo.Create().Close();
            //StreamWriter w = fInfo.AppendText();
            //w.WriteLine("Start.");
            //w.Flush();
            //w.Close();
                label1.Text = "Start: " + DateTime.Now.ToString();
            for (int i = 1; i <= totalInt; i++)
            {
                    WCFProxy proxy = new WCFProxy();
                try
                {
                    proxy.Add("tester: " + i.ToString(), "Work: " + i.ToString());
                    //StreamWriter ww = fInfo.AppendText();
                    //ww.WriteLine("Added:  " + i.ToString() + "  " + DateTime.Now.ToLongTimeString());
                    //ww.Flush();
                    //ww.Close();
                }
                catch (Exception ex)
                {
                    //StreamWriter ww = fInfo.AppendText();
                    //ww.WriteLine("Exception: ");
                    //ww.WriteLine("for: " + i.ToString());
                    //ww.WriteLine("DateTime: " + DateTime.Now.ToString());
                    //ww.WriteLine("Context: " + ex.Message);
                    //ww.Flush();
                    //ww.Close();
                }
                finally
                {
                    progressBar1.Value += 1;
                    //proxy.Close();
                }

            }
                label2.Text = "End: " + DateTime.Now.ToString();
        }
    }
}
