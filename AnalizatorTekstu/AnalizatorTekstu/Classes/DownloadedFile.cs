﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextAnalyzer.Resources;

namespace TextAnalyzer.Classes
{
    class DownloadedFile
    {
        private string filePath = "textfile.txt";
        private string stats;
        int numberOfSentences, numberOfWords;

        private int numberOfChars;


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

                if(numberOfSentences != 0)
                    Console.WriteLine($"Liczba zdań w pliku: {numberOfSentences}");
                else
                    Console.WriteLine($"Liczba zdań w pliku nie została policzona!");
                

                if (numberOfWords != 0)
                {
                    Console.WriteLine($"Liczba slow w pliku: {numberOfWords}");
                }
                else
                {
                    Console.WriteLine($"Liczba wyrazów w pliku nie zostala policzona!");
                }
                Console.WriteLine("Samogłoski:");
                foreach (var item in alphabetDictionary)
                {
                    if (ifCharisVovel(item.Key))
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                        stats += ($"{item.Key}: {item.Value}\n");
                    }
                }
                Console.WriteLine("Spółgłoski");
                foreach (var item in alphabetDictionary)
                {
                    if (ifCharisVovel(item.Key) == false)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                        stats += ($"{item.Key}: {item.Value}\n");
                    }
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
                stats += ($"Liczba liter w pliku: {numberOfChars}\n");
            }
        }

        /// <summary>
        /// Seperately counting letters as vovels and consonants
        /// </summary>
        public void CountVovelsAndConsonants()
        {
            var file = GetDownlodedFile();
            if (file != null)
            {
                int numberOfChars = file.Count(
                    c => ((byte)c >= 97 && (byte)c <= 122) ||
                    ((byte)c >= 65 && (byte)c <= 90)
                );

                int numberOfVovels = file.Count( c => (ifCharisVovel(c).Equals(true)));
                int numberOfConsonants = numberOfChars-numberOfVovels;

                Console.WriteLine($"Liczba samogłosek: {numberOfVovels}");
                Console.WriteLine($"LIczba spółgłosek: {numberOfConsonants}");
                stats += ($"Liczba samogłosek: {numberOfVovels}\n"+$"LIczba spółgłosek: { numberOfConsonants}\n");
            }
        }

        /// <summary>
        /// Check if letter is vovel or consonant
        /// </summary>
        public bool ifCharisVovel(char c)
        {
            char[] vovels = { 'A', 'E', 'I', 'O', 'U', 'Y', 'a', 'e', 'i', 'o', 'u', 'y'};
            if (vovels.Contains(c)) return true;
            else return false;
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
        /// Counts all words in dowloaded file, excluding one letter words
        /// </summary>
        public void CountAllWords()
        {
            var file = GetDownlodedFile();
            if (file != null)
            {
                int index = 0;
                numberOfWords = 0; 

                while (index < file.Length && char.IsWhiteSpace(file[index]))
                    index++;

                while (index < file.Length)
                {
                    while (index < file.Length && !char.IsWhiteSpace(file[index]))
                        index++;

                    if (!char.IsWhiteSpace(file[index - 2])) numberOfWords++;
                    if (char.IsWhiteSpace(file[index - 2]) && char.IsNumber(file[index - 1])) numberOfWords++;

                    while (index < file.Length && char.IsWhiteSpace(file[index]))
                        index++;
                }
                Console.WriteLine($"Liczba slow w pliku (bez wyrazów jednoliterowych): {numberOfWords}");
                stats += ($"Liczba slow w pliku (bez wyrazów jednoliterowych): {numberOfWords}\n");
            }
        }

        /// <summary>
        /// Count punctuation marks in dowloaded file a ads
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
                    if(file[index] == '?' || file[index] == '.')
                    {
                        numberOfPunctuationMarks++;
                        index++;
                    } index++;
                }
                Console.WriteLine($"Liczba znaków interpunkcyjnych w pliku: {numberOfPunctuationMarks}");
                stats += ($"Liczba znaków interpunkcyjnych w pliku: {numberOfPunctuationMarks}\n");
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
                numberOfSentences = 0;
                int index = 0;
                

                while (index < file.Length)
                {
                    if (file[index].Equals('.'))
                    {   
                        if (file[index - 1].Equals('.')) index++;
                        numberOfSentences++;
                        index++;
                    }
                    if (file[index].Equals('?'))
                    {
                        numberOfSentences++;
                        index++;
                    }
                    index++;
                }
                Console.WriteLine($"Liczba zdań w pliku: {numberOfSentences}");
                stats += ($"Liczba zdań w pliku: {numberOfSentences}\n");
            }
        }

        /// <summary>
        /// Save statistics to file
        /// </summary>
        public void SaveStatistics()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("statystyki.txt")))
            {
                outputFile.WriteLine(stats);
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
