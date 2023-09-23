using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class LoginModel
{
    public string UserName { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
