//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOFOY.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int Id { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public string ReviewDetail { get; set; }
        public int ReviewRate { get; set; }
        public string CustomerId { get; set; }
        public int ReviewMenu { get; set; }
        public int ReviewCafe { get; set; }
    
        public virtual CafeShop CafeShop { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
