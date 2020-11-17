using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman
{
    [TestClass]
    public class HangmanTest
    {
        [TestMethod]
        public void TestMethodHangman()
        {
            var h = new Hangman("Developer");
            
            Assert.AreEqual("---------", h.Guess('A'));
            Assert.AreEqual("-e-e---e-", h.Guess('E'));
            Assert.AreEqual("-e-e---e-", h.Guess('I'));
            Assert.AreEqual("-e-e-o-e-", h.Guess('O'));
            Assert.AreEqual("-e-e-o-e-", h.Guess('U'));
            Assert.AreEqual("-e-e-o-er", h.Guess('R'));
            Assert.AreEqual("-e-e-o-er", h.Guess('N'));
            Assert.AreEqual("-e-e-o-er", h.Guess('S'));
            Assert.AreEqual("-e-e-o-er", h.Guess('T'));
            Assert.AreEqual("-e-elo-er", h.Guess('L'));
            Assert.AreEqual("-e-eloper", h.Guess('P'));
            Assert.AreEqual("De-eloper", h.Guess('D'));
            Assert.AreEqual("Developer", h.Guess('V'));
        }

        [DataTestMethod]
        [DataRow("---------", "A")]
        [DataRow("-e-e---e-", "AE")]
        [DataRow("-e-e---e-", "AEI")]
        [DataRow("-e-e-o-e-", "AEIO")]
        [DataRow("-e-e-o-e-", "AEIOU")]
        [DataRow("-e-e-o-er", "AEIOUR")]
        [DataRow("-e-e-o-er", "AEIOURN")]
        [DataRow("-e-e-o-er", "AEIOURNS")]
        [DataRow("-e-e-o-er", "AEIOURNST")]
        [DataRow("-e-elo-er", "AEIOURNSTL")]
        [DataRow("-e-eloper", "AEIOURNSTLP")]
        [DataRow("De-eloper", "AEIOURNSTLPD")]
        [DataRow("Developer", "AEIOURNSTLPDV")]
        public void TestMethodHangmanParameter(string expected, string input)
        {
            var h = new Hangman("Developer");
            string s = "";
            foreach (var c in input)
            {
                s = h.Guess(c);
            }

            Assert.AreEqual(s, expected);
        }


        [DataTestMethod]
        [DataRow("secret", 'x', "------")]
        [DataRow("apple", 'x', "-----")]
        public void GuessWrongLetterShouldReturnDashedString(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }

        [DataTestMethod]
        [DataRow("secret", 'e', "-e--e-")]
        [DataRow("apple", 'e', "----e")]
        [DataRow("apple", 'a', "a----")]
        public void GuessCorrectLetterShouldReturnStringWithRevealedChar(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }

        [DataTestMethod]
        [DataRow("secret", 'C', "--c---")]
        [DataRow("apple", 'p', "-pp--")]
        [DataRow("apple", 'L', "---l-")]
        [DataRow("APPLE", 'l', "---L-")]
        public void GuessedLetterIsFoundRegardlessTheCase(string secret, char guessedLetter, string solvedSecret)
        {
            Hangman h = new Hangman(secret);
            Assert.AreEqual(solvedSecret, h.Guess(guessedLetter));
        }
   

        [TestMethod]
        public void OneGuessShouldReduceRemainingAttemptsByOne()
        {
            Hangman h = new Hangman("secret");

            Assert.AreEqual("-e--e-", h.Guess('e'));
            Assert.AreEqual(9, h.RemainingAttemps());
            Assert.AreEqual("se--e-", h.Guess('s'));
            Assert.AreEqual(8, h.RemainingAttemps());
            Assert.AreEqual("se-re-", h.Guess('r'));
            Assert.AreEqual(7, h.RemainingAttemps());
            Assert.AreEqual("secre-", h.Guess('c'));
            Assert.AreEqual(6, h.RemainingAttemps());
            Assert.AreEqual("secret", h.Guess('t'));
            Assert.AreEqual(5, h.RemainingAttemps());
        }

        [TestMethod]
        public void NoMoreGuessingPossibleOnceNoAttemptIsLeft()
        {
            Hangman h = new Hangman("abc");

            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(9, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(8, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(7, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(6, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(5, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(4, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(3, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(2, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(1, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x'));Assert.AreEqual(0, h.RemainingAttemps());
            Assert.AreEqual("---", h.Guess('x')); Assert.AreEqual(0, h.RemainingAttemps());
        }

    }
}
