namespace server.models
{
    public class Category
    {
        static int index = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public Category(string name,string icon)
        {
            Id = index++; Name = name; Icon = icon;
        }
        public Category()
        {
            
        }
    }
}
