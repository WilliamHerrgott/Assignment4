namespace WebService.Models
{
    public class CategoryPostAndPutModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProductGetModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
    
    public class ListProductGetModel
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}