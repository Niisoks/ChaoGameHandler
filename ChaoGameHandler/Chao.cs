using System;
using System.IO;
using System.Text;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Specialized;

namespace ChaoGameHandler
{
    public class Chao
    {
        public byte[] NameByte { get; set; }
        public byte[] LevelsByte { get; set; }
        public byte[] StatsByte { get; set; }
        public byte[] LessonsByte { get; set; }
        //evolution
        public byte[] AlignmentByte { get; set; }

        //______________________________________________
        //not implemented yet
        public byte[] StatsBarByte { get; set; }
        public byte[] StatsGradeByte { get; set; }
        //evolution
        public byte[] TypeByte { get; set; }
        public byte[] RunPowerByte { get; set; }
        public byte[] SwimFlyByte { get; set; }
        public byte[] TransformationMagnitudeByte { get; set; }
        public byte[] BasicsByte { get; set; } //garden,happiness, {reset trig}
        public byte[] LifeByte { get; set; }
        public byte[] AnimalBehavioursByte { get; set; }
        public byte[] ToysByte { get; set; }
        //chao appearance
        public byte[] BreedByte { get; set; }
        public byte[] AccessoriesByte { get; set; }
        public byte[] BodyShapeByte { get; set; }
        public byte[] AnimalPartsByte { get; set; }
        //chao DNA
        public byte[] DNAGradeByte { get; set; }
        public byte[] DNAPersonalityByte { get; set; }
        public byte[] DNAAppearanceByte { get; set; }
        //chao character bonds
        public byte[] CharacterBondsByte { get; set; }
        //chao emotions
        public byte[] StandardEmotionsByte { get; set; }
        public byte[] AnimatedBehavioursByte { get; set; }
        //chao health
        public byte[] HealthByte { get; set; }
        //chao personality
        public byte[] PersonalityByte { get; set; }

        private string[] levelNames = { 
            "Swim", 
            "Fly", 
            "Run", 
            "Power", 
            "Stamina", 
            "Luck", 
            "Intelligence"
        };

        private string[] lessons = new string[] {
            "bit1",
            "bit2",
            "bit3",
            "drawing5",
            "drawing4",
            "drawing3",
            "drawing2",
            "drawing1",
            "bit9",
            "bit10",
            "bit11",
            "exercise",
            "gogodance",
            "stepdance",
            "spindance",
            "shakedance",
            "bit17",
            "bit18",
            "bit19",
            "song5",
            "song4",
            "song3",
            "song2",
            "song1",
            "tambourine",
            "trumpet",
            "maracas",
            "flute",
            "drum",
            "cymbal",
            "castanets",
            "bell"
        }; 


        public Chao(string inputName = null, int[] inputLevel = null, int[] inputStats = null, string inputLessons = null)
        {
            NameByte = CreateName(inputName);
            LevelsByte = CreateLevels(inputLevel);
            StatsByte = CreateStats(inputStats);
            LessonsByte = CreateLessons(inputLessons);
        }

        public Chao(byte[] name, byte[] basics, byte[] life, byte[] animalBehaviours, byte[] toys,
            byte[] type, byte[] runPower, byte[] swimFly, byte[] transMag, byte[] statsBar, byte[] statsGrade,
            byte[] breed, byte[] accessories, byte[] bodyShape, byte[] animalParts, byte[] dNAGrade,
            byte[] dNAPersonality, byte[] dNAAppearance, byte[] characterBond, byte[] standardEmotion, byte[] aniBehaviours,
            byte[] health, byte[] personality, byte[] levels, byte[] stats, byte[] lessons, byte[] alignment)
        {
            NameByte = name;
            BasicsByte = basics;
            LifeByte = life;
            AnimalBehavioursByte = animalBehaviours;
            ToysByte = toys;
            TypeByte = type;
            RunPowerByte = runPower;
            SwimFlyByte = swimFly;
            TransformationMagnitudeByte = transMag;
            StatsBarByte = statsBar;
            StatsGradeByte = statsGrade;
            BreedByte = breed;
            AccessoriesByte = accessories;
            BodyShapeByte = bodyShape;
            AnimalPartsByte = animalParts;
            DNAGradeByte = dNAGrade;
            DNAPersonalityByte = dNAPersonality;
            DNAAppearanceByte = dNAAppearance;
            CharacterBondsByte = characterBond;
            StandardEmotionsByte = standardEmotion;
            AnimatedBehavioursByte = aniBehaviours;
            HealthByte = health;
            PersonalityByte = personality;
            LevelsByte = levels;
            StatsByte = stats;
            LessonsByte = lessons;
            AlignmentByte = alignment;
        }

