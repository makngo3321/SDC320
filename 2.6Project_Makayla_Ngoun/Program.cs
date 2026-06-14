/*******************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: SDC320 Course Project
*
* Main application class.
*/
public class PlaylistApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\nMakayla Ngoun - Music Playlist App - Course Project SDC320\n");

        //This creates a new playlist
        Playlist myPlaylist = new Playlist("The Best Beats Playlist");

        //Adding songs
        myPlaylist.AddSong(new Song("We Ride", "Rihanna", 3));
        myPlaylist.AddSong(new Song("Wait for You", "Elliott Yamin", 4));
        myPlaylist.AddSong(new Song("Energy", "Keri Hilson", 3));
        myPlaylist.AddSong(new Song("Soulja Girl", "Soulja Boy", 2));

        //Creates the menu
        PlaylistMenu menu = new PlaylistMenu(myPlaylist);
        menu.Run(); 
    }
}