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
    
    public partial class Exchange_Quantity
    {
        public int EP_ID { get; set; }
        public int Prod_ID { get; set; }
        public int Exchange_Quantity1 { get; set; }
    
        public virtual Exchange_Permission Exchange_Permission { get; set; }
        public virtual Product Product { get; set; }
    }
}
