using System.Collections.Generic;

public class User
{
    public int ID { get; set; }
    public List<string> Preferences { get; set; }
    public List<int> InteractedArticles { get; set; }

    public User(int id, List<string> preferences, List<int> interactedArticles)
    {
        ID = id;
        Preferences = preferences;
        InteractedArticles = interactedArticles;
    }
}
