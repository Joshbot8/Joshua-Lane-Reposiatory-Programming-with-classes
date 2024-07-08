using System;


    class Video
    {
        // Attributes
       // TBD - fix the setters and getter to make them public (like in our last program)
        private string _title { get; set; }
        private string _author { get; set; }
        private int _length { get; set; }

        //TBD - This needs to reference the new “Comment” class
        // List<Comment> _comments { get; set; }


        // Constructor
        public Video(string title, string description, string author, int length)
        {
            _title = title;
            _author = author;
           // TBD - Do this after Commets is created
           // _comments  =  Comments Information;
            _length  =  length; //length of the video;
        }

        // Methods
        public void AddComment()
        {
           // TBD
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
        public string _name { get; set; }
        public string _text { get; set; }

        // Methods
        public Comment( string name, string text)
        {
           _name = name;
           _text = text;
        }

        public void DisplayComment()
        {
           // TBD
        }

     }
