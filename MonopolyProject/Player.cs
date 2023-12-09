using System;
using System.Collections.Generic;


public class Player {
    public string Name {get;}
    public int Money {get; private set;}

    public int Position{get; private set;}

    public Tile currentTile{get; private set;}


    public Player (string name){
        Name=name;
        Money=200;
        Position=0;

    }


// Player sınıfındaki RollDice metodu
private int RollDie()
{
    Random random = new Random();
    return random.Next(1, 7);
}

// Player sınıfındaki RollDice metodu
public int RollDice()
{
    int dice1 = RollDie();
    int dice2 = RollDie();

    Console.WriteLine($"{Name} rolled a {dice1} and {dice2}.");

    if (dice1 == dice2)
    {
        
        Console.WriteLine("Zar çifti geldi!");
        return -1;
    }

    return dice1 + dice2;
}



 public void Move(Board board) 
{

    int steps = RollDice();
    Position = (Position + steps) % board.Size;
    Console.WriteLine($"{Name} rolled a {steps} and moved to position {Position} on the board.");
    currentTile = board.tiles[Position]; 
    Console.WriteLine($"{Name} is here:   \n "+currentTile.ToString());

    // Hareket ettikten sonra tahtanın boyutunu kontrol et
    if (Position >= board.Size)
    {
        // Eğer pozisyon tahtanın boyutundan büyükse, başa dön
        Position = Position % board.Size;
    }
}


    public void BuildHouse(){

    }

    public void DrawCard(){

    }


    public void GoToJail(){

    }
    public void PayToOtherPlayer(List<Player> players)
    {
        Console.WriteLine($"{Name}, başka bir oyuncuya para verdi!");
        // Başka oyuncuya para verme işlemleri buraya eklenebilir.
    }

    public void EarnMoney(int amount)
    {
        Money += amount;
        Console.WriteLine($"{Name} earned {amount} money. Total money: {Money}");
    }

    public void deductMoney(int i)
    {
        Money= Money-i;
    }
}