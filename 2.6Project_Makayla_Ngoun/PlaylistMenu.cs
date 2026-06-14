/***********************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: SDC320 Couse Project
* 
* This will be the class that handles the options users
* can choose from to make a selection. There will also be 
* an exit option so that users can leave the playlist. 
* This class also represents composition.
*/
public class PlaylistMenu
{
    //The current playlist
    public Playlist CurrentPlaylist { get; set; }

    //Constructor so that the menu knows what playlist to follow.
    public PlaylistMenu(Playlist playlist)
    {
        CurrentPlaylist = playlist;
    }

    //This shows the options that will be displayed to the user
    public void MenuDisplay()
    {
        Console.WriteLine("\nPlaylist Menu\n");
        Console.WriteLine("1 - View Playlist\n");
        Console.WriteLine("2 - Add a song\n");
        Console.WriteLine("3 - Remove a song\n");
        Console.WriteLine("4 - Start a song\n");
        Console.WriteLine("5 - Stop a song\n");
        Console.WriteLine("6 - Exit the playlist");
        Console.Write("Please enter your choice: ");
    }

    //Loop that takes the user's input and selects the option chosen.
    public void Run()
    {
        bool running = true;
        while (running)
        {
            MenuDisplay();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewPlaylist();
                    break;
                case "2":
                    AddSong();
                    break;
                case "3":
                    RemoveSong();
                    break;
                case "4":
                    StartSong();
                    break;
                case "5":
                    StopSong();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Thanks for using EZPlaylist. Come back again soon!");
                    break;
                default:
                    Console.WriteLine("This is not an option. Please try again and select a number 1-6.");
                    break;
            }
        }
    }

    //This is for the ViewPlaylist option and will create a display that shows all songs in the playlist.
    private void ViewPlaylist()
    {
        Console.WriteLine("\n" + CurrentPlaylist);

        foreach (SongInfo song in CurrentPlaylist.Items)
        {
            Console.WriteLine(song);
        }
    }

    //This is for the AddSong option, allowing user to input songs to the playlist.
    private void AddSong()
    {
        Console.Write("Title of song: ");
        string title = Console.ReadLine();

        Console.Write("Artist of song: ");
        string artist = Console.ReadLine();

        Console.Write("Length of the song: ");
        int length = Convert.ToInt32(Console.ReadLine());

        Song newSong = new Song(title, artist, length);
        CurrentPlaylist.AddSong(newSong);

        Console.Write("\n" + title + " has been added to your playlist.");
    }

    //This is for the removal of a song
    private void RemoveSong()
    {
        Console.Write("What's the title of the song you would like to remove?");
        string title = Console.ReadLine();
        SongInfo SongRemoval = FindSong(title);

        if (SongRemoval != null)
        {
            CurrentPlaylist.Items.Remove(SongRemoval);
            Console.WriteLine("\n" + title + " was remove from your playlist.");
        }
        else
        {
            Console.WriteLine("\nSong not found. Please try again.");
        }
    }

    //This is in place to start playing a song.
    private void StartSong()
    {
        Console.Write("What song would you like to play?");
        string title = Console.ReadLine();
        SongInfo song = FindSong(title);

        if (song != null)
        {
            Console.WriteLine("\n" + song.Start());
        }
        else
        {
            Console.WriteLine("\nSong not found, please try again.");
        }
    }
    
    //This is in place to pause the current song.
    private void StopSong()
    {
        Console.Write("What song would you like to stop?");
        string title = Console.ReadLine();

        SongInfo song = FindSong(title);

        if (song != null)
        {
            Console.WriteLine("\n" + song.Stop());
        }
        else
        {
            Console.WriteLine("\nSong not found, please try again.");
        }
    }
    //This is in place to search the palylist and case will not matter. 
    private SongInfo FindSong(string title)
    {
        foreach (SongInfo song in CurrentPlaylist.Items)
        {
            if (song.Title.ToLower() == title.ToLower())
            {
                return song;
            }
        }

        return null;
    }
}