using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AnkietaAlkoholowa.Models;

namespace AnkietaAlkoholowa.Controllers
{
    public class HomeController : Controller
    {

        public static Record _record = new Record();

        public ActionResult Index()
        {
            Session["start"] = true;
            return View();
        }

        public ActionResult Graph()
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
        
        public RedirectResult RedirectToIndex()
        {
            return Redirect("Home/Index");
        }

        public ContentResult DataToChart(string typ, string attr)
        {

            int[] liczba = new int[3];
            using (
            var connect = new SqlConnection(@"Server=tcp:alcobase.database.windows.net,1433;Initial Catalog=AlcoTestBase;Persist Security Info=False;User ID=kubmar;Password=Qweasdzxc_95;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                connect.Open();
                string query2 = $@"SELECT count(*) FROM[dbo].[Records] where times = @Times and {typ} = @typ;";
                using (SqlCommand command = new SqlCommand(query2, connect))
                {
                    command.Parameters.AddWithValue("@Times", Record.TimesEnum.Nigdy.ToString());
                    command.Parameters.AddWithValue("@typ", attr);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liczba[0] = Int32.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand(query2, connect))
                {
                    command.Parameters.AddWithValue("@Times", Record.TimesEnum.Sporadycznie.ToString());
                    command.Parameters.AddWithValue("@typ", attr);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liczba[1] = Int32.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand(query2, connect))
                {
                    command.Parameters.AddWithValue("@Times", Record.TimesEnum.Codziennie.ToString());
                    command.Parameters.AddWithValue("@typ", attr);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liczba[2] = Int32.Parse(reader.GetValue(0).ToString());
                        }
                    }
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
            return Content($"{liczba[0].ToString()}-{liczba[1].ToString()}-{liczba[2].ToString()}");
        }

        public ContentResult Save(string param, string type)
        {
          
            switch (type)
            {
                case "Sex":
                {
                    _record.Sex = param;
                    break;
                }
                case "Age":
                {
                    _record.Age = param;
                    break;
                }
                case "Education":
                {
                    _record.Education = param;
                    break;
                }
                case "Live":
                {
                    _record.Live = param;
                    break;
                }
                case "Times":
                {
                    _record.Times = param;
                    break;
                }
                case "Place":
                {
                    _record.Place = param;
                    break;
                }
                case "Aggresive":
                {
                    _record.Aggresive = param;
                    break;
                }
                case "Kind":
                {
                    _record.Kind = param;
                    break;
                }
                case "Hangover":
                {
                    _record.Hangover = param;
                    break;
                }


            }
            return Content(_record.Sex);

        }


        public void Data()
        {

            if (Session["start"] != null && _record.Hangover!=null)
            {
                using (
                    var connect =
                        new SqlConnection(
                            @"Server=tcp:alcobase.database.windows.net,1433;Initial Catalog=AlcoTestBase;Persist Security Info=False;User ID=kubmar;Password=Qweasdzxc_95;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                )

                {
                    connect.Open();
                    string query2 =
                        "INSERT INTO dbo.Records (age,sex,education,live,kind,times,place,aggresive,hangover) VALUES (@Age,@Sex,@Education,@Live,@Kind,@Times,@Place,@Aggresive,@Hangover);";

                    using (SqlCommand command = new SqlCommand(query2, connect))
                    {
                        command.Parameters.AddWithValue("@Sex", _record.Sex);
                        command.Parameters.AddWithValue("@Age", _record.Age);
                        command.Parameters.AddWithValue("@Education", _record.Education);
                        command.Parameters.AddWithValue("@Live", _record.Live);
                        command.Parameters.AddWithValue("@Kind", _record.Kind);
                        command.Parameters.AddWithValue("@Times", _record.Times);
                        command.Parameters.AddWithValue("@Place", _record.Place);
                        command.Parameters.AddWithValue("@Aggresive", _record.Aggresive);
                        command.Parameters.AddWithValue("@Hangover", _record.Hangover);
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

            else
            {
                Redirect("Home/Index");
            }



        }
        
    }
}