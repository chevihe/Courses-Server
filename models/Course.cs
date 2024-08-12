using Microsoft.OData.Edm;

namespace server.models
{

  public class Topic
  {
    public string Name { get; set; }
    public string Icon { get; set; }

    public Topic(string name,string icon)
    {
          Name = name;
          Icon = icon;
    }
  }

public enum Learn { Frontal = 1, Zoom = 2 };
    public class Course
    {
        static int index = 1;
        public int Id { get; set; }
        public string Name { get; set; }      
        public int CategoryId { get; set; }
        public int Count { get; set; }
        public string StartDate { get; set; }
        public Topic[] Syllabus { get; set; }
        public Learn Learn { get; set; }
        public int TecherId { get; set; }
        public string Img { get; set; }
        public Course(string name,int catId,int count, string startDate, Topic[]syllabus, Learn learn, int techerId, string image)
        {
            Id = index++;
            Name = name;
            CategoryId = catId;
            Count = count;
            StartDate = startDate;
            Syllabus = syllabus;
            Learn = learn;
            TecherId = techerId;
            Img = image;   
        }
        public Course()
        {
            
        }
    }
}
