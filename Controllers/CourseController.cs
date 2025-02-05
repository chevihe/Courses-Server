using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;
using server.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
    public static List<Course> courses = new List<Course> {
            new Course("הלכות שמירת הלשון", 9, 1, "03-11-2024", new Topic[] {new Topic("לימוד מתוך הספר נצור לשונך", "🔒" ), new Topic("חיזוקים וסיפורים", "🔒") },
                Learn.Zoom, 1, "https://www.photolight.co.il/wp-content/uploads/2020/10/camera_1603811431-300x200.jpg")
    };
    //new Course("Introduction to Drawing",
    //            1, 8, "05-23-2024",
    //            new string[] {
    //                "Unit 1: Introduction to Basic Drawing Materials",
    //                "Overview of different drawing materials (pencils, charcoal, ink, etc.)",
    //                "Introduction to basic drawing techniques",
    //                "Practice exercises focusing on line quality and mark-making",
    //                "Unit 2: Understanding Proportion and Scale",
    //                "Principles of proportion and scale in drawing",
    //                "Drawing exercises focusing on proportion and scale",
    //                "Still life drawing with emphasis on proportion and scale",
    //                "Unit 3: Exploring Perspective",
    //                "Introduction to linear perspective",
    //                "One-point and two-point perspective drawing exercises",
    //                "Perspective drawing from observation",
    //                "Unit 4: Introduction to Composition",
    //                "Principles of composition in drawing",
    //                "Composition exercises using still life setups",
    //                "Understanding focal points and balance in composition",
    //                "Unit 5: Introduction to Figure Drawing",
    //                "Basics of figure drawing",
    //                "Drawing exercises focusing on gesture and contour drawing",
    //                "Introduction to figure proportions and anatomy",
    //                "Unit 6: Exploring Value and Shading Techniques",
    //                "Understanding value and its importance in drawing",
    //                "Shading techniques using various drawing materials",
    //                "Still life drawing focusing on value and shading",
    //                "Unit 7: Final Project - Bringing It All Together",
    //                "Integration of learned skills and techniques into a final drawing project",
    //                "Individualized guidance and feedback on final projects",
    //                "Group critique and discussion",
    //                "Course Conclusion and Showcase",
    //                "Unit 8: Presentation of final projects",
    //                "Reflection on progress and growth throughout the course",
    //                "Discussion on further avenues for exploration in drawing" 
    //            },
    //            Learn.Frontal, 2, "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Circle-icons-art.svg/1024px-Circle-icons-art.svg.png"),
    //        new Course("Creative Writing",
    //            2, 5, "12-03-2024", new string[] { "Unit 1: Introduction to Creative Writing", "Introduction to the fundamentals of creative writing","Inspiration and idea generation techniques","Planning and outlining for creative writing projects", "Unit 2: Narrative Structure and Dialogue", "Understanding the elements of narrative structure","Developing characters and describing environments","Techniques for crafting engaging dialogue", "Unit 3: Description and Emotion","Utilizing poetic and descriptive language","Conveying emotions and feelings through words","Creating vivid imagery and detailed descriptions","Unit 4: Building Scenes and Characters","Exploring the construction of scenes and narratives","Developing characters and relationships","Advancing plotlines and creating dramatic tension","Unit 5: Conclusion and Review","Finalizing creative writing projects","Editing and refining writing pieces","Preparing work for publication and sharing with an audience" },
    //            Learn.Frontal, 2, "https://notsavakeset.co.il/wp-content/uploads/2020/07/nvk-1-768x643.png"),
    //    new Course("Introduction to Photography",
    //            3, 10, "03-11-2024", new string[] { "Photography Course Syllabus", "Unit 1: Introduction to Photography", "History of photography", "Basic concepts in photography", "Types of cameras and photography equipment", "Unit 2: Basic Techniques", "Exposure control: aperture, shutter speed, and ISO", "Camera position control: framing, composition, and perspective", "Motion control: freezing motion and capturing motion blur", "Focus control: depth of field", "Unit 3: Image Planning", "Understanding light and shadow", "Color balance control", "Creating suitable frames and backgrounds", "Leading lines and effective angles", "Unit 4: Outdoor Photography", "Landscape photography: techniques and dealing with light and shadow", "Urban photography: capturing movement and city structure", "Nature photography: coping with varying light conditions and movement in nature", "Event photography: capturing moments and dealing with changing light conditions", "Unit 5: Portrait Photography", "Understanding facial and self-anatomy", "Light and shadow control for mood and atmosphere", "Creating complementary backgrounds and coordinating with the subject", "Handling poses and compositions", "Unit 6: Product Photography", "Creating quality and sales-oriented product images", "Coping with product expansion and lighting conditions", "Shooting multiple items on a colorful or neutral background", "Understanding light sources and controlling angles of illumination", "Unit 7: Image Editing", "Basics of image editing in professional editing software", "Correcting technical flaws in images", "Preserving and enhancing details", "Creating effects and maintaining style", "Unit 8: Guest and Event Photography", "Principles of guest photography", "Planning and camera placement at events", "Coping with changing light conditions and continuous movement", "Documenting and editing event videos", "Unit 9: Artistic Photography", "Creating artistic images using advanced techniques", "Preparation and creation in artistic photography", "Artistic photography theories and artistic concepts", "Reflecting the world through artistic photography", "Unit 10: Final Project and Presentation", "Independent project creation and presentation", "Feedback and critique sessions", "Revision and final presentation of projects" },
    //            Learn.Zoom, 1, "https://www.photolight.co.il/wp-content/uploads/2020/10/camera_1603811431-300x200.jpg")};

// GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return courses;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            var course = courses.Find(x => x.Id == id);
            if (course != null)
                return course;
            return null;
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Course value)
        {
            var course = courses.Find(x => x.Id == value.Id);
            if (course != null)
            {
                course.Learn = value.Learn;
                course.Img = value.Img;
                course.Name = value.Name;
                course.TecherId = value.TecherId;
                course.StartDate = value.StartDate;
                course.CategoryId = value.CategoryId;
                course.Count = value.Count;
                course.Syllabus = value.Syllabus;
            }
            else
            {
                courses.Add(new Course(value.Name, value.CategoryId, value.Count, value.StartDate, value.Syllabus, value.Learn, value.TecherId, value.Img));
            }
            //courses.Add(new Course(value.Name,value.Description,value.CategoryId,value.Amount,value.BeginDate,value.Syllabus,value.LearningType,value.LecturerId,value.Image));
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Course value)
        {
            var course = courses.Find(x => x.Id == id);
            if (course != null)
            {
        course.Learn = value.Learn;
        course.Img = value.Img;
        course.Name = value.Name;
        course.TecherId = value.TecherId;
        course.StartDate = value.StartDate;
        course.CategoryId = value.CategoryId;
        course.Count = value.Count;
        course.Syllabus = value.Syllabus;
        }
            else
            {
                courses.Add(new Course(value.Name, value.CategoryId, value.Count, value.StartDate, value.Syllabus, value.Learn, value.TecherId, value.Img));
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var course = courses.Find(x => x.Id == id);
            if (course != null)
            {
                courses.Remove(course);
            }

        }
    }
}
