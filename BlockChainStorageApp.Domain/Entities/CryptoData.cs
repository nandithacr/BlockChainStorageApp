namespace BlockChainStorageApp.Domain.Entities
{
    public class CryptoData
    {
        public int Id { get; set; }
        public string Symbol { get; set; } 
        public string Name { get; set; } 
        public long Height { get; set; }  
        public string Hash { get; set; }  
        public DateTime Time { get; set; }  
        public string Latest_Url { get; set; }  
        public string Previous_Hash { get; set; }  
        public string Previous_Url { get; set; }  
        public int Peer_Count { get; set; }  
        public int Unconfirmed_Count { get; set; } 
        public int High_Fee_Per_Kb { get; set; }  
        public int Medium_Fee_Per_Kb { get; set; } 
        public int Low_Fee_Per_Kb { get; set; }  
        public long Last_Fork_Height { get; set; }  
        public string Last_Fork_Hash { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // For history
    }
}
