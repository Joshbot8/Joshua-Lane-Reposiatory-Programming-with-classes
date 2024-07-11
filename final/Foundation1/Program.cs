using System;
using System.Collections.Generic;




class Program
{
    static void Main(string[] args)
    {




        List<Video> _videoList = new List<Video>();




        string localTitle = "Title 1";
        string localAuthor = "Author 1";
        int localLength = 0;




        // Create three videos
        Video video1 = new Video(localTitle, localAuthor, localLength);
        Video video2 = new Video("Title 2", "Author 2", 150);
        Video video3 = new Video("Title 3", "Author 3", 180);




        // test video1 with zero comments




        // Add two comments to video2
        video2.AddComment("CommentAuthor1", "Great video!");
        video2.AddComment("CommentAuthor2", "Very informative.");




        // Add three comments to video3
        video3.AddComment("CommentAuthor1", "Nice tutorial.");
        video3.AddComment("CommentAuthor2", "Loved it!");
        video3.AddComment("CommentAuthor3", "Keep up the good work.");




        // Add videos to the list
        _videoList.Add(video1);
        _videoList.Add(video2);
        _videoList.Add(video3);




        // Iterate through the list of videos and display details
        foreach (var video in _videoList)
        {
            video.DisplayVideoInfoAndComments();
            Console.WriteLine("\n");            
        }
    }
}