﻿using System.ComponentModel.DataAnnotations;

namespace finance.api.DTOs.Account
{
	public class RegisterDto
	{
		[Required]
		public string? Username { get; set; }
		[Required]
		public string? Password { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }

	}
}
