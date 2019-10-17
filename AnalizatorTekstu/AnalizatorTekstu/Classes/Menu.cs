using TextAnalyzer.Resources;
using System;
using System.Net;

namespace TextAnalyzer.Classes
{
    public class Menu
    {
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
                        Console.WriteLine(DownloadTxtFile());
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
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

            string txt = System.IO.File.ReadAllText("textfile.txt");

            return txt;
        }
    }
}