        public Chao(int offset, string dir)
        {
            byte[] newNameByte = new byte[7];
            byte[] newBasicsByte = new byte[2];
            byte[] newLifeByte = new byte[6];
            byte[] newAnimalBehaviourByte = new byte[2];
            byte[] newToysByte = new byte[2];
            byte[] newTypeByte = new byte[1];
            byte[] newRunPowerByte = new byte[4];
            byte[] newSwimFlyByte = new byte[4];
            byte[] newTransformationMagnitudeByte = new byte[4];
            byte[] newStatsBarByte = new byte[7];
            byte[] newStatGradesByte = new byte[7];
            byte[] newBreedByte = new byte[5];
            byte[] newAccessoriesByte = new byte[2];
            byte[] newBodyShapeByte = new byte[6];
            byte[] newAnimalPartsByte = new byte[8];
            byte[] newDNAGradesByte = new byte[16];
            byte[] newDNAPersonalityByte = new byte[2];
            byte[] newDNAAppearanceByte = new byte[10];
            byte[] newCharacterBondsByte = new byte[6];
            byte[] newStandardEmotionsByte = new byte[12];
            byte[] newAnimatedBehavioursByte = new byte[4];
            byte[] newHealthByte = new byte[6];
            byte[] newPersonalityByte = new byte[6];
            byte[] newLevelsByte = new byte[7];
            byte[] newStatsByte = new byte[10];
            byte[] newLessonsByte = new byte[4];
            byte[] newAlignmentByte = new byte[4];

            using (FileStream sr = File.OpenRead(dir))
            {
                //0x3aa5 chao slot 1
                //THIS IS SO UGLY PLEASE THINK OF A BETTER WAY TO DO THIS
                int locationName, locationLvl, locationSta, locationLes, locationAli, locationBas, locationLif, locationAnB, locationToy, locationTyp,
                    locationRuP, locationSwF, locationTrM, locationStB, locationStG, locationBre, locationAcc, locationBoS, locationAnP, locationDGr,
                    locationDPe, locationApp, locationChB, locationEmo, locationAni, locationHea, locationPer;

                locationName = locationLvl = locationSta = locationLes = locationAli = locationBas = locationLif = locationAnB = locationToy = locationTyp =
                    locationRuP = locationSwF = locationTrM = locationStB = locationStG = locationBre = locationAcc = locationBoS = locationAnP = locationDGr =
                    locationDPe = locationApp = locationChB = locationEmo = locationAni = locationHea = locationPer = 0;
                
                int endLocation = offset + 0x800;
                sr.Seek(offset, SeekOrigin.Begin);
                
                for (int curLocation = offset; curLocation <= endLocation; curLocation++)
                {
                    int curRead = sr.ReadByte();
                    switch (curLocation)
                    {
                        //General
                        //Basics - name + garden,happiness
                        case var _ when (curLocation >= offset + 18 && curLocation <= offset + 24):
                            newNameByte[locationName] = (byte)curRead;
                            locationName++;
                            break;
                        case var _ when (curLocation >= offset + 129 && curLocation <= offset + 130):
                            newBasicsByte[locationBas] = (byte)curRead;
                            locationBas++;
                            break;
                        //Life - LS1,2,reincarnations
                        case var _ when (curLocation >= offset + 138 && curLocation <= offset + 143):
                            newLifeByte[locationLif] = (byte)curRead;
                            locationLif++;
                            break;
                        //Learnt abilities - animalbehaviours + classroom skills + toys
                        case var _ when (curLocation >= offset + 280 && curLocation <= offset + 281):
                            newAnimalBehaviourByte[locationAnB] = (byte)curRead;
                            locationAnB++;
                            break;
                        case var _ when (curLocation >= offset + 352 && curLocation <= offset + 355):
                            newLessonsByte[locationLes] = (byte)curRead;
                            locationLes++;
                            break;
                        case var _ when (curLocation >= offset + 356 && curLocation <= offset + 357):
                            newToysByte[locationToy] = (byte)curRead;
                            locationToy++;
                            break;

                        //evolution
                        //type
                        case var _ when (curLocation == offset + 128):
                            newTypeByte[0] = (byte)curRead;
                            break;
                        //alignment
                        case var _ when (curLocation >= offset + 176 && curLocation <= offset + 179):
                            newAlignmentByte[locationAli] = (byte)curRead;
                            locationAli++;
                            break;
                        //runpower
                        case var _ when (curLocation >= offset + 168 && curLocation <= offset + 171):
                            newRunPowerByte[locationRuP] = (byte)curRead;
                            locationRuP++;
                            break;
                        //swimfly
                        case var _ when (curLocation >= offset + 172 && curLocation <= offset + 175):
                            newSwimFlyByte[locationSwF] = (byte)curRead;
                            locationSwF++;
                            break;
                        //transformation mangnitude
                        case var _ when (curLocation >= offset + 192 && curLocation <= offset + 195):
                            newTransformationMagnitudeByte[locationTrM] = (byte)curRead;
                            locationTrM++;
                            break;


                        //stats
                        //stat bars
                        case var _ when (curLocation >= offset + 32 && curLocation <= offset + 38):
                            newStatsBarByte[locationStB] = (byte)curRead;
                            locationStB++;
                            break;
                        //grades
                        case var _ when (curLocation >= offset + 40 && curLocation <= offset + 45):
                            newStatGradesByte[locationStG] = (byte)curRead;
                            locationStG++;
                            break;
                        //levels
                        case var _ when (curLocation >= offset+48 && curLocation <= offset+54):
                            newLevelsByte[locationLvl] = (byte)curRead;
                            locationLvl++;
                            break;
                        //stat number
                        case var _ when (curLocation >= offset+56 && curLocation <= offset+65):
                            newStatsByte[locationSta] = (byte)curRead;
                            locationSta++;
                            break;

                        //appearance
                        //breed
                        case var _ when (curLocation >= offset + 216 && curLocation <= offset + 220):
                            newBreedByte[locationBre] = (byte)curRead;
                            locationBre++;
                            break;
                        //Accessories - medal + hat
                        case var _ when (curLocation == offset + 215):
                            newAccessoriesByte[0] = (byte)curRead;
                            break;
                        case var _ when (curLocation == offset + 213):
                            newAccessoriesByte[1] = (byte)curRead;
                            break;
                        //body shape - bodytype,animal + eyes,mouth,emoball + hiddenfeet
                        case var _ when (curLocation >= offset + 221 && curLocation <= offset + 222):
                            newBodyShapeByte[locationBoS] = (byte)curRead;
                            locationBoS++;
                            break;
                        case var _ when (curLocation >= offset + 209 && curLocation <= offset + 211):
                            newBodyShapeByte[locationBoS] = (byte)curRead;
                            locationBoS++;
                            break;
                        case var _ when (curLocation == offset + 214):
                            newBodyShapeByte[locationBoS] = (byte)curRead;
                            locationBoS++;
                            break;
                        //animal parts - arms,ears,4head,horns,legs,tail,wings,face
                        case var _ when (curLocation >= offset + 284 && curLocation <= offset + 291):
                            newAnimalPartsByte[locationAnP] = (byte)curRead;
                            locationAnP++;
                            break;

                        //DNA
                        //grades
                        case var _ when (curLocation >= offset + 1172 && curLocation <= offset + 1187):
                            newDNAGradesByte[locationDGr] = (byte)curRead;
                            locationDGr++;
                            break;
                        //personality
                        case var _ when (curLocation >= offset + 1222 && curLocation <= offset + 1223):
                            newDNAPersonalityByte[locationDPe] = (byte)curRead;
                            locationDPe++;
                            break;
                        //appearance
                        case var _ when (curLocation >= offset + 1228 && curLocation <= offset + 1237):
                            newDNAAppearanceByte[locationApp] = (byte)curRead;
                            locationApp++;
                            break;

                        //bonds
                        case var _ when (curLocation == offset + 364 || curLocation == offset + 370
                        || curLocation == offset + 376 || curLocation == offset + 382
                        || curLocation == offset + 388 || curLocation == offset + 394):
                            newCharacterBondsByte[locationChB] = (byte)curRead;
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
                            newStandardEmotionsByte[locationEmo] = (byte)curRead;
                            locationEmo++;
                            break;
                        //Animated
                        case var _ when (curLocation == offset + 300 || curLocation == offset + 302
                        || curLocation == offset + 303 || curLocation == offset + 305):
                            newAnimatedBehavioursByte[locationAni] = (byte)curRead;
                            locationAni++;
                            break;

                        //Health
                        case var _ when (curLocation >= offset + 346 && curLocation <= offset + 351):
                            newHealthByte[locationHea] = (byte)curRead;
                            locationHea++;
                            break;

                        //Personality
                        case var _ when (curLocation == offset + 343 || curLocation == offset + 330
                        || curLocation == offset + 332 || curLocation == offset + 333
                        || curLocation == offset + 336 || curLocation == offset + 341):
                            newPersonalityByte[locationPer] = (byte)curRead;
                            locationPer++;
                            break;

                        default:
                            break;
                    }
                }
            }
            NameByte = newNameByte;
            BasicsByte = newBasicsByte;
            LifeByte = newLifeByte;
            AnimalBehavioursByte = newAnimalBehaviourByte;
            ToysByte = newToysByte;
            TypeByte = newTypeByte;
            RunPowerByte = newRunPowerByte;
            SwimFlyByte = newSwimFlyByte;
            TransformationMagnitudeByte = newTransformationMagnitudeByte;
            StatsBarByte = newStatsBarByte;
            StatsGradeByte = newStatGradesByte;
            BreedByte = newBreedByte;
            AccessoriesByte = newAccessoriesByte;
            BodyShapeByte = newBodyShapeByte;
            AnimalPartsByte = newAnimalPartsByte;
            DNAGradeByte = newDNAGradesByte;
            DNAPersonalityByte = newDNAPersonalityByte;
            DNAAppearanceByte = newDNAAppearanceByte;
            CharacterBondsByte = newCharacterBondsByte;
            StandardEmotionsByte = newStandardEmotionsByte;
            AnimatedBehavioursByte = newAnimatedBehavioursByte;
            HealthByte = newHealthByte;
            PersonalityByte = newPersonalityByte;
            LevelsByte = newLevelsByte;
            StatsByte = newStatsByte;
            LessonsByte = newLessonsByte;
            AlignmentByte = newAlignmentByte;
        }
        
