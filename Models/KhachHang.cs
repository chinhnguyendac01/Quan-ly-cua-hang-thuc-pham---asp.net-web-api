using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


   [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? makh  { get; set; }
        [MaxLength(50)]
        public string Hoten { get; set; }
        [MaxLength(100)]
        public string diachi { get; set; }
         [MaxLength(50)]
        public string sodt { get; set; }
        [MaxLength(50)] 
        public string email { get; set; }
           
    }
