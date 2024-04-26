namespace ConsoleApp1;

public class Tafel
{
    public int Tafel_Id { get; set; }
    public int Max_Aantal_Personen { get; set; }
    public override string ToString() => $"ID = {Tafel_Id}, Maximum personen = {Max_Aantal_Personen}";
}
