﻿using TextAnalyzer.Resources;
using System;
using System.Net;
using System.IO;

namespace TextAnalyzer.Classes
{
    public class Menu
    {
        /// <summary>
        /// DownloadedFile instance.
        /// </summary>
        private DownloadedFile TextFile { get; set; }

        /// <summary>
        /// FileDownloader instance.
        /// </summary>
        private InputFileSelector FileDownloader { get; set; }

        /// <summary>
        /// Creates new instance of the Menu
        /// </summary>
        public Menu()
        {
            this.TextFile = new DownloadedFile();
            this.FileDownloader = new InputFileSelector();
        }
        /// <summary>
        /// Shows menu on the console
        /// </summary>
        public void Show()
        {
            Console.WriteLine(Strings.menu);
        }

        /// <summary>
        /// Gets input from user and runs menu option.
        /// </summary>
        public void MakeAChoice()
        {
            bool isMenu = true;
            int menuOption = 0;
            while (isMenu)
            {
                Console.Write("Czekam na input: ");
                try
                {
                    menuOption = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawny format. Wpisz cyfrę od 1 do 8");
                    MakeAChoice();
                }

                switch (menuOption)
                {
                    case 1:
                        this.FileDownloader.SelectInputFile();
                        break;
                    case 2:
                        this.TextFile.CountVovelsAndConsonants();
                        break;
                    case 3:
                        this.TextFile.CountAllWords();
                        break;
                    case 4:
                        this.TextFile.CountPunctuationMarks();
                        break;
                    case 5:
                        this.TextFile.CountSentences();
                        break;
                    case 6:
                        this.TextFile.CountIndividualLetters();
                        break;
                    case 7:
                        this.TextFile.SaveStatistics();
                        break;
                    case 8:
                        File.Delete(Path.Combine("textfile.txt"));
                        File.Delete(Path.Combine("statystyki.txt"));
                        Environment.Exit(0);

                        break;
                    default:
                        Console.WriteLine(Strings.unknownMenuOption);
                        break;
                }
                this.Show();
            }
        }

        public String DownloadTxtFile()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://s3.zylowski.net/public/input/1.txt", "textfile.txt");

            return File.ReadAllText("textfile.txt");
        }
    }
}
