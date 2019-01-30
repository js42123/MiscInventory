using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiscInventory.Models
{
    public class TransSearch
    {
        public string transaction { get; set; }

        public string TRANS { get; set; }
        public string INV_TYPE { get; set; }
        public Nullable<System.DateTime> INV_DATE { get; set; }
        public Nullable<System.TimeSpan> INV_TIME { get; set; }
        public string TRANS_USERID { get; set; }
        public string ID_R { get; set; }
        public string INV_DESC { get; set; }
        public string BUD { get; set; }
        public string SERIAL_NO { get; set; }
        public string REPLC_SERIAL_NO { get; set; }
        public string LOC { get; set; }
        public string SUB_LOC { get; set; }
        public string PURCH_YY { get; set; }
        public string PURCH_MM { get; set; }
        public Nullable<System.DateTime> DOC_DATE { get; set; }
        public decimal COST { get; set; }
        public decimal DEPR { get; set; }
        public string FEDID { get; set; }
        public string SUB_TYPE { get; set; }
        public string REQ_NO { get; set; }
        public string VCHR_NO { get; set; }
        public string MANUFAC_MODL_NO { get; set; }
        public string MANUFAC_NAME { get; set; }
        public string COMMENT { get; set; }
        public string UT_VCHR_NO { get; set; }
        public string T115_MISC_TRANS_PRIMARY_KEY { get; set; }
        public string VALUE_STATUS { get; set; }
        public string T115_MISC_INVENTORYT115_MISC_INVENTORY_PRIMARY_KEY { get; set; }
        public List<TransSearch> SearchResults { get; set; }
        public string count { get; set; }
        public List<T115_MISC_TRAN_ARCHV> arch { get; set; }
        public List<T115_MISC_TRANS> trans { get; set; }

        public virtual ICollection<T115_MISC_INVENTORY> T115_MISC_INVENTORY { get; set; }
        public virtual ICollection<T115_MISC_TRAN_ARCHV> T115_TRAN_ARCHV { get; set; }
    }
}