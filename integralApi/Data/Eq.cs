using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using org.mariuszgromada.math.mxparser;

namespace integralApi.Data
{
    public class Eq
    {
        [Key]
        public int Id { get; set; }
        public string? Equation { get; set; }
        public string? Variable { get;set; }
        public string? FirstNumber { get;set;}
        public string? LastNumber { get;set;}
        public double Answer { get; set; }
    }
}
