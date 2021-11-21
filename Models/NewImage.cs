namespace MoviesApi.Models
{
    public class NewImage
    { 
           public Guid Id{get;set;} =Guid.NewGuid(); 
           public IFormFile Data{get;set;}
           public Guid MovieID{get;set;}

    }
}