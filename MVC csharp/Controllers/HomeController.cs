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
    public IActionResult Support()
    {
        return View();
    }
    public IActionResult Cart()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

     void conStr(){
         con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=cad_os; User ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True; ";
    }
    
    [HttpPost]
     public IActionResult RegisterDB(RegistrationModel rmodel)
    {  
        conStr();
        con.Open();
        com.Connection=con;
        com.CommandText="insert into os_registration(Full_Name,Contact_number,Address,Email_id,User_id, Password) values (@Full_Name,@Contact_number,@Address,@Email_id,@User_id,@password)";
        com.Parameters.AddWithValue("@Full_Name",rmodel.Full_Name);
        com.Parameters.AddWithValue("@Contact_number",rmodel.Contact_number);
        com.Parameters.AddWithValue("@Address",rmodel.Address);
        com.Parameters.AddWithValue("@Email_id",rmodel.Email_id);
        com.Parameters.AddWithValue("@User_id",rmodel.User_id);
        com.Parameters.AddWithValue("@Password",rmodel.Password);

        int rowAffected=com.ExecuteNonQuery();
        if(rowAffected>0){
            con.Close();
            return RedirectToAction("Login");
        }
        else{
            con.Close();
            return View("Error");
        }
        
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
        return RedirectToAction("Register", "Login");
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
