using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Hangman
    {
        private string _secret = string.Empty;
        private HashSet<char> _letters = new HashSet<char>();

        public Hangman(string secret)
        {
            _letters.Clear();
            _secret = secret;
        }

        public string Guess(char letter)
        {
            var s = string.Empty;
            _letters.Add(letter);
            foreach (var c in _secret)
            {
                if( _letters.Contains(char.ToUpper(c)) )
                {
                    s += char.ToUpper(c);
                }
                else
                {
                    s += '-';
                }
            }
            return s;
        }
    }
}
