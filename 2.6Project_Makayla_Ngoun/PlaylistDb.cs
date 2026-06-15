/**********************************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: SDC320 Course Project
*
* Class to handle all interactions with the Playlist table in the
* database, including creating the table if it doesn't exist and all
* CRUD (Create, Read Update, Delete) operations on the Playlist table.
* The interactions are all done using standard SQL syntax
* that is then executed by the SQLite library.
*/
using System.Data.SQLite;

public class PlaylistDb
{
    //Create the tables if they do not exist already.
    public static void CreateTables(SQLiteConnection conn)
    {
        string sql =
            "CREATE TABLE IF NOT EXISTS Playlists (\n"
            + "    PlaylistID integer PRIMARY KEY\n"
            + "    ,Name varchar(50)\n"
            + "    ,DateCreated varchar(30));";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();

        sql =
            "CREATE TABLE IF NOT EXISTS Songs (\n"
            + "    SongID integer PRIMARY KEY\n"
            + "    ,PlaylistID integer\n"
            + "    ,Title varchar(50)\n"
            + "    ,Artist varchar(50)\n"
            + "    ,Length integer);";
        
        cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddPlaylist(SQLiteConnection conn, Playlist playlist)
    {
        string sql = string.Format(
            "INSERT INTO Playlists(Name, DateCreated) VALUES('{0}', '{1}')",
            playlist.Name, playlist.DateCreated);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static Playlist GetPlaylist(SQLiteConnection conn)
    {
        string sql = "SELECT * FROM Playlists LIMIT 1";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new Playlist(
                rdr.GetInt32(0),
                rdr.GetString(1),
                Convert.ToDateTime(rdr.GetString(2))
            );
        }
        else
        {
            return new Playlist(-1, string.Empty, DateTime.MinValue);
        }
    }

    public static void AddSong(SQLiteConnection conn, int playlistID, SongInfo song)
    {
        string sql = string.Format(
            "INSERT INTO Songs(PlaylistID, Title, Artist, Length) "
            + "VALUES({0}, '{1}', '{2}', '{3}')",
            playlistID, song.Title, song.Artist, song.Length);

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
    }

    public static List<SongInfo> GetSongsForPlaylist(SQLiteConnection conn, int playlistID)
    {
        List<SongInfo> songs = new List<SongInfo>();

        string sql = string.Format("SELECT * FROM Songs WHERE PlaylistID = {0}", playlistID);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            songs.Add(new Song(
                rdr.GetString(2),
                rdr.GetString(3),
                rdr.GetInt32(4)
            ));
        }

        return songs;
    }

    public static void DeleteSong(SQLiteConnection conn, int playlistID, string title)
    {
        string sql = string.Format(
            "DELETE FROM Songs WHERE PlaylistID = {0} AND Title = '{1}'",
            playlistID, title);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
}
