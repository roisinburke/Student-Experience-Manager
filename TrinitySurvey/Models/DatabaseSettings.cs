namespace TrinitySurvey.Models
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string QuestionsCollectionName { get; set; }
    }

    

    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string QuestionsCollectionName { get; set; }
    }
}