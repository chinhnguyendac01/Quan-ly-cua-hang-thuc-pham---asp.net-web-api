using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


[Table("DNNDB_NhanVien")]
public class DNNDB_NhanVien
    {   
    public int? NhanVienID { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string Anh { get; set; }
    public string Email { get; set; }
    public string MatKhau { get; set; }
}
