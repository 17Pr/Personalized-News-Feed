using System.Collections.Generic;

public class Article
{
    public int ID { get; set; }
    public string Title { get; set; }
    public List<string> Topics { get; set; }
    public int Likes { get; set; }
    public int Shares { get; set; }
    public int RelevanceScore { get; set; }

    public Article(int id, string title, List<string> topics, int likes, int shares)
    {
        ID = id;
        Title = title;
        Topics = topics;
        Likes = likes;
        Shares = shares;
    }
}
