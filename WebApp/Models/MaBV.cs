using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeverBVSTT.Models
{
    public class MaBV
    {
        [Required(ErrorMessage = "Bạn chưa nhập user")]
        public string User { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mã")]
        public string Ma { get; set; }
        public bool Remember { get; set; }

    }
}
