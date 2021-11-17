using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thang_core1.Models
{
    public class Blog
    {
        public int? id { get; set; }

        /// <summary>
        /// validattion tin
        /// </summary>
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string tin { get; set; }

        /// <summary>
        /// validation loai
        /// </summary>
        [Required]
        public string loai { get; set; }

        /// <summary>
        /// validation trangthai
        /// </summary>
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string trangThai { get; set; }
        /// <summary>
        /// validation vitri
        /// </summary>
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string viTri { get; set; }

        /// <summary>
        /// validation motangan
        /// </summary>
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string motangan { get; set; }

        /// <summary>
        /// validation chitiet
        /// </summary>
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string chitiet { get; set; }

        /// <summary>
        /// validation ngay public
        /// </summary>
        [Required(ErrorMessage = "Enter the issue date")]
        [DataType(DataType.Date)]
        public DateTime ngayPublic { get; set; }
    }
 
}

