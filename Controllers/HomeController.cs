using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shaveer.Models;
using System.Net;
using System.Net.Mail;
namespace Shaveer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ShaveerEntities db = new ShaveerEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Training()
        {
            return View(db.Trainings.ToList());
        }

        public ActionResult Nutrition()
        {
            return View(db.Nutritions.ToList());
        }

        public ActionResult Wellness()
        {
            return View(db.Wellnesses.ToList());
        }


        public ActionResult Transformation()
        {
            return View(db.Transformations.ToList());
        }


        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection frm)
        {
             Contact details = new Contact();
                {
                    details.Name = frm["Name"];
                    details.Mail = frm["Email"];
                    details.Message = frm["Message"];



                }

                if (ModelState.IsValid)
                {
                    var body = details.Name + "\n" + details.Mail + "\n" + details.Message;
                                
                                var message = new MailMessage();
                                message.To.Add(new MailAddress("contact.coachshav@gmail.com"));  // replace with valid value 
                                message.From = new MailAddress(details.Mail);
                                message.Subject = "INQUIRY";
                                
                                message.Body = string.Format(body);
                                message.IsBodyHtml = true;
                                


                                try
                                {
                                    using (var smtp = new SmtpClient())
                                    {
                                        var credential = new NetworkCredential
                                        {
                                            UserName = "sagartattoos555@gmail.com",  // replace with valid value
                                            Password = "sumansonu143"  // replace with valid value
                                        };
                                        

                                        smtp.Host = " smtp.gmail.com";
                                        smtp.Port = 587;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = credential;
                                        smtp.EnableSsl = true;
                                        smtp.Send(message);
                                    }
                                }
                                catch (SmtpException ex)
{
//catched smtp exception
ViewBag.Text = "SMTP Exception: " + ex.Message.ToString();
ViewBag.ForeColor = System.Drawing.Color.Red;
return View();
}

                    }



        }
       
            
        }
}

