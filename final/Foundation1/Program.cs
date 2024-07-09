using System;

//main
class Program ()
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");
        List<Video> _videoList = new List<Video>();
    }

}

    class Video
    {
        // Attributes
        List<Comment> _comments = new List<Comment>();

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
        public Video(string title, string description, string author, int length)
        {
            _title = title;
            _author = author;
            _length  =  length; //length of the video;
        }

        // Methods
        public void AddComment(string name, string text)
        {
           _comments.Add(new Comment(name, text));
        }

        public void DisplayVideoInfoAndComments()
        {
            //TBD
        }

        public void GetNumberOfComments()
        {
            //TBD
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
           // TBD
        }

     }

