using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFusion.Models;

public partial class User
{
    public int UId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "City can only contain letters.")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
    public string Phone { get; set; }

public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
