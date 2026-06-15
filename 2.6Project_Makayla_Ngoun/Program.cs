/*******************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: SDC320 Course Project
*
* Main application class.
*/
using System.Data.SQLite;
public class PlaylistApp
{
    public static void Main(string[] args)
    {
        const string dbName = "Playlist.db";
        Console.WriteLine("\nMakayla Ngoun - Music Playlist Application\n");

        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null)
        {
            //Creating tables for playlist and songs
            PlaylistDb.CreateTables(conn);

            //This is to grab the playlist
            Playlist myPlaylist = PlaylistDb.GetPlaylist(conn);
            
            //If no playlist exists, create playlist
            if (myPlaylist.ID == -1)
            {
                PlaylistDb.AddPlaylist(conn, new Playlist("The Best Beats Playlist"));
                myPlaylist = PlaylistDb.GetPlaylist(conn);
            }

            //Loading songs that are already saved
            List<SongInfo> savedSongs = PlaylistDb.GetSongsForPlaylist(conn, myPlaylist.ID);
            foreach (SongInfo song in savedSongs)
            {
                myPlaylist.AddSong(song);
            }

            //This is the menu creation
            PlaylistMenu menu = new PlaylistMenu(myPlaylist, conn);
            menu.Run();
        }
    }
}