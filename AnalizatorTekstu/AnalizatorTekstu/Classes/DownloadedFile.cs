using System;
using System.IO;
using System.Linq;
using TextAnalyzer.Resources;

namespace TextAnalyzer.Classes
{
    class DownloadedFile
    {
        private string filePath = "textfile.txt";

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
