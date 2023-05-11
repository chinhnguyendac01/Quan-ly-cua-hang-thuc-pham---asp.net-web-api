using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("DNNDB_MonAn")]
public class DNNDB_MonAn
{

    public int? mamon { get; set; }
    [MaxLength(50)]
    public string tenmon { get; set; }
    public string tenloai { get; set; }
    public int? soluong { get; set; }
    public int? gia { get; set; }
    public int maloai { get; set; }
    [MaxLength(50)]
    public string thanhphan { get; set; }
    public int? MaAnh { get; set; }
    public DateTime? Ngaynhap { get; set; }
    public int IDCungcap { get; set; }
    public string TenLienHe { get; set; }
}
public class DNNDB_MonAn_LoaiMon_MediaFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? mamon { get; set; }
    [MaxLength(50)]
    public string tenloai { get; set; }
    public string tenmon { get; set; }
    public int? soluong { get; set; }
    public int? gia { get; set; }
    public int maloai { get; set; }
    [MaxLength(50)]
    public string thanhphan { get; set; }
    public int? MaAnh { get; set; }
    public DateTime? Ngaynhap { get; set; }
    public int IDCungcap { get; set; }
    public string TenLienHe { get; set; }
    [MaxLength(1000)]
    public string Path { get; set; } // nvarchar(1000), null
    [MaxLength(1000)]
    public string Url { get; set; } // nvarchar(1000), null
    public string pathFolder { get; set; }
    public string pathThuMuc { get; set; }
    public string Title { get; set; }
    public int FileID { get; set; }


}
