using System.Drawing;

Clothes[] mas = new Clothes[4];
mas[0] = new Tshirt(ClothingSize.XXS, 2000, "red");
mas[1] = new Pants(ClothingSize.L, 6999, "blue");
mas[2] = new Skirt(ClothingSize.S, 4300, "white");
mas[3] = new Tie(ClothingSize.M, 2599, "black");

Atelier atelier = new Atelier();
atelier.dressWoman(mas, 4);

public enum ClothingSize
{
    XXS = 32,
    XS = 34,
    S = 36,
    M = 38,
    L = 40
}

public static class ClothingSizeExtension
{
    public static string GetTypeOfSize(this ClothingSize value)
    {
        if ((int)value != 32) return "adult";
        else return "children";
    }
}

interface IMenClothes
{
    string dressMan();
}

interface IWomenClothes
{
    string dressWoman();
}

abstract class Clothes
{
    public string TypeOfClothes { get; set; } = "";
    public ClothingSize ClS { get; set; }
    public int Cost { get; set; } = 0;
    public string Colour { get; set; } = "";
}

class Tshirt : Clothes, IMenClothes, IWomenClothes
{
    public Tshirt (ClothingSize cls, int cost, string colour)
    {
        TypeOfClothes = "t-shirt";
        ClS = cls;
        Cost = cost;
        Colour = colour;
    }
    public string dressMan()
    {
        return "dress man";
    }
    public string dressWoman()
    {
        return "dress woman";
    }
}

class Pants : Clothes, IMenClothes, IWomenClothes
{
    public Pants(ClothingSize cls, int cost, string colour)
    {
        TypeOfClothes = "pants";
        ClS = cls;
        Cost = cost;
        Colour = colour;
    }
    public string dressMan()
    {
        return "dress man";
    }
    public string dressWoman()
    {
        return "dress woman";
    }
}

class Skirt : Clothes, IWomenClothes
{
    public Skirt(ClothingSize cls, int cost, string colour)
    {
        TypeOfClothes = "skirt";
        ClS = cls;
        Cost = cost;
        Colour = colour;
    }
    public string dressWoman()
    {
        return "dress woman";
    }
}

class Tie : Clothes, IMenClothes
{
    public Tie(ClothingSize cls, int cost, string colour)
    {
        TypeOfClothes = "tie";
        ClS = cls;
        Cost = cost;
        Colour = colour;
    }
    public string dressMan()
    {
        return "dress man";
    }
}

class Atelier
{
    public void dressWoman(Clothes[] m, int n)
    {
        Console.WriteLine("===== Women's Clothes =====");
        for (int i = 0; i < n; i++)
        {
            if (m[i].TypeOfClothes != "tie")
            {
                Console.WriteLine($"   №{i + 1}   \nType of clothes: {m[i].TypeOfClothes}\nClothing size: {m[i].ClS}\nType of size: {m[i].ClS.GetTypeOfSize}\nCost: {m[i].Cost}\nColour: {m[i].Colour}");
            }
        }
    }
    public void dressMan(Clothes[] m, int n)
    {
        Console.WriteLine("===== Men's Clothes =====");
        for (int i = 0; i < n; i++)
        {
            if (m[i].TypeOfClothes != "skirt")
            {
                Console.WriteLine($"   №{i + 1}   \nType of clothes: {m[i].TypeOfClothes}\nClothing size: {m[i].ClS}\nType of size: {m[i].ClS.GetTypeOfSize}\nCost: {m[i].Cost}\nColour: {m[i].Colour}");
            }
        }
    }
}