using System;
using System.Collections.Generic;
// Abstract base class for representing tiles on the game board
public abstract class Tile
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }

    protected Tile(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    // Abstract method to be implemented by derived classes
    // Represents the action when a player lands on this tile
    public abstract void LandOn(Player player);

    public virtual void Display(string route,int position)
    {
        Console.Write($"|{position}-{Name}|{route}");
    }

    public virtual string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";

        string result = $"+{horizontalLine}+\n" +
                        $"{verticalLine,2} Name: {Name, 15}{verticalLine, 3}\n" +
                        $"{verticalLine}{horizontalLine}\n" +
                        $"{verticalLine,2} Description: {Description, 13}{verticalLine, 5}\n" +
                        $"{verticalLine}{horizontalLine}";

        return result;
    }
}
