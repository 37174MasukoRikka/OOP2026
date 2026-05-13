
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            // 2.1.3
            //var songs = new Song[] {
            //new Song("Let it be", "The Beatles", 243),
            //new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
            //new Song("Close To You", "Carpenters", 276),
            //new Song("Honesty", "Billy Joel", 231),
            //new Song("I Will Always Love You", "Whitney Houston", 273),
            //};

            var songs = new List<Song>();
            Console.WriteLine("***** 曲の登録  *****");

            while (true) {
                Console.Write("曲名：");
                string? title = Console.ReadLine();
                if (title == "end" || title == "End") {
                    break;
                }
                Console.Write("アーティスト名：");
                string? artistname = Console.ReadLine();
                Console.Write("演奏時間（秒）：");
                int length = int.Parse(Console.ReadLine());
                //int length = Console.Read();
                //Console.ReadLine(); //バッファクリア
                Song song = new Song(title, artistname, length);

                songs.Add(song);
            }
            PrintSongs(songs);
            //PrintSongs(songs); //←クリックして、Alt + Enter で以下のメソッドが自動的に作成される
        }
        private static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var song in songs) {
                var minutes = song.Length / 60;
                var seconds = song.Length % 60;
                Console.WriteLine($"{song.Title},{song.ArtistName},{minutes}:{seconds:00}");
            }
        }
    }
}

