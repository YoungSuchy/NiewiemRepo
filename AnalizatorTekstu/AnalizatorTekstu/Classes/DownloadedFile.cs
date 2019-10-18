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
