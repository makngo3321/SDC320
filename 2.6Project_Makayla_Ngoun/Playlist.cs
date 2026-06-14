/************************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: Course Project SDC320
*
* This class creates a list that will hold all playlist
* information. It demonstrates that this class uses 
* composition. It will also include a method that
* gives an option to add a song. 
*/
public class Playlist
{
    //This is the playlist name and the name can be altered.
    public string Name { get; set; }

    //This shows when the playlist was created.
    public DateTime DateCreated  { get; private set; }

    //This is the list that will hold the songs in the playlist
    public List<SongInfo> Items { get; private set; }

    //This will count the number of songs in the playlist.
    public int TotalSongs
    {
        get { return Items.Count; }
    }

    //This is the constructor and it will set a name, as well as
    // set when the playlist was created and intialize the list.
    public Playlist(string name)
    {
        Name = name;
        DateCreated = DateTime.Now;
        Items = new List<SongInfo>();
    }

    //Add song to playlist
    public void AddSong(SongInfo song)
    {
        Items.Add(song);
    }

    //The ToString override that will provide the output.
    public override string ToString()
    {
        return
            "Playlist: " + Name + "\n" +
            "Date Created: " + DateCreated + "\n" +
            "Total Song Count: " + TotalSongs + "\n";
    }
}