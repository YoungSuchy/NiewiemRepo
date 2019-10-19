using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextAnalyzer.Resources;

namespace TextAnalyzer.Classes
{
    class DownloadedFile
    {
        private string filePath = "textfile.txt";

        /// <summary>
        /// Counts individual letter from downloaded file and prints result to screen.
        /// </summary>
        /// <param name="file">Downloaded file as string</param>
        private void CountIndividualLetters(string file)
        {
            if (file != null)
            {
                Dictionary<char, int> alphabetDictionary = new Dictionary<char, int>();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                foreach (char c in alphabet)
                {
                    alphabetDictionary.Add(c, 0);
                }

                foreach (char c in file)
                {
                    if (((byte)c >= 97 && (byte)c <= 122) || ((byte)c >= 65 && (byte)c <= 90))
                    {
                        alphabetDictionary[char.ToUpper(c)]++;
                    }
                }

                foreach (var item in alphabetDictionary)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

        /// <summary>
        /// Counts all letters in downloaded file
        /// </summary>
        public void CountAllLetters()
        {
            var file = GetDownlodedFile();
            if (file != null)
            {
                int numberOfChars = file.Count(
                    c => ((byte)c >= 97 && (byte)c <= 122) ||
                    ((byte)c >= 65 && (byte)c <= 90)
                    );
                Console.WriteLine($"Liczba liter w pliku: {numberOfChars}");
            }
        }

        /// <summary>
        /// Counts individual letter from downloaded file and prints result to screen
        /// </summary>
        public void CountIndividualLetters()
        {
            string file = GetDownlodedFile();
            this.CountIndividualLetters(file);
        }

        /// <summary>
        /// Counts all words in dowloaded file
        /// </summary>
        public void CountAllWords()
        {
            var file = GetDownlodedFile();
            if (file != null)
            {
                int numberOfWords = 0, index = 0;

                while (index < file.Length && char.IsWhiteSpace(file[index]))
                    index++;

                while (index < file.Length)
                {
                    while (index < file.Length && !char.IsWhiteSpace(file[index]))
                        index++;

                    numberOfWords++;

                    while (index < file.Length && char.IsWhiteSpace(file[index]))
                        index++;
                }
                Console.WriteLine($"Liczba slow w pliku: {numberOfWords}");

            }
        }

        /// <summary>
        /// Count punctuation marks in dowloaded file
        /// </summary>
        public void CountPunctuationMarks()
        {
            var file = GetDownlodedFile();
            if (file != null)
            {
                int numberOfPunctuationMarks = 0;
                int index = 0;

                while (index < file.Length)
                {
                    if(char.IsPunctuation(file[index]))
                    {
                        numberOfPunctuationMarks++;
                        index++;
                    } index++;
                }
                Console.WriteLine($"Liczba znaków interpunkcyjnych w pliku: {numberOfPunctuationMarks}");
            }
        }

        /// <summary>
        /// Count sentences in dowloaded file
        /// </summary>
        public void CountSentences()
        {
            var file = GetDownlodedFile();
            if (file != null)
            {
                int numberOfSentences = 0;
                int index = 0;
                

                while (index < file.Length)
                {
                    if (file[index].Equals('.'))
                    {   
                        if (file[index - 1].Equals('.')) index++;
                        numberOfSentences++;
                        index++;
                    }
                    if (file[index].Equals(',') || file[index].Equals(';') || file[index].Equals('?') || file[index].Equals('!'))
                    {
                        numberOfSentences++;
                        index++;
                    }
                    index++;
                }
                Console.WriteLine($"Liczba zdań w pliku: {numberOfSentences}");
            }
        }

        /// <summary>
        /// Opens downloaded file and returns it
        /// </summary>
        /// <returns>Downloaded file as string</returns>
        private string GetDownlodedFile()
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine(Strings.noFileError);
                return null;
            }
        }
    }
}
