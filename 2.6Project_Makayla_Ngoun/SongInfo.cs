/************************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: Course Project SDC320
*
* This class demonstrates the use of abstraction. It will implement
* the interface IMusic. It also includes public get and protect sets.
*/
public abstract class SongInfo : IMusic
{
    //Title of song
    public string Title { get; protected set; }
    //Artist of the song
    public string Artist { get; protected set; }
    //Length of the song
    public int Length { get; protected set; }
    //Bool for the song that is currently playing
    public bool CurrentlyPlaying { get; protected set; }

    //Protected constructor that sets CurrentlyPlaying automatically to false
    protected SongInfo(string title, string artist, int length)
    {
        Title = title;
        Artist = artist;
        Length = length;
        CurrentlyPlaying = false;
    }

    //This includes an abstract method from the interface, but Song will
    //do the implementation. 
    public abstract string Start();
    public abstract string Stop();

    //ToString override that will create output
    public override string ToString()
    {
        string status = CurrentlyPlaying ? "playing" : "not playing";
        return
            "Title: " + Title + "\n" +
            "Artist: " + Artist + "\n" +
            "Length: " + Length + "\n" +
            "Song playing currently: " + status + "\n";
    }
}