using System;
using System.Collections.Generic;
using System.Text;

namespace ChaoGameHandler
{
    public class Password
    {
        public string Pass { get; set; }
        public Chao PassChao { get; set; }

        public Password(string inputPass)
        {
            string[] words = inputPass.Split('-');

            PassChao = new Chao(Convert.FromBase64String(words[0]), Convert.FromBase64String(words[1]), Convert.FromBase64String(words[2]),
                Convert.FromBase64String(words[3]), Convert.FromBase64String(words[4]), Convert.FromBase64String(words[5])
                , Convert.FromBase64String(words[6]), Convert.FromBase64String(words[7]), Convert.FromBase64String(words[8])
                , Convert.FromBase64String(words[9]), Convert.FromBase64String(words[10]), Convert.FromBase64String(words[11])
                , Convert.FromBase64String(words[12]), Convert.FromBase64String(words[13]), Convert.FromBase64String(words[14])
                , Convert.FromBase64String(words[15]), Convert.FromBase64String(words[16]), Convert.FromBase64String(words[17])
                , Convert.FromBase64String(words[18]), Convert.FromBase64String(words[19]), Convert.FromBase64String(words[20])
                , Convert.FromBase64String(words[21]), Convert.FromBase64String(words[22]), Convert.FromBase64String(words[23])
                , Convert.FromBase64String(words[24]), Convert.FromBase64String(words[25]), Convert.FromBase64String(words[26]));
        }

        public Password(Chao inputChao)
        {
            string thisName = Convert.ToBase64String(inputChao.NameByte);
            string thisBasics = Convert.ToBase64String(inputChao.BasicsByte);
            string thisLife = Convert.ToBase64String(inputChao.LifeByte);
            string thisAnimalBehaviours = Convert.ToBase64String(inputChao.AnimalBehavioursByte);
            string thisToys = Convert.ToBase64String(inputChao.ToysByte);
            string thisType = Convert.ToBase64String(inputChao.TypeByte);
            string thisRunPower = Convert.ToBase64String(inputChao.RunPowerByte);
            string thisSwimFly = Convert.ToBase64String(inputChao.SwimFlyByte);
            string thisTransMag = Convert.ToBase64String(inputChao.TransformationMagnitudeByte);
            string thisStatsBar = Convert.ToBase64String(inputChao.StatsBarByte);
            string thisStatsGrade = Convert.ToBase64String(inputChao.StatsGradeByte);
            string thisBreed = Convert.ToBase64String(inputChao.BreedByte);
            string thisAccessories = Convert.ToBase64String(inputChao.AccessoriesByte);
            string thisBodyShape = Convert.ToBase64String(inputChao.BodyShapeByte);
            string thisAnimalParts = Convert.ToBase64String(inputChao.AnimalPartsByte);
            string thisDNAGrade = Convert.ToBase64String(inputChao.DNAGradeByte);
            string thisDNAPersonality = Convert.ToBase64String(inputChao.DNAPersonalityByte);
            string thisDNAAppearance = Convert.ToBase64String(inputChao.DNAAppearanceByte);
            string thisCharacterBond = Convert.ToBase64String(inputChao.CharacterBondsByte);
            string thisStandardEmotion = Convert.ToBase64String(inputChao.StandardEmotionsByte);
            string thisAniBehaviours = Convert.ToBase64String(inputChao.AnimatedBehavioursByte);
            string thisHealth = Convert.ToBase64String(inputChao.HealthByte);
            string thisPersonality = Convert.ToBase64String(inputChao.PersonalityByte);
            string thisLevels = Convert.ToBase64String(inputChao.LevelsByte);
            string thisStats = Convert.ToBase64String(inputChao.StatsByte);
            string thisLessons = Convert.ToBase64String(inputChao.LessonsByte);
            string thisAlignment = Convert.ToBase64String(inputChao.AlignmentByte);

            Pass = (thisName + '-' +
               thisBasics + '-' + thisLife + '-' + thisAnimalBehaviours + '-' + thisToys + '-' + thisType + '-' +
                thisRunPower + '-' + thisSwimFly + '-' + thisTransMag + '-' + thisStatsBar + '-' + thisStatsGrade + '-' +
                thisBreed + '-' + thisAccessories + '-' + thisBodyShape + '-' + thisAnimalParts + '-' + thisDNAGrade + '-' +
                thisDNAPersonality + '-' + thisDNAAppearance + '-' + thisCharacterBond + '-' + thisStandardEmotion + '-' + thisAniBehaviours + '-' +
                thisHealth + '-' + thisPersonality + '-' + thisLevels + '-' + thisStats + '-' + thisLessons + '-' + thisAlignment);
        }
    }
}
