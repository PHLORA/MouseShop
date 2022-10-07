namespace BookShop.Domain.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public bool isDel { get; set; }
    
    public string Author { get; set; }
    
    public string Genre { get; set; }
    
    public string Language { get; set; }
    
    public string Cover { get; set; }

    public IFormFile Avatar { get; set; }
}