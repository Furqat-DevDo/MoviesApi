namespace MoviesApi.Enteties
{
    public class Image
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID{get;set;}=Guid.NewGuid();
        public byte[] Data {get;set;}
        [Required]
        public Guid MovieId{get;set;}
        [Obsolete]
        public Image() {}
        public Image(Guid movieid)
        {
           MovieId=movieid ;
        }
            
        
       
    }
}