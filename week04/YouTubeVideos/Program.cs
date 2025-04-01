// Program.cs
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Amazing Space Facts", "Cosmic Explorer", 360);
        Video video2 = new Video("Learn Python in 10 Minutes", "Code Master", 600);
        Video video3 = new Video("Delicious Chocolate Cake Recipe", "Baking Queen", 480);
        Video video4 = new Video("Funny Cat Compilation", "Laugh Factory", 240);

        // Add comments to video 1
        video1.AddComment(new Comment("User123", "Great video! I learned a lot."));
        video1.AddComment(new Comment("SpaceFan", "The visuals are stunning!"));
        video1.AddComment(new Comment("CuriousMind", "Could you make more videos on black holes?"));
        video1.AddComment(new Comment("AstroGuy", "Awesome facts!"));

        // Add comments to video 2
        video2.AddComment(new Comment("CoderBeginner", "This was very helpful, thank you!"));
        video2.AddComment(new Comment("PythonLover", "Excellent introduction to Python."));
        video2.AddComment(new Comment("TechGuru", "Well-explained concepts."));

        // Add comments to video 3
        video3.AddComment(new Comment("SweetTooth", "I'm definitely trying this recipe!"));
        video3.AddComment(new Comment("BakeLover", "Looks so yummy!"));
        video3.AddComment(new Comment("ChocolateAddict", "My favorite!"));
        video3.AddComment(new Comment("HomeBaker", "Thanks for sharing!"));

        // Add comments to video 4
        video4.AddComment(new Comment("CatFanatic", "So cute!"));
        video4.AddComment(new Comment("FunnyGuy", "I laughed so hard!"));
        video4.AddComment(new Comment("AnimalLover", "These cats are hilarious!"));
        video4.AddComment(new Comment("MemeLord", "Purrfect!"));

        // Create a list of videos
        List<Video> videos = new List<Video>() { video1, video2, video3, video4 };

        // Iterate through the list of videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("End of video list.");
    }
}