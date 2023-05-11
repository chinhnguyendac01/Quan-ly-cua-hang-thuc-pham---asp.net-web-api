using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("DNNDB_MonAn_File")]
    public class DNNDB_MonAn_File
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? ID { get; set; }
    public int? mamon { get; set; }
    public int? FileID { get; set; }
}