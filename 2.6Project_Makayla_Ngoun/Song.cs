/************************************
* Name: Makayla Ngoun
* Date: 6/14/2026
* Assignment: Course Project SDC320
*
* This class demonstrates inheritance. It will inherit information
* from SongInfo and implement the Start and Stop feature. 
*/
public class Song : SongInfo
{
    //Constructor
    public Song(string title, string artist, int length)
        : base(title, artist, length)
    {
    }

    //This will start the song and output the message to let the
    //user know what song is playing. 
     public override string Start()
    {
        CurrentlyPlaying = true;
        return "Song playing: " + Title + " by " + Artist + "\nLength: " + Length + " minutes";
    }

    //This will stop the song and output a message to inform
    // the user the song that is paused.
    public override string Stop()
    {
        CurrentlyPlaying = false;
        return Title + "is paused.";
    }
}