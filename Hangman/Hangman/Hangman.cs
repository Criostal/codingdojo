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
        int _attemps = 0;

        public Hangman(string secret)
        {
            _letters.Clear();
            _secret = secret;
            _attemps = 10;
        }

        public string Guess(char letter)
        {
            var s = string.Empty;
            _letters.Add(letter);
            
            foreach (var c in _secret)
            {
                if( _letters.Contains(char.ToUpper(c)) || _letters.Contains(char.ToLower(c)))
                {
                    s += c;
                }
                else
                {
                    s += '-';
                }
            }
            _attemps--;

            return s;
        }

        public int RemainingAttemps()
        {
            return _attemps < 0 ? 0 : _attemps;
        }
    }
}
