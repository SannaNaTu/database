using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tehtävä1NetCore.Model
{
    public partial class Phone
    {
        public Phone(string type, string number)
        {
            Type = type;
            Number = number;
        }

        public long Id { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string Type { get; set; }
        [Column(TypeName = "char(20)")]
        public string Number { get; set; }
        public long? PersonId { get; set; }

        [ForeignKey("PersonId")]
        [InverseProperty("Phone")]
        public Person Person { get; set; }
        public override string ToString()
        {
            return $"{Type} - {Number}";
        }
    }
}
