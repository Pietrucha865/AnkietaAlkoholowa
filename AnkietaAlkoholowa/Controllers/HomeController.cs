using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AnkietaAlkoholowa.Models;

namespace AnkietaAlkoholowa.Controllers
{
    public class HomeController : Controller
    {
        public int Age { get; set; }
      
        public  string Sex { get; set; }
        private List<Record> record = new List<Record>();
        public ActionResult Index()
        {
            Session["start"] = 53;
            return View();
        }

        public ActionResult Graph(string sex, int? age)
        {
            Data();
            var model = new RecordViewModel
            {
                Record = record
            };
            //ViewBag.Record = record;
            return View(model);
        }
       
        public JsonResult Sessione()
        {
            
           // this.Sex = sex;
           Session["Age"] = Request.Params["age"];
            Session["Sex"] = Request.Params["sex"]; 
         
            return Json(null);


        }


        public void Data()
        {
            this.Age = Int32.Parse(Session["Age"].ToString());
            this.Sex = Session["Sex"].ToString();
            
            if (Session["start"] != null)
            {
                //List<Record> rec = new List<Record>();
                using (
                    var connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = AlcoBase"))

                {
                    connect.Open();
                    string query = "SELECT * FROM dbo.Records ;";
                    string query2 = "INSERT INTO dbo.Records (age,sex) VALUES (@Age,@Sex);";

                    using (SqlCommand command = new SqlCommand(query2, connect))
                    {
                        command.Parameters.AddWithValue("@Age",Age);
                        command.Parameters.AddWithValue("@Sex",Sex);
                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command = new SqlCommand(query, connect))
                    {

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                record.Add(new Record(Int32.Parse(reader.GetValue(1).ToString()),
                                    reader.GetValue(2).ToString().TrimEnd()));
                            }

                        }
                    }
                }
            }

        }
        
    }
}