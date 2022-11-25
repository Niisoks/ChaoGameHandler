using System;
using System.Diagnostics;
using System.IO;
using IronBarCode;
using System.Windows.Forms;

namespace ChaoGameHandler
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Chao newChao2 = new Chao("CUNTFAGGOT", new int[] { 15, 55, 35, 66, 88, 40, 65 }, new int[] { 132, 204, 360, 410, 553 }, "00011111000000000000000000000111");
            //WriteHex(0x3ab6, 0x3c08, directory, newChao2);
            //LaunchCommandLineApp(directory);
            //MessageBox.Show(newChao2.ToString());

            //Chao oldChao = new Chao(0x3ab6, 0x3ae5, args[0]);
            //Password oldChaoPass = new Password(oldChao);
            //QRCodeWriter.CreateQrCode(oldChaoPass.Pass, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");

            //Password newChao = new Password(Console.ReadLine());
            ////Console.Write(newChao.PassChao);
            ////Console.Write(oldChao);
            ////Console.Write(newChao2);
            //WriteHex(0x3ab6, 0x3ae5, args[0], newChao.PassChao);
            //LaunchCommandLineApp(args[0]);
        }

        public static void WriteHex(int startLocation, int endLocation, string dir, Chao chao)
        {
            using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(dir)))
            {
                bw.Seek(startLocation, SeekOrigin.Begin);
                int locationName, locationLvl, locationSta, locationLes, locationAli;
                locationName = locationLvl = locationSta = locationLes = locationAli = 0;
                int z = 0;
                for (int curLocation = startLocation; curLocation <= endLocation; curLocation++)
                {
                    switch (curLocation)
                    {
                        case var _ when (curLocation <= 0x3abc):
                            bw.Write(chao.NameByte[locationName]);
                            locationName++;
                            break;

                        case var _ when (curLocation >= 0x3ad4 && curLocation <= 0x3ada):
                            if (locationLvl == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.LevelsByte[locationLvl]);
                            locationLvl++;
                            break;

                        case var _ when (curLocation >= 0x3adc && curLocation <= 0x3ae5):
                            if (locationSta == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.StatsByte[locationSta]);
                            locationSta++;
                            break;

                        case var _ when (curLocation >= 0x3b54 && curLocation <= 0x3b57):
                            if (locationAli == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.StatsByte[locationAli]);
                            locationAli++;
                            break;

                        case var _ when (curLocation >= 0x3c04 && curLocation <= 0x3c07):
                            if (locationLes == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.LessonsByte[locationLes]);
                            locationLes++;
                            break;

                        default:
                            break;
                    }
                }
            }
            
        }



        public static void LaunchCommandLineApp(string args)
        {
            //Chao newChao2 = new Chao("PISSBABY", new int[] { 15, 55, 35, 66, 88, 40, 65 }, new int[] { 132, 204, 360, 410, 553 });
            // For the example
            string hashfixer = "SA2HashFix.exe";
            //Process.Start(hashfixer, args);
            HashFix.Main(args);

        }
    }
}