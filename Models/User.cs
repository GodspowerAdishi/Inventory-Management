using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string Username { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        public int Status { get; set; }

        [Display(Name = "Role")]
        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Roles { get; set; }

    }
}