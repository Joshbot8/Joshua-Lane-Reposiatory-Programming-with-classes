class Comment
{
    // Attributes
    private string _commentAuthor;
    private string _commentText;




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




    // Constructor
    public Comment(string name, string text)
    {
        _commentAuthor = name;
        _commentText = text;
    }




    public void DisplayComment()
    {
        Console.WriteLine(_commentAuthor + ": " + _commentText);
    }
}