//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product_Measure
    {
        public int Prod_ID { get; set; }
        public string Measure_Unit { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
