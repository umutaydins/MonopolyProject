using System;
using System.Collections.Generic;
public abstract class Tile
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }

     public string GetName()
    {
        return Name;
    }

    // Setter method for 'name' attribute
    

    protected Tile(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public abstract void LandOn(Player player);


    public virtual string ToString()
    {
        string horizontalLine = new string('-', 30);
        string verticalLine = "|";

        string result = $"+{horizontalLine}+\n" +
                        $"{verticalLine,2} Name: {Name, 15}{verticalLine, 5}\n" +
                        $"{verticalLine}{horizontalLine}{verticalLine, 5}\n" +
                        $"{verticalLine,2} Description: {Description, 13}{verticalLine, 5}\n" +
                        $"{verticalLine}{horizontalLine}{verticalLine, 5}";

        return result;
    }
}
