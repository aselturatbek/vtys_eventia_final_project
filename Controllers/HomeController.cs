using eventia_database.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eventia_database.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user, HttpPostedFileBase profilePicture)
        {
            if (ModelState.IsValid)
            {
                // Profil resmini byte dizisine dönüştürme
                if (profilePicture != null && profilePicture.ContentLength > 0)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new System.IO.BinaryReader(profilePicture.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(profilePicture.ContentLength);
                    }

                    // User modelindeki UserImage'e atama
                    user.UserImage = imageData;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }

            return View(user);
        }

        // GET: Home/Login


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            var matchedUser = db.Users.FirstOrDefault(u => u.Mail == user.Mail && u.Password == user.Password);

            if (matchedUser != null)
            {
                // Başarılı giriş durumunda session başlatılabilir veya gerekli diğer işlemler yapılabilir.
                // Örneğin:
                Session["UserId"] = matchedUser.UserID; // Kullanıcı kimliğini session'a ekle
                Session["Username"] = matchedUser.UserName;
                Session["UserImage"] = matchedUser.UserImage;
                return RedirectToAction("Index", "Home"); // Index sayfasına yönlendir
            }
            else
            {
                ViewBag.giris = "Hatalı giriş";
                return View(user);
            }
        }

        public ActionResult Index()
        {

            string username = Session["Username"] as string;
            ViewBag.Username = username;
            string userImage = Session["UserImage"] as string;
            ViewBag.UserImage = userImage;
            var viewModel = new IndexVM
            {
                Categories = db.Categories.ToList(),
                Event = new Event(),
                events = db.Event.ToList(),

                Review = new Review(),
                reviews = db.Review.ToList(),

                Attendance = new Attendance(),

            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexVM model)
        {
            if (ModelState.IsValid)
            {
                db.Event.Add(model.Event); // model.Event olarak düzeltilmiş
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.result = "Kaydedildi";
                    ViewBag.status = "success";
                }
                else
                {
                    ViewBag.result = "Kayıt başarısız";
                    ViewBag.status = "danger";
                }
            }
            else
            {
                ViewBag.result = "Geçersiz model"; // ModelState.IsValid false ise
                ViewBag.status = "danger";
            }

            model.Categories = db.Categories.ToList();
            model.events = db.Event.ToList(); // Etkinlikleri güncelle
            return View("Index", model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(FormCollection formCollection, HttpPostedFileBase reviewImage)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            int eventId = Convert.ToInt32(formCollection["eventSelect"]);
            string comment = formCollection["reviewText"];
            int rating = Convert.ToInt32(formCollection["rating"]);

            // Resim yükleme işlemi
            byte[] imageData = null;
            if (reviewImage != null && reviewImage.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(reviewImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(reviewImage.ContentLength);
                }
            }

            // Review nesnesini oluştur ve veritabanına ekle
            var review = new Review
            {
                UserID = userId,
                EventID = eventId,
                Comment = comment,
                Rating = rating,
                ReviewImage = imageData
            };

            db.Review.Add(review);
            db.SaveChanges();

            ViewBag.Message = "Review successfully added!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JoinEvent(FormCollection formCollection)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            int eventId = Convert.ToInt32(formCollection["event"]);
            string name = formCollection["name"];
            string surname = formCollection["surname"];
            string location = formCollection["location"];
            int age = Convert.ToInt32(formCollection["age"]);
            string email = formCollection["email"];
            string gender = formCollection["gender"];
            string phone = formCollection["phone"];

            // Review nesnesini oluştur ve veritabanına ekle
            var Attendance = new Attendance
            {
                UserID = userId,
                EventID = eventId,
                name = name,
                surname = surname,
                age = age,
                gender = gender,
                location = location,
                email = email,
                phone_number = phone
            };

            db.Attendance.Add(Attendance);
            db.SaveChanges();

            ViewBag.Message = "You successfully joined!";
            return RedirectToAction("Index");
        }


        public ActionResult AdminsPanel()
        {
            var viewModel = new IndexVM
            {
                users = db.Users.ToList(),
                Categories = db.Categories.ToList(),
                events = db.Event.ToList(),
                reviews = db.Review.ToList(),
                Attendances = db.Attendance.ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }

        [HttpPost]
        public ActionResult UpdateUser(Users user)
        {
            var existingUser = db.Users.Find(user.UserID);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Mail = user.Mail;
                existingUser.Password = user.Password;
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }
        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            var evt = db.Event.Find(id);
            if (evt != null)
            {
                db.Event.Remove(evt);
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }

        [HttpPost]
        public ActionResult UpdateEvent(Event evt)
        {
            var existingEvent = db.Event.Find(evt.EventID);
            if (existingEvent != null)
            {
                existingEvent.EventTitle = evt.EventTitle;
                existingEvent.CategoryID = evt.CategoryID;
                existingEvent.EventDetail = evt.EventDetail;
                existingEvent.Location = evt.Location;
                existingEvent.EventDate = evt.EventDate;
                existingEvent.EventTime = evt.EventTime;
                existingEvent.ParticipationRequirements = evt.ParticipationRequirements;
                existingEvent.ContactInfo = evt.ContactInfo;
                existingEvent.EventImageUrl = evt.EventImageUrl;
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }
        [HttpPost]
        public ActionResult DeleteAttendance(int id)
        {
            var attendance = db.Attendance.Find(id);
            if (attendance != null)
            {
                db.Attendance.Remove(attendance);
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }

        [HttpPost]
        public ActionResult UpdateAttendance(Attendance attendance)
        {
            var existingAttendance = db.Attendance.Find(attendance.AttendanceID);
            if (existingAttendance != null)
            {
                existingAttendance.UserID = attendance.UserID;
                existingAttendance.EventID = attendance.EventID;
                existingAttendance.name = attendance.name;
                existingAttendance.surname = attendance.surname;
                existingAttendance.age = attendance.age;
                existingAttendance.gender = attendance.gender;
                existingAttendance.location = attendance.location;
                existingAttendance.phone_number = attendance.phone_number;
                existingAttendance.email = attendance.email;
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }
        [HttpPost]
        public ActionResult DeleteReview(int id)
        {
            var review = db.Review.Find(id);
            if (review != null)
            {
                db.Review.Remove(review);
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }

        [HttpPost]
        public ActionResult UpdateReview(Review review)
        {
            var existingReview = db.Review.Find(review.ReviewID);
            if (existingReview != null)
            {
                existingReview.UserID = review.UserID;
                existingReview.EventID = review.EventID;
                existingReview.Comment = review.Comment;
                existingReview.Rating = review.Rating;
                existingReview.ReviewImage = review.ReviewImage;
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }
        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var existingCategory = db.Categories.Find(category.CategoryID);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                db.SaveChanges();
            }
            return RedirectToAction("AdminsPanel");
        }




    }


}
