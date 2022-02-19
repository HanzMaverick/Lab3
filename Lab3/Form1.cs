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

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Guardar(string fileName, string texto)
        {
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uri = "";
             
            if (comboBoxurl.SelectedItem != null)
                uri = comboBoxurl.SelectedItem.ToString();
            if (comboBoxurl.Text != null)
                uri = comboBoxurl.Text;

            if (!uri.Contains("."))
                uri = "https://www.google.com/search?q=" + uri;
            if (!uri.Contains("https://" + uri))
                uri = "https://" + uri;

               webBrowser1.Navigate(new Uri(uri));

            comboBoxurl.Items.Add(uri);
            Guardar("Historial.txt", uri);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
