using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("DNNDB_LoaiMon")]
    public class DNNDB_LoaiMon
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? maloai { get; set; }
    [MaxLength(50)]
    public string tenloai { get; set; }
}
