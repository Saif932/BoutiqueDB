using Database;

DatabaseManager db = new DatabaseManager();
await db.Connect();
db.AjouterProduit("Test", 20, 20);
db.AjouterProduit("Couscous", 19, 10);

foreach (string nom in db.RecupererNomsProduits()){
    Console.WriteLine(nom);
}