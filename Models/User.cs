
using System;
using System.ComponentModel.DataAnnotations;
namespace GoOrangeApi.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Birth { get; set; }
    [Required]
    public int Email { get; set; }
    [Required]
    public int Genre { get; set; }
    [Required]
    public int Photo { get; set; }
  }
}