using MyPlaylists.Menus;
using System.Text;
using MyPlaylists.Models;
using MyPlaylists;

// C:\Users\User\AppData\Local\MyPlaylists.db
MainMenu menu = new MainMenu();
menu.Menu();

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





