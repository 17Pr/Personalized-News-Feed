using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        NewsFeedSystem system = new NewsFeedSystem();

        // Adding articles
        system.AddArticle(new Article(1, "Tech News", new List<string> { "Technology" }, 100, 50));
        system.AddArticle(new Article(2, "Health Tips", new List<string> { "Health" }, 70, 20));
        system.AddArticle(new Article(3, "AI Trends", new List<string> { "AI", "Technology" }, 150, 80));

        // Adding relationships between topics
        system.AddTopicRelation("Technology", "AI");

        // Adding user
        User user = new User(1, new List<string> { "Technology", "Health" }, new List<int> { 1 });

        // Generate personalized news feed
        List<Article> personalizedFeed = system.GenerateNewsFeedForUser(user);

        // Output the news feed
        Console.WriteLine("Personalized News Feed:");
        foreach (var article in personalizedFeed)
        {
            Console.WriteLine($"Title: {article.Title}, Relevance Score: {article.RelevanceScore}");
        }
    }
}

