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

        }

        public static void WriteHex(int offset, string dir, Chao chao)
        {
            using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(dir)))
            {
                int locationName, locationLvl, locationSta, locationLes, locationAli, locationBas, locationLif, locationAnB, locationToy, locationTyp,
                    locationRuP, locationSwF, locationTrM, locationStB, locationStG, locationBre, locationAcc, locationBoS, locationAnP, locationDGr,
                    locationDPe, locationApp, locationChB, locationEmo, locationAni, locationHea, locationPer;

                locationName = locationLvl = locationSta = locationLes = locationAli = locationBas = locationLif = locationAnB = locationToy = locationTyp =
                    locationRuP = locationSwF = locationTrM = locationStB = locationStG = locationBre = locationAcc = locationBoS = locationAnP = locationDGr =
                    locationDPe = locationApp = locationChB = locationEmo = locationAni = locationHea = locationPer = 0;

                int endLocation = offset + 0x800;
                bw.Seek(offset, SeekOrigin.Begin);
                for (int curLocation = offset; curLocation <= endLocation; curLocation++)
                {
                    switch (curLocation)
                    {
                        //case var _ when (curLocation <= 0x3abc):
                        //    bw.Write(chao.NameByte[locationName]);
                        //    locationName++;
                        //    break;

                        //case var _ when (curLocation >= 0x3ad4 && curLocation <= 0x3ada):
                        //    if (locationLvl == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                        //    bw.Write(chao.LevelsByte[locationLvl]);
                        //    locationLvl++;
                        //    break;

                        //General
                        //Basics - name + garden,happiness
                        case var _ when (curLocation >= offset + 18 && curLocation <= offset + 24):
                            if (locationName == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.NameByte[locationName]);
                            locationName++;
                            break;
                        case var _ when (curLocation >= offset + 129 && curLocation <= offset + 130):
                            if (locationBas == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.BasicsByte[locationBas]);
                            locationBas++;
                            break;
                        //Life - LS1,2,reincarnations
                        case var _ when (curLocation >= offset + 138 && curLocation <= offset + 143):
                            if (locationLif == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.LifeByte[locationLif]);
                            locationLif++;
                            break;
                        //Learnt abilities - animalbehaviours + classroom skills + toys
                        case var _ when (curLocation >= offset + 280 && curLocation <= offset + 282):
                            if (locationAnB == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.AnimalBehavioursByte[locationAnB]);
                            locationAnB++;
                            break;
                        case var _ when (curLocation >= offset + 352 && curLocation <= offset + 355):
                            if (locationLes == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.LessonsByte[locationLes]);
                            locationLes++;
                            break;
                        case var _ when (curLocation >= offset + 356 && curLocation <= offset + 357):
                            if (locationToy == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.ToysByte[locationToy]);
                            locationToy++;
                            break;

                        //evolution
                        //type
                        case var _ when (curLocation == offset + 128):
                            if (locationTyp == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.TypeByte[locationTyp]);
                            locationTyp++;
                            break;
                        //alignment
                        case var _ when (curLocation >= offset + 176 && curLocation <= offset + 179):
                            if (locationAli == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.AlignmentByte[locationAli]);
                            locationAli++;
                            break;
                        //runpower
                        case var _ when (curLocation >= offset + 168 && curLocation <= offset + 171):
                            if (locationRuP == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.RunPowerByte[locationRuP]);
                            locationRuP++;
                            break;
                        //swimfly
                        case var _ when (curLocation >= offset + 172 && curLocation <= offset + 175):
                            if (locationSwF == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.SwimFlyByte[locationSwF]);
                            locationSwF++;
                            break;
                        //transformation mangnitude
                        case var _ when (curLocation >= offset + 192 && curLocation <= offset + 195):
                            if (locationTrM == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.TransformationMagnitudeByte[locationTrM]);
                            locationTrM++;
                            break;


                        //stats
                        //stat bars
                        case var _ when (curLocation >= offset + 32 && curLocation <= offset + 38):
                            if (locationStB == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.StatsBarByte[locationStB]);
                            locationStB++;
                            break;
                        //grades
                        case var _ when (curLocation >= offset + 40 && curLocation <= offset + 45):
                            if (locationStG == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.StatsGradeByte[locationStG]);
                            locationStG++;
                            break;
                        //levels
                        case var _ when (curLocation >= offset + 48 && curLocation <= offset + 54):
                            if (locationLvl == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.LevelsByte[locationLvl]);
                            locationLvl++;
                            break;
                        //stat number
                        case var _ when (curLocation >= offset + 56 && curLocation <= offset + 69):
                            if (locationSta == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.StatsByte[locationSta]);
                            locationSta++;
                            break;

                        //appearance
                        //breed
                        case var _ when (curLocation >= offset + 216 && curLocation <= offset + 220):
                            if (locationBre == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.BreedByte[locationBre]);
                            locationBre++;
                            break;
                        //Accessories - medal + hat
                        case var _ when (curLocation == offset + 215):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.AccessoriesByte[0]);
                            break;
                        case var _ when (curLocation == offset + 213):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.AccessoriesByte[1]);
                            break;
                        //body shape - bodytype,animal + eyes,mouth,emoball + hiddenfeet
                        case var _ when (curLocation >= offset + 221 && curLocation <= offset + 222):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.BodyShapeByte[locationBoS]);
                            locationBoS++;
                            break;
                        case var _ when (curLocation >= offset + 209 && curLocation <= offset + 211):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.BodyShapeByte[locationBoS]);
                            locationBoS++;
                            break;
                        case var _ when (curLocation == offset + 214):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.BodyShapeByte[locationBoS]);
                            locationBoS++;
                            break;
                        //animal parts - arms,ears,4head,horns,legs,tail,wings,face
                        case var _ when (curLocation >= offset + 284 && curLocation <= offset + 291):
                            if (locationAnP == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.AnimalPartsByte[locationAnP]);
                            locationAnP++;
                            break;

                        //DNA
                        //grades
                        case var _ when (curLocation >= offset + 1172 && curLocation <= offset + 1187):
                            if (locationDGr == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.DNAGradeByte[locationDGr]);
                            locationDGr++;
                            break;
                        //personality
                        case var _ when (curLocation >= offset + 1222 && curLocation <= offset + 1223):
                            if (locationDPe == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.DNAPersonalityByte[locationDPe]);
                            locationDPe++;
                            break;
                        //appearance
                        case var _ when (curLocation >= offset + 1228 && curLocation <= offset + 1237):
                            if (locationApp == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.DNAAppearanceByte[locationApp]);
                            locationApp++;
                            break;

                        //bonds
                        case var _ when (curLocation == offset + 364 || curLocation == offset + 370
                        || curLocation == offset + 376 || curLocation == offset + 382
                        || curLocation == offset + 388 || curLocation == offset + 394):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.CharacterBondsByte[locationChB]);
                            locationChB++;
                            break;

                        //Emotions
                        //Standard
                        case var _ when (curLocation == offset + 314 || curLocation == offset + 315
                        || curLocation == offset + 312 || curLocation == offset + 313
                        || curLocation == offset + 292 || curLocation == offset + 293
                        || curLocation == offset + 310 || curLocation == offset + 311
                        || curLocation == offset + 316 || curLocation == offset + 317
                        || curLocation == offset + 328 || curLocation == offset + 329):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.StandardEmotionsByte[locationEmo]);
                            locationEmo++;
                            break;
                        //Animated
                        case var _ when (curLocation == offset + 300 || curLocation == offset + 302
                        || curLocation == offset + 303 || curLocation == offset + 305):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.AnimatedBehavioursByte[locationAni]);
                            locationAni++;
                            break;

                        //Health
                        case var _ when (curLocation >= offset + 346 && curLocation <= offset + 351):
                            if (locationHea == 0) { bw.Seek(curLocation, SeekOrigin.Begin); }
                            bw.Write(chao.HealthByte[locationHea]);
                            locationHea++;
                            break;

                        //Personality
                        case var _ when (curLocation == offset + 343 || curLocation == offset + 330
                        || curLocation == offset + 332 || curLocation == offset + 333
                        || curLocation == offset + 336 || curLocation == offset + 341):
                            bw.Seek(curLocation, SeekOrigin.Begin);
                            bw.Write(chao.PersonalityByte[locationPer]);
                            locationPer++;
                            break;

                        default:
                            break;
                    }
                }
            }
            
        }



        public static void LaunchCommandLineApp(string args)
        {
            string hashfixer = "SA2HashFix.exe";
            //Process.Start(hashfixer, args);
            HashFix.Main(args);

        }
    }
}
