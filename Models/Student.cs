namespace entityframeworkStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        public int? age { get; set; }

        [Column("class")]
        [StringLength(10)]
        public string _class { get; set; }
    }
}
