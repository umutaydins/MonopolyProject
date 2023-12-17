using System;
using System.Collections.Generic;
public abstract class Tile
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; set; }

     /*public string GetName()
    {
        return Name;
    }*/

    
    

    protected Tile(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public abstract void LandOn(Player player);

    public void Display(string route)
    {
        Console.Write($"|{Name}|" + route);
    }

    public virtual string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";

        string result = $"+{horizontalLine}+\n" +
                        $"{verticalLine,2} Name: {Name, 15}{verticalLine, 3}\n" +
                        $"{verticalLine}{horizontalLine}\n" +
                        //$"{verticalLine,2} Description: {Description, 13}{verticalLine, 5}\n" +
                        $"{verticalLine}{horizontalLine}";

        return result;
    }
}
