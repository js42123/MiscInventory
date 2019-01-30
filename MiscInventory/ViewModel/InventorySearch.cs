using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MiscInventory.Controllers;
using PagedList;
using PagedList.Mvc;


namespace MiscInventory.Models
{
    public class InventorySearch
    {
      
    
        public static string DefaultSortOrder = "DESCENDING";
        public static string SortingByDefault = "Inventory Number";

        public static Dictionary<string, string> OrderByFields = new Dictionary<string, string>
            {
                {"ID_R", "Inventory Number"},
                {"DOC_DATE", "Doc. Date"}
            };
     

        [Display(Name = "Type:")]
        public string INV_TYPE { get; set; }
        public string DELETE_FLAG { get; set; }
        [Display(Name = "Inventory Number:")]
        public string ID_R { get; set; }
        [Display(Name = "Description:")]
        public string INV_DESC { get; set; }
        [Display(Name = "Budget:")]
        public string BUD { get; set; }
        [Display(Name = "Serial Number:")]
        public string SERIAL_NO { get; set; }
        public string REPLC_SERIAL_NO { get; set; }
        [Display(Name = "Location:")]
        public string LOC { get; set; }
        [Display(Name = "Sub-Location:")]
        public string SUB_LOC { get; set; }
        [Display(Name = "Purch. Yr.:")]
        public string PURCH_YY { get; set; }
        [Display(Name = "Purch. Mnth.:")]
        public string PURCH_MM { get; set; }
        [Display(Name = "Doc. Date:")]
        public Nullable<System.DateTime> DOC_DATE { get; set; }
        [Display(Name = "Cost:")]
        [DataType(DataType.Currency)]
        public decimal COST { get; set; }
        [Display(Name = "Depr.:")]
        [DataType(DataType.Currency)]
        public decimal DEPR { get; set; }
        public string FEDID { get; set; }
        [Display(Name = "Sub. Type:")]
        public string SUB_TYPE { get; set; }
        [Display(Name = "Req. No.:")]
        public string REQ_NO { get; set; }
        [Display(Name = "Voucher No.:")]
        public string VCHR_NO { get; set; }
        public string MANUFAC_MODL_NO { get; set; }
        public string MANUFAC_NAME { get; set; }
        [Display(Name = "Comment:")]
        public string COMMENT { get; set; }
        public string UT_VCHR_NO { get; set; }
        public string T115_MISC_INVENTORY_PRIMARY_KEY { get; set; }
        public string VALUE_STATUS { get; set; }
        [Display(Name = "Begin month:")]
        public string BEGIN_MONTH { get; set; }
        [Display(Name = "End month:")]
        public string END_MONTH { get; set; }
        public string INVENTORY_TYPE { get; set; }
        [Display(Name = "Begin Year:")]
        public string BEGIN_YEAR { get; set; }
        [Display(Name = "End Year:")]
        public string END_YEAR { get; set; }
        [Display(Name = "Inventory Number Contains")]
        public string CONTAINS { get; set; }
        [Display(Name = "Inventory Number Begins With")]
        
        public string query { get; set; }
        public string Search { get; set; }
        public string inventory { get; set; }
        public List<T115_MISC_INVENTORY> SearchResults { get; set; }
        public List<T115_MISC_TRAN_ARCHV> arch { get; set; }
        public List<T115_MISC_TRANS> trans { get; set; }
        public int page { get; set; }

        public string SortOrder { get; set; }
        public string SortingBy { get; set; }
        public string OrderBy { get; set;  }
        public string model { get; set; }

        public string data { get; set; }
        

        [Display(Name = "From Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy")]
        public DateTime FromSearchDate { get; set; }
        [Display(Name = "To Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy")]
        public DateTime ToSearchDate { get; set; }

        internal class OrderByDescending
        {
            private Func<object, object> p;

            public OrderByDescending(Func<object, object> p)
            {
                this.p = p;
            }

            internal class Skip
            {
                private int startIndex;

                public Skip(int startIndex)
                {
                    this.startIndex = startIndex;
                }
            }
        }

  
    }
     
}




 





        

   

