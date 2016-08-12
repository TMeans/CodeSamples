using System;

public class Article: Taggable
{
    public int id { get; set; }
    public int views { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string keywords { get; set; }
    public string content { get; set; }
    public Person author { get; set; }
    public DateTime date { get; set; }
    public string imageUrl { get; set; }
    public string imageAltText { get; set; }
    public string slug { get; set; }

    public Article()
	{
	}
}
