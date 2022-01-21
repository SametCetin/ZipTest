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

namespace ZipTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            lblFilePath.Text = "FilePath";

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "(*.zip) | *.zip";
            DialogResult dr = opf.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            lblFilePath.Text = opf.FileName;
        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            if (lblFilePath.Text == "FilePath")
                return;

            var unzipPath = "D:\\UnzippedFile\\";

            if (Directory.Exists(unzipPath))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(unzipPath);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    Directory.Delete(unzipPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(lblFilePath.Text, unzipPath);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
