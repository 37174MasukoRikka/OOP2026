
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            // 2.1.3
            var songs = new Song[] {
    new Song("Let it be", "The Beatles", 243),
    new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
    new Song("Close To You", "Carpenters", 276),
    new Song("Honesty", "Billy Joel", 231),
    new Song("I Will Always Love You", "Whitney Houston", 273),
};
            PrintSongs(songs);　//←クリックして、Alt + Enter で以下のメソッドが自動的に作成される
        }

        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                Console.WriteLine($"{song.Title},{song.ArtistName},{song.Length / 60 + ":" + (song.Length % 60).ToString("00")}");
            }
        }
    }
}

