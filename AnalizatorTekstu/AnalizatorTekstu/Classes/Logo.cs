using TextAnalyzer.Resources;
using System;

namespace TextAnalyzer.Classes
{
    class Logo
    {
        /// <summary>
        /// The logo color.
        /// </summary>
        public ConsoleColor LogoColor { private get; set; }

        /// <summary>
        /// Creates logo for the application
        /// </summary>
        /// <param name="logoColor">Color of the logo. Default gray</param>
        public Logo(ConsoleColor logoColor = ConsoleColor.Gray)
        {
            this.LogoColor = logoColor;
        }

        /// <summary>
        /// Shows the logo on the console
        /// </summary>
        public void Show()
        {
            Console.ForegroundColor = LogoColor;
            Console.WriteLine(Strings.logo);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
