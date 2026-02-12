using Zkouseni;

Console.WriteLine("Hello");

// stahni balicek mysqlconnector hotovo
// precti si heslo
Helpers.ReadSecret();


string ServerDomain = "vydb1.spsmb.cz";
string Username = "radek.pelikan";
string Password = "heslo123";
string Database = "student_radek.pelikan_duolingo";

string connectionString = $"Server={ServerDomain};Database={Database};User={Username};Password={Password};SslMode=None;";
MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString);
connection.Open();
MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("SELECT * FROM users" ,connection);

// ziskej nejake zaznamy ze sve databaze. Uloz je do recordu
// vypis recordy

