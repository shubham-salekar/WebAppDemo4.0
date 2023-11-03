using Microsoft.AspNetCore.Identity;
using System;

public class ApplicationUser : IdentityUser
{
    public string City { get; set; }   
}
