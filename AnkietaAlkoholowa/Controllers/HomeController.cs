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
       
      
        private List<Record> record = new List<Record>();
        public ActionResult Index()
        {
            Session["start"] = 53;
            return View();
        }

        public ActionResult Graph(string sex, int? age)
        {
            Data();
            //var model = new RecordViewModel
            //{
            //    Record = record
            //};
            //ViewBag.Record = record;
            return View();
            //return View();
        }


       
        public JsonResult Sessione()
        {
            Session["Age"] = Request.Params["age"];
            Session["Sex"] = Request.Params["sex"];
            Session["Education"] = Request.Params["education"];
            Session["Live"] = Request.Params["lives"];
            Session["Kind"] = Request.Params["kind"];
            Session["Place"] = Request.Params["place"];
            Session["Times"] = Request.Params["times"];
            Session["Aggresive"] = Request.Params["aggresive"];
            Session["Hangover"] = Request.Params["hangover"];
            return Json(null);
        }


        public void Data()
        {
            
            if (Session["start"] != null)
            {
                //List<Record> rec = new List<Record>();
                using (
                    //var connect = new SqlConnection("Server = mssql01.dcsweb.pl,51433; Database = 1292_AlcoTest; Uid = 1292_alcotest; Password = Qweasdzxc_95;"))
                   // var connect = new SqlConnection(@"Server=tcp:alcobase.database.windows.net,1433;Initial Catalog=AlcoTestBase;Persist Security Info=False;User ID=kubmar;Password=Qweasdzxc_95;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    var connect = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = AlcoBase"))

                {
                    connect.Open();
                    //string query = "SELECT * FROM dbo.Records ;";
                    string query2 = "INSERT INTO dbo.Records (age,sex,education,live,kind,times,place,aggresive,hangover) VALUES (@Age,@Sex,@Education,@Live,@Kind,@Times,@Place,@Aggresive,@Hangover);";

                    using (SqlCommand command = new SqlCommand(query2, connect))
                    {
                        command.Parameters.AddWithValue("@Age", Session["Age"]);
                        command.Parameters.AddWithValue("@Sex",Session["Sex"]);
                        command.Parameters.AddWithValue("@Education",Session["Education"]);
                        command.Parameters.AddWithValue("@Live",Session["Live"]);
                        command.Parameters.AddWithValue("@Kind",Session["Kind"]);
                        command.Parameters.AddWithValue("@Times",Session["Times"]);
                        command.Parameters.AddWithValue("@Place",Session["Place"]);
                        command.Parameters.AddWithValue("@Aggresive",Session["Aggresive"]);
                        command.Parameters.AddWithValue("@Hangover",Session["Hangover"]);
                        command.ExecuteScalar();
                    }
                    //using (SqlCommand command = new SqlCommand(query, connect))
                    //{

                    //    using (var reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            record.Add(new Record(Int32.Parse(reader.GetValue(1).ToString()),
                    //                reader.GetValue(2).ToString().TrimEnd()));
                    //        }

                    //    }
                    //}
                }
            }

        }
        
    }
}