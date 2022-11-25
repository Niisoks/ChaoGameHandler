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

            PassChao = new Chao(Convert.FromBase64String(words[0]), Convert.FromBase64String(words[1]), Convert.FromBase64String(words[2]), Convert.FromBase64String(words[3]), Convert.FromBase64String(words[4]));
        }

        public Password(Chao inputChao)
        {
            string thisName = Convert.ToBase64String(inputChao.NameByte);
            string thisLevels = Convert.ToBase64String(inputChao.LevelsByte);
            string thisStats = Convert.ToBase64String(inputChao.StatsByte);
            string thisLessons = Convert.ToBase64String(inputChao.LessonsByte);
            string thisAlignment = Convert.ToBase64String(inputChao.AlignmentByte);
            Pass = (thisName + '-' + thisLevels + '-' + thisStats + '-' + thisLessons + '-' + thisAlignment);
        }
    }
}
