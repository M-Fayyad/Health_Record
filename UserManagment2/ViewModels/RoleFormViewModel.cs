﻿using System.ComponentModel.DataAnnotations;

namespace UserManagment2.ViewModels
{
    public class RoleFormViewModel
    {
        [Required,StringLength(256)]
        public string Name { get; set; }
    }
}
