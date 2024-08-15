namespace app.config
{
    public class MongoDBSettings
    {
        public required string ConnectionString { get; set; }
        public required string DatabaseName { get; set; }
        public required string ProductCollectionName { get; set; }
    }
}