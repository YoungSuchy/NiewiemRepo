using System;
using TextAnalyzer.Classes;

namespace TextAnalyzer
{
    class Program
    {
        static Menu menu;
        static Logo logo;

        static void Main(string[] args)
        {
            PrepareApplication();

            logo.Show();
            menu.Show();
            menu.MakeAChoice();
        }

        /// <summary>
        /// Prepares application components
        /// </summary>
        private static void PrepareApplication()
        {
            menu = new Menu();
            logo = new Logo(ConsoleColor.Yellow);
        }
    }
}
