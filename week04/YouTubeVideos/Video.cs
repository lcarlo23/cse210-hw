public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public string GetDisplayText()
    {
        return $"""
        Title: {_title}
        Author: {_author}
        Length: {_length} secs
        """;
    }

    public void AddComment(string name, string comment)
    {
        Comment newComment = new Comment(name, comment);
        _comments.Add(newComment);
    }

    public string GetDisplayComments()
    {
        string commentList = "";

        foreach (Comment comment in _comments)
        {
            commentList += $"""
            {comment.GetDisplayText()}

            """;
        }

        return commentList;
    }

    public int GetCommentCount()
    {
        return _comments.Count();
    }
}