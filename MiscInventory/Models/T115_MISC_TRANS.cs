//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiscInventory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class T115_MISC_TRANS
    {
        [Display(Name = "Trans")]
        public string TRANS { get; set; }
        [Display(Name = "Inv Type")]
        public string INV_TYPE { get; set; }
        [Display(Name = "Inv Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> INV_DATE { get; set; }
        [Display(Name = "Inv Time")]
        public Nullable<System.TimeSpan> INV_TIME { get; set; }
        [Display(Name = "Trans UserId")]
        public string TRANS_USERID { get; set; }
        [Display(Name = "ID")]
        public string ID_R { get; set; }
        [Display(Name = "Description")]
        public string INV_DESC { get; set; }
        [Display(Name = "Budget")]
        public string BUD { get; set; }
        public string SERIAL_NO { get; set; }
        public string REPLC_SERIAL_NO { get; set; }
        [Display(Name = "Location")]
        public string LOC { get; set; }
        public string SUB_LOC { get; set; }
        public string PURCH_YY { get; set; }
        public string PURCH_MM { get; set; }
        [Display(Name = "Doc Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DOC_DATE { get; set; }
        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public decimal COST { get; set; }
        [Display(Name = "Depr")]
        [DataType(DataType.Currency)]
        public decimal DEPR { get; set; }
        [Display(Name = "Fed Id")]
        public string FEDID { get; set; }
        [Display(Name = "Sub Type")]
        public string SUB_TYPE { get; set; }
        [Display(Name = "Req No.")]
        public string REQ_NO { get; set; }
        [Display(Name = "Vchr No.")]
        public string VCHR_NO { get; set; }
        public string MANUFAC_MODL_NO { get; set; }
        public string MANUFAC_NAME { get; set; }
        public string COMMENT { get; set; }
        public string UT_VCHR_NO { get; set; }
        public string T115_MISC_TRANS_PRIMARY_KEY { get; set; }
        public string VALUE_STATUS { get; set; }
    }
}
