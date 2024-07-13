class Video
{
    // Attributes
    private List<Comment> _commentsList = new List<Comment>();
    private string _title;
    private string _author;
    private int _length;


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
        _length = length; // length of the video;
    }




    // Methods
    public void AddComment(string name, string text)
    {
        _commentsList.Add(new Comment(name, text));
    }




    public void DisplayVideoInfoAndComments()
    {
        Console.WriteLine("Title: " + _title);
        Console.WriteLine("Author: " + _author);
        Console.WriteLine("Length: " + _length + " seconds");


        Console.WriteLine("Comments (" + GetNumberOfComments() + ")");


        foreach (var comment in _commentsList)
        {
            comment.DisplayComment();
        }
    }




    public int GetNumberOfComments()
    {
        return _commentsList.Count;
    }
}