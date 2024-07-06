public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;
    private bool _isCompleted;


    public string Title
    {
        get { return _title; }
        protected set { _title = value; }
    }


    public string Description
    {
        get { return _description; }
        protected set { _description = value; }
    }


    public int Points
    {
        get { return _points; }
        protected set { _points = value; }
    }


    public bool IsCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; }
    }


    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _isCompleted = false;
    }


    public abstract void Complete();
    public abstract void DisplayStatus();
}
