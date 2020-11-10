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
            Assert.AreEqual("-E-E---E-", h.Guess('E'));
            Assert.AreEqual("-E-E---E-", h.Guess('I'));
            Assert.AreEqual("-E-E-O-E-", h.Guess('O'));
            Assert.AreEqual("-E-E-O-E-", h.Guess('U'));
            Assert.AreEqual("-E-E-O-ER", h.Guess('R'));
            Assert.AreEqual("-E-E-O-ER", h.Guess('N'));
            Assert.AreEqual("-E-E-O-ER", h.Guess('S'));
            Assert.AreEqual("-E-E-O-ER", h.Guess('T'));
            Assert.AreEqual("-E-ELO-ER", h.Guess('L'));
            Assert.AreEqual("-E-ELOPER", h.Guess('P'));
            Assert.AreEqual("DE-ELOPER", h.Guess('D'));
            Assert.AreEqual("DEVELOPER", h.Guess('V'));
        }

        [DataTestMethod]
        [DataRow("---------", "A")]
        [DataRow("-E-E---E-", "AE")]
        [DataRow("-E-E---E-", "AEI")]
        [DataRow("-E-E-O-E-", "AEIO")]
        [DataRow("-E-E-O-E-", "AEIOU")]
        [DataRow("-E-E-O-ER", "AEIOUR")]
        [DataRow("-E-E-O-ER", "AEIOURN")]
        [DataRow("-E-E-O-ER", "AEIOURNS")]
        [DataRow("-E-E-O-ER", "AEIOURNST")]
        [DataRow("-E-ELO-ER", "AEIOURNSTL")]
        [DataRow("-E-ELOPER", "AEIOURNSTLP")]
        [DataRow("DE-ELOPER", "AEIOURNSTLPD")]
        [DataRow("DEVELOPER", "AEIOURNSTLPDV")]
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

    }
}
