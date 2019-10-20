namespace TextAnalyzer.Resources
{
    public class Strings
    {
        public static string logo =
    @"
╔════════════════════════════════════════════════════════════════════════════════╗
║                                                                                ║
║     _                _ _          _               _____    _        _          ║
║    / \   _ __   __ _| (_)______ _| |_ ___  _ __  |_   _|__| | _____| |_ _   _  ║
║   / _ \ | '_ \ / _` | | |_  / _` | __/ _ \| '__|   | |/ _ \ |/ / __| __| | | | ║
║  / ___ \| | | | (_| | | |/ / (_| | || (_) | |      | |  __/   <\__ \ |_| |_| | ║
║ /_/   \_\_| |_|\__,_|_|_/___\__,_|\__\___/|_|      |_|\___|_|\_\___/\__|\__,_| ║
║                                                                                ║
║                                                                                ║   
╠════════════════════════╗                                                       ║
║@NiewiemTeam 2019       ║                                                       ║
╚════════════════════════╩═══════════════════════════════════════════════════════╝
";

        public static string menu =
@"
╔════════════════════════════════════════════════════════════════════════════════╗
║                                     MENU                                       ║
╠════════════════════════════════════════════════════════════════════════════════╣
║ ( 1 ) - Wybierz plik wejściowy                                                 ║
║ ( 2 ) - Zlicz liczbę samogłosek i spółgłosek w pobranym pliku                  ║
║ ( 3 ) - Zlicz liczbę wyrazów w pliku                                           ║
║ ( 4 ) - Zlicz liczbę znaków interpunkcyjnych w pliku                           ║
║ ( 5 ) - Zlicz liczbę zdań w pliku                                              ║
║ ( 6 ) - Wygeneruj raport o użyciu liter (A-Z)                                  ║
║ ( 7 ) - Zapisz statystyki z punktów 2-5 do pliku statystyki.txt                ║
║ ( 8 ) - Wyjście z programu                                                     ║
╚════════════════════════════════════════════════════════════════════════════════╝";

        public static string unknownMenuOption = "Nie ma takiej opcji w menu. Wybierz ponownie";

        public static string noFileError = "Error! Plik nie został pobrany!";
    }
}
