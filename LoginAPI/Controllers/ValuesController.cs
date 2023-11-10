using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AccountController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpPost]
    [Route("login")]
    public string Login(Account account)
    {
        SqlConnection con = new SqlConnection(_configuration.GetConnectionString("defaultconnection").ToString());
        SqlDataAdapter da = new SqlDataAdapter("select * from account where username = '" + account.Username + "' and password = '" + account.Password + "'", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return "Login succesful";
        }
        else
        {
            return "Login fail";
        }

    }
}
