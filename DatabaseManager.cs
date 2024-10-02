using MySqlConnector;

namespace Database
{


    public class DatabaseManager
    {

        private MySqlConnection connection;

        public async Task Connect()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "boutique",
            };

            // open a connection asynchronously
            connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            Console.WriteLine("Connexion ok");
        }

        public void AjouterProduit(string label, int price, int stock)
        {
            // inserer un produit dans la table produit
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT into produits(label,price,stock) VALUES(@label, @price, @stock)";
            command2.Parameters.AddWithValue("@label", label);
            command2.Parameters.AddWithValue("@price", price);
            command2.Parameters.AddWithValue("@stock", stock);
            command2.ExecuteNonQuery();
            Console.WriteLine("Produit inséré dans la base !");
        }

        public List<string> RecupererNomsProduits()
        {
            // on fait une liste vide pour les noms produits
            List<string> nomProduits = new List<string>();

            // recuperer tout les produits de la table produitss
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * from produits";

            // execute the command and read the results
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string label = reader.GetString("label");
                nomProduits.Add(label);
            }
            reader.Close();
            return nomProduits;
        }

    }

}
