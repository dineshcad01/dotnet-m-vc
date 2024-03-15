using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_csharp.Models;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_csharp.Controllers;

public class HomeController : Controller
{
    SqlConnection con=new SqlConnection();
    SqlCommand com=new SqlCommand(); 

    SqlDataReader? dr;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    void connectionString(){
        con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=cad_os; User Id= CADBATCH01; password=CAD@123pass; TrustServerCertificate=true;";
    }
     
     [HttpPost]
    public IActionResult VerifyLogin(LoginModel lmodel){

        connectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="select * from os_user_login where user_name='"+lmodel.user_name+"' and password='"+lmodel.password+"' ; ";
        dr=com.ExecuteReader();
        if(dr.Read()){
            con.Close();
        return View("Done");
        }
        else{
            con.Close();
            return View("Error");
        }

        
        
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
