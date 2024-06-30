using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventia_database.Models
{
    [Table("Users")]
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
        public byte[] UserImage { get; set; }
    }

    [Table("Category")] // Tablonuzun ismini burada belirtin
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }

    [Table("Event")]
    public partial class Event
    {
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public int CategoryID { get; set; }
        public string EventDetail { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan? EventTime { get; set; }
        public string ParticipationRequirements { get; set; }
        public string ContactInfo { get; set; }
        public string EventImageUrl { get; set; }

        // Navigation property for Category
        public virtual Category Category { get; set; }


    }
    [Table("Review")]
    public class Review
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public byte[] ReviewImage { get; set; }
        public virtual Event Event { get; set; }
        public virtual Users User { get; set; }
    }
    [Table("Attendance")]
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public virtual Event Event { get; set; }
        public virtual Users Users { get; set; }

    }

}