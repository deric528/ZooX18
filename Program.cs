using System;
using System.Net;

namespace ZooX18 {
    class Program {
        private const string MainUrl = "https://media.zoox18.com/nx18/media/videos/";
        private static readonly WebClient WebClient = new WebClient();
        private static string _downloadLocation;
        private static string _command;
        private static int _vidNumber;
        private static string _name;
        private static bool _running = true;

        static void Main() {
            Console.WriteLine("Thank you for using ZooX18 downloader!");
            Console.WriteLine("To close type close application");
            Console.Write("Where should we save the videos? :: ");
            _downloadLocation = Console.ReadLine();

            while(_running) {
                Console.WriteLine("Type in close to close program.");
                Console.Write("What video should we download? :: ");
                _command = Console.ReadLine();
                if(_command == "close") {
                    _running = false;
                }
                else {
                    _vidNumber = int.Parse(_command ?? throw new InvalidOperationException());
                    Console.Write("What should the title this? :: ");
                    _name = Console.ReadLine();
                    if(_vidNumber >= 30360) {
                         WebClient.DownloadFile(new Uri($"{MainUrl}h264/{_vidNumber}_SD.mp4"), $"{_downloadLocation}/{_name}_SD.mp4");
                         Console.WriteLine($"Finished Downloading {_name}_SD.mp4");
                    }
                    else {
                        WebClient.DownloadFile(new Uri($"{MainUrl}iphone/{_vidNumber}.mp4"), $"{_downloadLocation}/{_name}.mp4");
                        Console.WriteLine($"Finished Downloading {_name}.mp4");
                    }
                }
            }
            WebClient.Dispose();
        }
    }
}
