using System.Collections.Generic;

public class NewsFeedSystem
{
    private Dictionary<int, Article> articles;
    private Graph topicGraph;

    public NewsFeedSystem()
    {
        articles = new Dictionary<int, Article>();
        topicGraph = new Graph();
    }

    public void AddArticle(Article article)
    {
        articles[article.ID] = article;
    }

    public void AddTopicRelation(string topic1, string topic2)
    {
        topicGraph.AddEdge(topic1, topic2);
    }

    public List<Article> GenerateNewsFeedForUser(User user)
    {
        SortedSet<Article> newsFeed = new SortedSet<Article>(new ArticleComparer());

        foreach (var article in articles.Values)
        {
            int relevanceScore = CalculateRelevanceScore(article, user);
            article.RelevanceScore = relevanceScore;
            newsFeed.Add(article);
        }

        return new List<Article>(newsFeed);
    }

    private int CalculateRelevanceScore(Article article, User user)
    {
        int score = 0;

        // Boost for matching user preferences
        foreach (var topic in article.Topics)
        {
            if (user.Preferences.Contains(topic))
            {
                score += 10;
            }
        }

        // Boost for article engagement
        score += article.Likes + article.Shares;

        // Boost for related content based on graph traversal
        foreach (var articleId in user.InteractedArticles)
        {
            if (topicGraph.IsRelated(article.Topics[0], articles[articleId].Topics[0]))
            {
                score += 5;
            }
        }

        return score;
    }
}
