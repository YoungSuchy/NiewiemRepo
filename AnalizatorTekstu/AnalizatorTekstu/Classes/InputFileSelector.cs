using System;
using System.IO;
using System.Net;

namespace TextAnalyzer.Classes
{
    class InputFileSelector
    {
        /// <summary>
        /// User can select if download file from web or open local file
        /// </summary>
        public void SelectInputFile()
        {
            string option;
            Console.WriteLine("Pobrać plik z internetu? [T/N]");
            option = Console.ReadLine();
            switch (option)
            {
                case "t":
                case "T":
                    this.DownloadAFile();
                    break;
                case "n":
                case "N":
                    this.OpenExistingFile();
                    break;
                default:
                    Console.WriteLine("Niepoprawna odpowiedź!. Spróbuj jeszcze raz.");
                    break;
            }
        }

        /// <summary>
        /// Downloads a file from given web path
        /// </summary>
        private void DownloadAFile()
        {
            string fileAddres;
            Console.WriteLine("Podaj adres pliku z internetu");
            fileAddres = Console.ReadLine();

            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile(fileAddres, "textfile.txt");
                Console.WriteLine("Plik został pobrany pomyślnie");
            }
            catch (Exception)
            {
                Console.WriteLine("Podany adres jest niepoprawny!");
            }
        }

        /// <summary>
        /// Opens existing file
        /// </summary>
        private void OpenExistingFile()
        {
            string filename;
            Console.WriteLine("Podaj nazwę pliku");
            filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                File.OpenRead(filename);
                Console.WriteLine("Plik został otwarty!");
            }
            else
            {
                Console.WriteLine($"Podany plik '{filename}' nie istnieje w ścieżce {Directory.GetCurrentDirectory()}");
            }
        }
    }
}
