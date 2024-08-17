namespace todoApi.Models
{
    /*
        The DbSetting model is designed to encapsulate the connection string for our database.
        It conatins a single property: ConnectionString, which will store the actual connection string value.

    */
    public class DbSetting
    {
        public string ConnectionString { get; set; }
    }
}
