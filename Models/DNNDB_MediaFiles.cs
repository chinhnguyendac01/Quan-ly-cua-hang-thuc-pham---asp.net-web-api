using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("NNDB_MediaFiles")]
public class NNDB_MediaFile
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? FileID { get; set; } // int, not null
    public int? TypeID { get; set; } // int, null
    public int? FolderID { get; set; } // int, null
    [MaxLength(255)]
    public string Title { get; set; } // nvarchar(255), not null
    [MaxLength]
    public string Description { get; set; } // nvarchar(max), null
    public DateTime? DateCreated { get; set; } // smalldatetime, null
    [MaxLength(1000)]
    public string Path { get; set; } // nvarchar(1000), null
    [MaxLength(1000)]
    public string Url { get; set; } // nvarchar(1000), null
}
