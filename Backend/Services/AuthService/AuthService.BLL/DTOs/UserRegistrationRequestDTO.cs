﻿using System.ComponentModel.DataAnnotations;
using AuthService.DAL.Enums;

namespace AuthService.BLL.DTOs;

public class UserRegistrationRequestDTO
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 100 characters")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First name can contain letters only")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 100 characters")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last name can contain letters only")]
    public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;
    
    public Role Role { get; set; } = Role.Student;
}