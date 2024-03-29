﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class JobApplicationDto
    {
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[Phone]
		public string PhoneNumber { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public byte[] CV { get; set; }
		public byte[] MotivationalLetter { get; set; }
		[Required]
		public string Category { get; set; }
	}
}
