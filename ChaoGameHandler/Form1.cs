using IronBarCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaoGameHandler
{
    public partial class Form1 : Form
    {
        public string directory;
        public string import;
        public Chao exportChao;

        public Form1()
        {
            InitializeComponent();
        }

        private void openDir_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.SafeFileName == "SONIC2B__ALF")
            {
                directory = @openFileDialog1.FileName;
                labelDir.Text = "Current file and directory : " + directory;
                MessageBox.Show("File loaded");
                
            } else
            {
                MessageBox.Show("Please point to a file named SONIC2B__ALF");
            }
            
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            if(directory!= null) 
            {
                exportChao = new Chao(0x3aa4, directory);
                chaoLabel.Text = exportChao.ToString();
                Password exportChaoPass = new Password(exportChao);
                string qrName = "MyQR.png";
                QRCodeWriter.CreateQrCode(exportChaoPass.Pass, 350, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng(qrName);
                qrPic.Image = new Bitmap("MyQR.png");
            } else
            {
                MessageBox.Show("Please use the Open File button first");
            }

        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            if (directory != null)
            {
                string[] words = importTxt.Text.Split('-');
                if(words.Length > 3 && IsBase64String(words[0]) && IsBase64String(words[1]) && IsBase64String(words[2])) { 
                    Chao importChao = new Chao(
                        Convert.FromBase64String(words[0]), Convert.FromBase64String(words[1]), Convert.FromBase64String(words[2])
                        , Convert.FromBase64String(words[3]), Convert.FromBase64String(words[4]), Convert.FromBase64String(words[5])
                        , Convert.FromBase64String(words[6]), Convert.FromBase64String(words[7]), Convert.FromBase64String(words[8])
                        , Convert.FromBase64String(words[9]), Convert.FromBase64String(words[10]), Convert.FromBase64String(words[11])
                        , Convert.FromBase64String(words[12]), Convert.FromBase64String(words[13]), Convert.FromBase64String(words[14])
                        , Convert.FromBase64String(words[15]), Convert.FromBase64String(words[16]), Convert.FromBase64String(words[17])
                        , Convert.FromBase64String(words[18]), Convert.FromBase64String(words[19]), Convert.FromBase64String(words[20])
                        , Convert.FromBase64String(words[21]), Convert.FromBase64String(words[22]), Convert.FromBase64String(words[23])
                        , Convert.FromBase64String(words[24]), Convert.FromBase64String(words[25]), Convert.FromBase64String(words[26]));
                    chaoLabel.Text = importChao.ToString();
                    Program.WriteHex(0x3aa4, directory, importChao);
                    Program.LaunchCommandLineApp(directory);
                }
                else { MessageBox.Show("Incorrect code, did you copy it correctly?"); }
            }
            else{   MessageBox.Show("Please use the Open File button first");   }
        }

        public static bool IsBase64String(string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

/*        private string AddQuotes(string path)
        {
            return !string.IsNullOrWhiteSpace(path) ?
                path.Contains(" ") && (!path.StartsWith("\"") && !path.EndsWith("\"")) ?
                    "\"" + path + "\"" : path :
                    string.Empty;
        }*/
    }
}
