using System;
using System.ComponentModel.DataAnnotations;
using Controllers.CustomValidators;

namespace Controllers.Models;

public class Person2
{
    [Required(ErrorMessage = "{0} can not be empty or Null")]
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1 characters long}")]
    public string? PersonName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
    [Range(0, 999.99, ErrorMessage = "{0} should be between R{1} and R{2}")]
    public double? Price { get; set; }
    [MinimumYearValidator(2005)]
    public DateTime DateOfBirth { get; set;}

    public override string ToString()
    {
        return $"Person2 object\nPersonName: {PersonName}\nEmail: {Email}\nPhone: {Phone}\nPassword: {Password}\nConfirmPassword: {ConfirmPassword}\nPrice: {Price}";
    }
}
