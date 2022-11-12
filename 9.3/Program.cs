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
        if ((int)value != 32) return "Взрослый размер";
        else return "Детский размер";
    }
}

interface IMenClothes
{
    void dressMan();
}

interface IWomenClothes
{
    void dressWoman();
}

abstract class Clothes
{
    public ClothingSize ClS { get; set; }
    public int Cost { get; set; } = 0;
    public string Colour { get; set; } = "";
}