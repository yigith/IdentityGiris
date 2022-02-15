﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityGiris.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string DisplayName { get; set; }
    }
}
