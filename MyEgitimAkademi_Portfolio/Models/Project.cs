//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyEgitimAkademi_Portfolio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public Nullable<int> ProjectCategory { get; set; }
        public Nullable<int> ComplateDay { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProjectImage { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
