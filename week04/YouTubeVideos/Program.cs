using System;

class Program
{
    static void Main(string[] args)
    {
        Video firstVideo = new Video("The Sunken City", "Marco Traveler", 767);
        Video secondVideo = new Video("How to Cook the Perfect Pan Pizza", "Cooking with Julia", 495);
        Video thirdVideo = new Video("Fun with Static Electricity", "Easy Science", 903);
        Video fourthVideo = new Video("Dolomites Sunset Timelapse", "Alpine Visions", 402);

        firstVideo.AddComment("Sara_Explorer", "Such breathtaking footage! It feels like a sci‑fi movie.");
        firstVideo.AddComment("LucaDive92", "I’m a diver and I can confirm: the atmosphere underwater is truly magical.");
        firstVideo.AddComment("ElenaArt", "This makes me want to paint those ruins.");

        secondVideo.AddComment("FoodieMax", "Tried it last night, amazing result! Crispy yet fluffy.");
        secondVideo.AddComment("AnnaSmile", "Finally a simple recipe without an oven, thank you!");
        secondVideo.AddComment("ChefLorenzo", "Tip: drizzle a little oil on the edge to make it even crunchier.");

        thirdVideo.AddComment("TechKid", "Love when the balloon makes hair stand up!");
        thirdVideo.AddComment("MartaScience", "Perfect way to explain physics to kids, clear and fun.");
        thirdVideo.AddComment("RobyGeek", "Could you do an episode on electromagnetism too?");
        thirdVideo.AddComment("Vale88", "This brought back memories of school labs, pure nostalgia.");

        fourthVideo.AddComment("ClimberTom", "Every time I see the Dolomites I get emotional, thanks for this video.");
        fourthVideo.AddComment("GiadaPhoto", "The changing light minute by minute is pure poetry.");
        fourthVideo.AddComment("AndreaDrone", "Stunning shots, which drone did you use?");

        List<Video> videos = new List<Video>
        {
            firstVideo,
            secondVideo,
            thirdVideo,
            fourthVideo
        };

        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Total Comments: {video.GetCommentCount()}");
            Console.WriteLine(video.GetDisplayComments());
            Console.WriteLine();
        }
    }
}