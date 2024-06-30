using System.Collections.Generic;




namespace eventia_database.Models
{
    public class IndexVM
    {
        public List<Category> Categories { get; set; }
        public List<Event> events { get; set; }
        public Event Event { get; set; }
        public Review Review { get; set; }
        public List<Review> reviews { get; set; }
        public List<Users> users { get; set; }
        public Attendance Attendance { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
