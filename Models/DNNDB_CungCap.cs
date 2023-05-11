using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("DNNDB_MonAn")]
public class DNNDB_CungCap
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? CungCapID { get; set; }
    [MaxLength(50)]
    public string TenLienHe { get; set; }
    public string DiaChi { get; set; }
    public string MaBuudien { get; set; }
    public string Quocgia { get; set; }
    public string DienThoai { get; set; }
}
