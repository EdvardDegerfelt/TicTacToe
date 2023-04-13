using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Tictac;
namespace Tictac;

public class Player : IColour// //Behövs Icolour-implementationen??? : PlayerMove //Ärver Playermove pga få färg till errormeddelande och kunna addera wins/ties för BO3, BO5
{
    private string name;
    public string Name { get => name; private set => name = value; }
    public int AmountOfWins { get; private set; }
    public int AmountOfTies { get; private set; }


    public Player()
    {
        this.Name = PlayerName();

    }
    public string PlayerName()
    {
        string name;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter your name: ");
        name = Console.ReadLine() ?? "";
        try
        {
            CheckForError(name);
        }
        catch (ArgumentException error)
        {
            if (error.Message == "Null")
            {
                return PlayerName("ERROR: Name must be atleast 1 character long. Please try again!");
            }
            if (error.Message == "Length Override")
            {
                return PlayerName("ERROR: Name can not contain more than 15 letters. Please try again!");
            }
            if (error.Message == "Number")
            {
                return PlayerName("ERROR: Name can not contain any numbers. Please try again!");
            }
        }
        return name;
    }
    public string PlayerName(string error)
    {
        Color(error);
        Console.WriteLine(error);
        return PlayerName();
    }
    public string GetPlayerName() => this.Name;

    public  string CheckForError(string name)
    {
        if (name.Any(char.IsDigit))
        {
            throw new ArgumentException("Number");
        }
        if (name.Length > 15)
        {
            throw new ArgumentException("Length Override");
        }
        if (name == null || name.Length == 0)
        {
            throw new ArgumentException("Null");
        }
        return name;
    }

    public string[] Color(string[] array)//Onödig implementation, här för att få in abstract injection till gameboard
    {
		Console.ForegroundColor = ConsoleColor.White;
        return array;
	}
	public void AddWin() => this.AmountOfWins++;
    public int GetWin(Player player) => this.AmountOfWins;    //Kanske göra om föra o se hur många vinster man har totalt?
    public void AddTie() => this.AmountOfTies++;
    public int GetTie() => this.AmountOfTies;

    public string Color(string input)//Overridas från Colour för att få Errormeddelanden röda (gammal?)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return input;
    }
}