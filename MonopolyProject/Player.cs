using System;
using System.Collections.Generic;


public class Player {
    public string Name {get;}
    public int Money {get; private set;}

    public int Position{get; private set;}

    public Tile currentTile{get; private set;}

    public List<Tile> playerCardList{get; private set;}


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
    public void PayToOtherPlayer(Player player,int amount)
    {
        Console.WriteLine($"{Name}, {player.Name}  oyuncusuna para verdi!");
        Money = Money - amount;
        player.Money = player.Money + amount; // Methodlarla da yapulabilir 
        
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
    public int getUtilityCardCount(){  // Maksimum 2 kartı olabilir zaten ama aklıma efektif çözüm gelmedi 
        int counter = 0;
        for (int i = 0 ; i < playerCardList.Count; i++){
            if(playerCardList[i]is UtilityTile utilityTile){
                counter++;

            }
        }
        return counter;
    }



}