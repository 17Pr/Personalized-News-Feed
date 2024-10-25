using System.Collections.Generic;

public class ArticleComparer : IComparer<Article>
{
    public int Compare(Article x, Article y)
    {
        if (x.RelevanceScore > y.RelevanceScore) return -1;
        if (x.RelevanceScore < y.RelevanceScore) return 1;
        return x.ID.CompareTo(y.ID); // To avoid duplicate keys in SortedSet
    }
}
