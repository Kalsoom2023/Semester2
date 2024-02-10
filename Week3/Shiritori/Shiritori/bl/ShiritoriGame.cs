using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori.bl
{
    public class ShiritoriGame
    {
        public List<string> Array = new List<string>();

        public bool Game_Over = false;

        public string Play(string word)
        {
            string a = "Game over";
            string b = "Added to list";
            if (Array == null)
            {
                Array.Add(word);
                return a;
            }


            if (Array.Count > 0)
            {
                string lastWord = Array[Array.Count - 1];
                char lastChar = lastWord[lastWord.Length - 1];
                char firstChar = word[0];

                if (char.ToLower(lastChar) != char.ToLower(firstChar))
                {
                    Game_Over = true;
                    return "Game over";
                }
            }





            for (int i = 0; i < Array.Count; i++)
            {
                if (word == Array[i])
                {
                    Game_Over = true;
                    return a;

                }

            }
            Array.Add(word);
            return b;
        }
        public string restart()
        {
            Array.Clear();
            string c = "Game restarted";
            Game_Over = false;
            return c;
        }

    }
}

        
    

