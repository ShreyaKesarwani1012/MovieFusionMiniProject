using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieFusion.Models;

public partial class MovieList
{

    public int MId { get; set; }

    [Required(ErrorMessage = "Mname is required.")]
    [StringLength(50, ErrorMessage = "Mname cannot be longer than 50 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Mname can only contain letters.")]
    public string Mname { get; set; } = null!;

    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(50, ErrorMessage = "Genre cannot be longer than 50 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Genre can only contain letters.")]
    public string Genre { get; set; } = null!;

    [Required(ErrorMessage = " number is required.")]
    [RegularExpression(@"^\d{3}$", ErrorMessage = "number must be 3 digits.")]
    public int Duration { get; set; }


    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
