using System;
using System.Collections.Generic;

public abstract class Taggable
{
    public HashSet<string> tags { get; set; }

    public Taggable()
	{
	}
}
