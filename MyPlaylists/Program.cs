using MyPlaylists.Menus;
using System.Text;
using MyPlaylists.Models;
using MyPlaylists;

//C:\Users\User\AppData\Local\MyPlaylists.db
while (true)
{
    try
    {
        MainMenu menu = new MainMenu();
        menu.Menu();
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        var message = ex.Message;
        CenterTextMethod.CenterText(message, 1, 1);
        Console.WriteLine(ex.Message);
        Thread.Sleep(2000);
        Console.ForegroundColor = ConsoleColor.Gray;
        //MainMenu menu2 = new MainMenu();
        //menu2.Menu();
    }
}

//using (MyPlaylistsDbContext db = new MyPlaylistsDbContext())
//{
//    PlaylistSong playlistSong = new PlaylistSong();
//    playlistSong.SongId = 10;
//    playlistSong.PlaylistId = 1;
//    db.PlaylistsSongs.Add(playlistSong);
//    db.SaveChanges();
//}

//Song a = new Song();
//a.SongName = "a";
//a.Url = "a";
//a.Artist = "a";
//a.Genre = "a";

//using(MyPlaylistsDbContext db = new MyPlaylistsDbContext())
//{
//    PlaylistSong b = new PlaylistSong();
//    var songCheck = db.Songs.Where(song => song.SongName == "a" && song.Artist == "a" && song.Genre == "a" && song.Url == "a").ToList();
//    if(songCheck.Count == 0)
//    {
//        b.PlaylistId = 2;
//        b.Song = a;
//    }
//    else
//    {
//        b.PlaylistId = 2;
//        b.SongId = songCheck[0].SongId;
//    }
//    db.PlaylistsSongs.Add(b);
//    db.SaveChanges();
//}