        private float LEByteToFloat(byte[] floatValue)
        {
            //byte[] reverseBytesAr = new byte[floatValue.Length];
            //for (int i = 0; i < reverseBytesAr.Length; i++)
            //{
            //    reverseBytesAr[i] = floatValue[floatValue.Length - i - 1];
            //}
           
            //for (int i = 0; i < floatValue.Length; i++)
            //{
            //    MessageBox.Show(floatValue[i].ToString());
            float newFloat = BitConverter.ToSingle(floatValue, 0);
            //}
            return newFloat;
        }

        private byte[] CreateStats(int[] newStats)
        {
            byte[] newStatsByte = new byte[10];
            for (int i = 0, x = 1; i < levelNames.Length - 2; i++, x += 2)
            {
                var test = BinaryPrimitives.ReverseEndianness(newStats[i]);
                var hex = test.ToString("x");
                string trimmed = hex.Substring(0, hex.Length - 4);
                uint num = uint.Parse(trimmed, System.Globalization.NumberStyles.AllowHexSpecifier);
                byte[] floatVals = BitConverter.GetBytes(num);

                newStatsByte[x] = floatVals[0];
                newStatsByte[x - 1] = floatVals[1];
            }
            return newStatsByte;
        }

        private byte[] CreateLessons(string newLessons)
        {
            int numOfBytes = newLessons.Length / 8;
            byte[] newLessonsByte = new byte[4];
            for (int i = 0; i < numOfBytes; ++i)
            {
                newLessonsByte[i] = Convert.ToByte(newLessons.Substring(8 * i, 8), 2);
            }
            return newLessonsByte;
        }


