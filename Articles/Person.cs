using System;

public class Person
{
    public int id { get; set; }
    public string first { get; set; }
    public string middle { get; set; }
    public string last { get; set; }
    public string imgUrl { get; set; }
    public string title { get; set; }

    public Person()
	{
        first = first.Trim();
        middle = middle.Trim();
        last = last.Trim();
	}

    public string fullname()
    {
        return String.Format("{0} {1}", first, last);
    }
}
