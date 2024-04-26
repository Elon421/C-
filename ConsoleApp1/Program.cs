using ConsoleApp1;
using MySql.Data.MySqlClient;

Console.WriteLine("database connectie");

var connectiestring = new MySqlConnectionStringBuilder
{
    Server = "127.0.0.1",
    UserID = "root",
    Password = "",
    Database = "restaurant",
    Port = 3307
}.ToString();

Console.WriteLine(connectiestring);

var connection = new MySqlConnection(connectiestring);

connection.Open();
Console.WriteLine("Database open");

int max_aantal_personen = 30;

var newTafel = new Tafel
{
    Max_Aantal_Personen = Ask("Max personen")
};

int Ask(string question)
{
    Console.Write($"{question}?");
    _ = int.TryParse(Console.ReadLine(), out int result);
    return result;
}

InsertData(connection, newTafel.Max_Aantal_Personen);

Console.WriteLine("Nieuwe rij toegevoegd.");

Console.WriteLine("Tabelinhoud:");
foreach (var tafel in GetTables(connection))
{
    Console.WriteLine(tafel);
}

connection.Close();
Console.WriteLine("Database dicht");

void InsertData(MySqlConnection connection, int max_aantal_personen)
{
    string query = "INSERT INTO tafel (max_aantal_personen) VALUES (@max_aantal_personen)";

    using MySqlCommand command = new(query, connection);
    command.Parameters.AddWithValue("@max_aantal_personen", max_aantal_personen);
    command.ExecuteNonQuery();
}

List<Tafel> GetTables(MySqlConnection connection)
{
    var list = new List<Tafel>();
    string query = "SELECT * FROM tafel";

    using MySqlCommand command = new(query, connection);
    using MySqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        list.Add(new Tafel
        {
            Tafel_Id = (int) reader["tafel_id"],
            Max_Aantal_Personen = reader.GetInt32("max_aantal_personen")
        });
    }
    return list;
}