        private byte[] CreateLevels(int[] newLevels)
        {
            byte[] newLevelsByte = new byte[7];
            int newLevel = 0;
            for (int i = 0; i < newLevelsByte.Length; i++)
            {
                if (newLevels == null)
                {
                    Console.WriteLine("enter level for " + levelNames[i]);
                    newLevel = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    newLevel = newLevels[i];
                }
                newLevelsByte[i] = Convert.ToByte(newLevel);
            }
            return newLevelsByte;
        }

        private byte[] CreateName(string newInputName)
        {
            char[] charArr = null;
            byte[] newNameByte = new byte[7];
            if (newInputName == null)
            {
                Console.WriteLine("enter name: ");
                string newName = Console.ReadLine();
                charArr = newName.ToCharArray();
            }
            else
            {
                charArr = newInputName.ToCharArray();
            }
            
            for (int i = 0; i < newNameByte.Length; i++)
            {
                if (i < charArr.Length)
                {
                    newNameByte[i] = Convert.ToByte(charArr[i]);
                }
                else
                {
                    newNameByte[i] = Convert.ToByte(95);
                }
            }
            return newNameByte;
        }


        //COMPLETELY REWRITE THIS BEFORE PUBLISHING ITS POOP
        public override string ToString()
        {
            string strName = Encoding.UTF8.GetString(NameByte);
            int[] intLevels = Array.ConvertAll(LevelsByte, c => (int)c);
            int[] intStats = Array.ConvertAll(StatsByte, c => (int)c);
            int[] intBars = Array.ConvertAll(StatsBarByte, c => (int)c);
            string[] strStats = new string[intStats.Length / 2];
            for (int i = 0, q = 1; i < strStats.Length; i++, q+=2)
            {
                strStats[i] = intStats[q].ToString("X") + "" + intStats[q-1].ToString("X");
            }

            for (int i = 0; i < strStats.Length; i++)
            {
                uint num = uint.Parse(strStats[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                strStats[i] = num.ToString();
            }


            string[] strLevelNames = levelNames;
            string[] strArLevels = new string[strLevelNames.Length];
            for (int i = 0; i < strArLevels.Length; i++)
            {
                if(i < strStats.Length)
                {
                    strArLevels[i] = strLevelNames[i] + " : " + intLevels[i] + " - " + strStats[i] + " // " + intBars[i] + "\n";
                }
                else
                {
                    strArLevels[i] = strLevelNames[i] + " : " + intLevels[i] + "\n";
                }
            }
            var strLevels = string.Empty;
            foreach (var item in strArLevels)
            {
                strLevels += item;
            }

            var strAlignment = Convert.ToString(BitConverter.ToSingle(AlignmentByte, 0));

            var strLessons = string.Empty;
            foreach (var value in LessonsByte)
            {
                strLessons += Convert.ToString(value, 2).PadLeft(8, '0');
            }
            var strJeff1 = strLessons.ToCharArray();
            string[] strJeff = new string[32];
            for (int i = 0; i < strJeff1.Length; i++)
            {
                if( strJeff1[i] == '0'){ strJeff[i] = " False"; }
                else { strJeff[i] = " True"; }
            }
            string strLessonsAll = string.Empty;
            for (int i = 0; i < strLessons.Length; i++)
            {
                if(i%5 == 0){ strLessonsAll += "\n" + lessons[i] + ":" + strJeff[i] + "||"; }
                else { strLessonsAll += lessons[i] + ":" + strJeff[i] + "||"; }
            }

            return "This Chao's name is: " + strName
                + "\nThis Chao's levels are:\n" + strLevels
                + "\nLessons Learned:\n" + strLessonsAll
                + "\nAlignment: " + strAlignment;
        }
    }
}




//char[] charArr = fourDigit.ToCharArray();
//if (charArr[0] == '0')
//{
//    StatsByte[x - 1] = Convert.ToByte(fourDigit);
//    //StatsByte[x - 1] = Convert.ToByte(charArr[1].ToString() + charArr[2].ToString());
//}
//else
//{
//    StatsByte[x - 1] = Convert.ToByte(charArr[2].ToString() + charArr[3].ToString());
//    StatsByte[x] = Convert.ToByte(charArr[0].ToString() + charArr[1].ToString());
//}