using System;




//main
class Program ()
{
   
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");


        List<Video> _videoList = new List<Video>();


        string localTitle = "Title 1";
        string localAuthor = "Author 1";
        int localLength = 0;



        Video video1 = new Video(localTitle, localAuthor, localLength);
        string _commentAuthor = "CommentAuthor1";
        string _commentText = "CommentText1";

        video1.AddComment(_commentAuthor, _commentText);

        video1.AddComment("Howdy im the second author","I am the text :D");


        _videoList.Add(video1);
       
       int temp = _videoList.Count();

       video1.GetNumberOfComments();

       Console.WriteLine("Comments ("+ video1.GetNumberOfComments() +")");
    }
}
    class Video
    {
        // Attributes
        List<Comment> _commentsList = new List<Comment>();




        private string _title ;
        private string _author ;
        private int _length ;




        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }
        public string Author
        {
            get { return _author; }
            private set { _author = value; }
        }
        public int Length
        {
            get { return _length; }
            private set { _length = value; }
        }


        // Constructor
        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length  =  length; //length of the video;
        }




        // Methods
        public void AddComment(string name, string text)
        {
           _commentsList.Add(new Comment(name, text));
        }




        public void DisplayVideoInfoAndComments()
        {
            //TBD
        }




        public int GetNumberOfComments()
        {
            return _commentsList.Count;
        }




       
    }




    class Comment
    {
        // Attributes
        private string _commentAuthor ;
        private string _commentText ;




        public string Name
        {
            get { return _commentAuthor; }
            private set { _commentAuthor = value; }
        }
        public string Text
        {
            get { return _commentText; }
            private set { _commentText = value; }
        }








        // Methods
        public Comment( string name, string text)
        {
           _commentAuthor = name;
           _commentText = text;
        }



        public void DisplayComment()
        {
           Console.WriteLine( _commentAuthor + ": " + _commentText);
        }

     }

