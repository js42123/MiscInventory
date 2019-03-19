using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiscInventory.Models;
using ConsultantContractsInternal.Utilities;
using AHPSystem.Helpers;


namespace MiscInventory.Controllers
{
    public class MiscInventoryController : Controller
    {
        private MISC_INVENTORYEntities1 db = new MISC_INVENTORYEntities1();
       
        private List<string> _availbudgs;
        private object _allowuser;

        enum PagingListType
        {
            Index
        }

        // GET: /MiscInventory/
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            //This is how we get the security set for user and budgets they can see
            _allowuser = GetUser();

            _availbudgs = GetBudgets().ToList();
            //Sets up the form to search 
            {
                var model = new InventorySearch();
                model.page = page;

                if (Session["budgs"] != null)
                    model.BUD = (string)Session["budgs"];
                if (Session["INV_TYPE"] != null)
                    model.INV_TYPE = (string)Session["INV_TYPE"];
                if (Session["LOC"] != null)
                    model.LOC = (string)Session["LOC"];
                if (Session["INV_DESC"] != null)
                    model.INV_DESC = (string)Session["INV_DESC"];
                if (Session["VCHR_NO"] != null)
                    model.VCHR_NO = (string)Session["VCHR_NO"];
                if (Session["ID_R"] != null)
                    model.ID_R = (string)Session["ID_R"];
                if (Session["FromSearchDate"] != null)
                    model.FromSearchDate = (DateTime)Session["FromSearchDate"];
                if (Session["ToSearchDate"] != null)
                    model.ToSearchDate = (DateTime)Session["ToSearchDate"];

                if (Session["query"] != null)
                {
                    //paging display code
                    var query = Session["query"] as List<Models.T115_MISC_INVENTORY>;
                    model.page = model.page <= 0 ? 1 : model.page;
                    ViewBag.CurrentPage = model.page;
                    ViewBag.PagingList = SharedFunctions.PagerArray(model.page, SharedFunctions.PerPage, query.Count(), this, "Index", "MiscInventory");
                    var pagingList = query
                         .OrderBy(p => p.ID_R)
                        .ThenBy(p => p.DOC_DATE)
                        .Skip((model.page - 1) * SharedFunctions.PerPage)
                        .Take(SharedFunctions.PerPage)
                        .ToList<Models.T115_MISC_INVENTORY>();
                    model.SearchResults = pagingList;
                }
                using (var db = new Models.MISC_INVENTORYEntities1())
                {

                    //using view bags to display the search form 
                    PopulateViewBagLists(db);
                    return View(model);
                }
            }
        }

        //this is where we are getting the user data from the system for security. If user isn't found throw exception!
    private object GetUser()
        {
            object useView = null;
            {
                if (Session["Budgets"] == null)
                {
                    using (var db = new SYSTEM_SECURITYEntities())
                    {
                        //  var user = HttpContext.Request.LogonUserIdentity.Name;
                        //  var idx = user.IndexOf('\\');

                        //  user = user.Substring(idx + 1);

                        int index = User.Identity.Name.IndexOf('\\');
                        string userID = User.Identity.Name.Substring(index + 1);

                        var query = db.T000_SYSTEM_SEC.Where(g => g.FUNCTIONAL_AREA == "WMIN" && g.SYSTEM_ID == "MISC" && g.USERID_R == userID && g.BUDGET != "");
                        if (query.Count() >= 1)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            throw new HttpException(404, "You do not have access to this page");
                        }
                    }
                }
                else
                {
                    useView = (List<string>)Session["Budgets"];
                }
                return useView;
            }
        }



        //POST: /MiscInventory/SearchResults
        [HttpPost]
        public ActionResult Index(Models.InventorySearch data)
        {
            using (var db = new MISC_INVENTORYEntities1())
            
            {
                var availbudgs = GetBudgets();
                PopulateViewBagLists(db);

                if (data != null
                   && (data.FromSearchDate == null || data.FromSearchDate.Equals(DateTime.MinValue))
                   && (data.ToSearchDate == null || data.ToSearchDate.Equals(DateTime.MinValue))
                   && (data.BUD == null)
                   && (data.ID_R == null)
                   && (data.INVENTORY_TYPE == null)
                   && (data.LOC == null)
                   && (data.INV_DESC == null)
                   && (data.VCHR_NO == null))
                {
                    if (Session["budgs"] != null)
                        data.BUD = (string)Session["budgs"];
                    if (Session["INV_TYPE"] != null)
                        data.INV_TYPE = (string)Session["INV_TYPE"];
                    if (Session["LOC"] != null)
                        data.LOC = (string)Session["LOC"];
                    if (Session["INV_DESC"] != null)
                        data.INV_DESC = (string)Session["INV_DESC"];
                    if (Session["VCHR_NO"] != null)
                        data.VCHR_NO = (string)Session["VCHR_NO"];
                    if (Session["ID_R"] != null)
                        data.ID_R = (string)Session["ID_R"];
                    if (Session["FromSearchDate"] != null)
                        data.FromSearchDate = (DateTime)Session["FromSearchDate"];
                    if (Session["ToSearchDate"] != null)
                        data.ToSearchDate = (DateTime)Session["ToSearchDate"];
                    if (Session["query"] != null)
                    {
                        var query = new List<Models.T115_MISC_INVENTORY>();
                        data.page = data.page <= 0 ? 1 : data.page;
                        ViewBag.CurrentPage = data.page;
                        ViewBag.PagingList = SharedFunctions.PagerArray(data.page, SharedFunctions.PerPage, query.Count(), this, "Index", "MiscInventory");
                        var pagingList = query
                             .OrderBy(p => p.ID_R)
                             .ThenBy(p => p.DOC_DATE)
                            .Skip((data.page - 1) * SharedFunctions.PerPage)
                            .Take(SharedFunctions.PerPage)
                            .ToList<Models.T115_MISC_INVENTORY>();
                        data.SearchResults = pagingList;
                    }
                }
                else
                {
                    data.SearchResults = new List<Models.T115_MISC_INVENTORY>();

                    IQueryable<Models.T115_MISC_INVENTORY> query = GetSearchResults(data, db, PagingListType.Index);
                    data.page = data.page <= 0 ? 1 : data.page;
                    ViewBag.CurrentPage = data.page;
                    ViewBag.PagingList = SharedFunctions.PagerArray(data.page, SharedFunctions.PerPage, query.Count(), this, "Index", "MiscInventory");
                    Session["query"] = query.ToList<T115_MISC_INVENTORY>();
                    if (data.FromSearchDate != DateTime.MinValue)
                        Session["FromSearchDate"] = data.FromSearchDate;
                    if (data.ToSearchDate != DateTime.MinValue)
                        Session["ToSearchDate"] = data.ToSearchDate;
                    if (data.BUD != null)
                        Session["budgs"] = data.BUD;
                    if (data.INV_TYPE != null)
                        Session["INV_TYPE"] = data.INV_TYPE;
                    if (data.LOC != null)
                        Session["LOC"] = data.LOC;
                    if (data.VCHR_NO != null)
                        Session["INV_DESC"] = data.VCHR_NO;
                    if (data.INV_DESC != null)
                        Session["VCHR_NO"] = data.INV_DESC;
                    if (data.ID_R != null)
                        Session["ID_R"] = data.ID_R;

                    query = query
                        .OrderBy(p => p.ID_R)
                        .ThenBy(p => p.DOC_DATE)
                         .Skip((data.page - 1) * SharedFunctions.PerPage)
                         .Take(SharedFunctions.PerPage)
                         .Select(c => c);
                    if (data.SearchResults == null)
                        data.SearchResults = new List<T115_MISC_INVENTORY>();

                    foreach (Models.T115_MISC_INVENTORY temp
                        in query)
                    {
                        data.SearchResults.Add(temp);
                    }
              
                }
                
            }
         return View(data);
        }
        //used to get the budgets to display for each user. Each user has certain budgets
        private IEnumerable<string> GetBudgets()
        {
            IEnumerable<string> result = null;
            {
                if (Session["Budgets"] == null)
                {
                    using (var db = new SYSTEM_SECURITYEntities())
                    {
                        //var user = HttpContext.Request.LogonUserIdentity.Name;
                        //  var idx = user.IndexOf('\\');
                        //TO DO Using Lesa's Login until later
                        //user = user.Substring(idx + 1);
                        //user = "LAFA335";

                        int index = User.Identity.Name.IndexOf('\\');
                        string userID = User.Identity.Name.Substring(index + 1);

                        var query = db.T000_SYSTEM_SEC.Where(g => g.FUNCTIONAL_AREA == "WMIN" && g.SYSTEM_ID == "MISC" && g.USERID_R == userID && g.BUDGET == "000").OrderByDescending(g => g.BUDGET);
                        if (query.Count() >= 1)
                        {
                            result = db.T000_SYSTEM_SEC.Where(g => g.FUNCTIONAL_AREA == "WMIN" && g.SYSTEM_ID == "MISC" && g.BUDGET != "000")
                                .OrderBy(s => s.BUDGET)
                                .Select(s => s.BUDGET).ToList();
                        }
                        else
                        {
                            result = db.T000_SYSTEM_SEC.Where(g => g.FUNCTIONAL_AREA == "WMIN" && g.SYSTEM_ID == "MISC" && g.USERID_R == userID)
                                    .OrderBy(s => s.BUDGET)
                                     .Select(s => s.BUDGET).ToList();
                        }
                    }
                }
                else
                {
                    result = (List<string>)Session["Budgets"];
                }
                return result;
            }
        }

        // This is to populate the search fields 
        private void PopulateViewBagLists(MISC_INVENTORYEntities1 db)
        {

            ViewBag.BUD = GetBudgets().Distinct().Select(m => new SelectListItem { Value = m, Text = m });
            var inventoryType = new Dictionary<string, string>() { { " ", "Not Specified"}, { "C", "Computer" }, { "5", "Engineering Equipment" }, { "8", "Heating/Cooling" }, {"4", "Lab Equipment"},
                {"7", "Media Equipment"}, {"9", "Office Equip"}, {"2", "Radio/Pagers"}, {"3", "Reproduction Equipment"}, {"B", "Research/Dev Equip"}, {"1", "Shop Equipment/Tools"}, {"6", "Traffic Recorders"}, {"A", "Weapons/Scales"}};
            ViewBag.INV_TYPE = inventoryType.Select(m => new SelectListItem { Text = m.Value, Value = m.Key }).ToList();
            ViewBag.INV_DESC = db.T115_MISC_INVENTORY.ToList().Select(m => new SelectListItem { Value = m.INV_DESC, Text = m.INV_DESC }).ToList();
            ViewBag.LOC = db.T115_MISC_INVENTORY.ToList().Select(m => new SelectListItem { Value = m.LOC, Text = m.LOC }).ToList();
            ViewBag.VCHR_NO = db.T115_MISC_INVENTORY.ToList().Select(m => new SelectListItem { Value = m.VCHR_NO, Text = m.VCHR_NO }).ToList();
            ViewBag.ID_R = db.T115_MISC_INVENTORY.ToList().Select(m => new SelectListItem { Value = m.ID_R, Text = m.ID_R }).ToList();
        }
        // GET: /MiscInventory/Create

        public ActionResult Create(T115_MISC_INVENTORY model)
        {
            using (var db = new Models.MISC_INVENTORYEntities1())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.T115_MISC_INVENTORY.Add(model);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception)
                    {
                    }
                }
                var inventorySearch = new InventorySearch();
                return View("Index", inventorySearch);
            }
        }

        //Query for inventory search results to display 

        private IQueryable<Models.T115_MISC_INVENTORY> GetSearchResults(Models.InventorySearch data, MISC_INVENTORYEntities1 db, PagingListType pagingListType)
        {
            IQueryable<Models.T115_MISC_INVENTORY>
                query = db.T115_MISC_INVENTORY;

            if (!(data.FromSearchDate.Equals(DateTime.MinValue) && data.ToSearchDate.Equals(DateTime.MinValue)))
            {
                query = query.Where(c => c.DOC_DATE > data.FromSearchDate && c.DOC_DATE <= data.ToSearchDate);
            }
            if (!(data.BUD == null || data.BUD.Equals("")))
            {
                query = query.Where(c => c.BUD.Contains(data.BUD));
            };
            if (!(data.INV_TYPE == null || data.INV_TYPE.Trim().Equals("")))
            {
                query = query.Where(c => c.INV_TYPE.Contains(data.INV_TYPE));
            };
            if (!(data.INV_DESC == null || data.INV_DESC.Equals("")))
            {
                query = query.Where(c => c.INV_DESC.Contains(data.INV_DESC));
            };
            if (!(data.LOC == null || data.LOC.Equals("")))
            {
                query = query.Where(c => c.LOC.Contains(data.LOC));
            };
            if (!(data.VCHR_NO == null || data.VCHR_NO.Equals("")))
            {
                query = query.Where(c => c.VCHR_NO.Contains(data.VCHR_NO));
            };
            if (!(data.ID_R == null || data.ID_R.Equals("")))
            {
                query = query.Where(c => c.ID_R.Contains(data.ID_R));
            };
            if (!(data.PURCH_MM == null || data.PURCH_MM.Equals("")))
            {
                query = query.Where(c => c.PURCH_MM.Contains(data.PURCH_MM));
            };
            if (!(data.PURCH_YY == null || data.PURCH_YY.Equals("")))
            {
                query = query.Where(c => c.PURCH_YY.Contains(data.PURCH_YY));
            }

            ViewBag.CurrentPage = data.page;
            if (pagingListType == PagingListType.Index)
                ViewBag.PagingList = SharedFunctions.PagerArray(data.page, SharedFunctions.PerPage, query.Count(), this, "Index", "MiscInventory");

            if (data.SortOrder == "DESCENDING")
            {
                switch (data.SortingBy)
                {
                    case "ID_R":
                        query = query.OrderByDescending(c => c.ID_R)
                            .ThenByDescending(c => c.DOC_DATE);
                        break;
                    case "DOC_DATE":
                        query = query.OrderByDescending(c => c.DOC_DATE)
                            .ThenByDescending(c => c.ID_R);
                        break;
                    default:
                        query = query.OrderByDescending(c => c.ID_R)
                            .ThenByDescending(c => c.DOC_DATE);
                        break;
                }
            }
            else if (data.SortOrder == "ASCENDING")
            {
                switch (data.SortingBy)
                {
                    case "ID_R":
                        query = query.OrderByDescending(c => c.ID_R)
                            .ThenByDescending(c => c.DOC_DATE);
                        break;
                    case "DOC_DATE":
                        query = query.OrderByDescending(c => c.DOC_DATE)
                            .ThenByDescending(c => c.ID_R);
                        break;
                    default:
                        query = query.OrderBy(c => c.ID_R)
                            .ThenBy(c => c.DOC_DATE);
                        break;
                }
            }
            return query;
        }

        //GET: /MiscInventory/Transactions and Trans Archive/Results are displayed based on click of details button on inventory data

        [HttpGet]
        public ActionResult TransSearchResults(string id)
        {
            ReturnArgs ra = new ReturnArgs();

            using (var db = new MISC_INVENTORYEntities1())
            {
                List<T115_MISC_TRANS> trans = db.T115_MISC_TRANS.Where(p => p.ID_R.Equals(id.TrimEnd())).ToList();
                List<T115_MISC_TRAN_ARCHV> arch = db.T115_MISC_TRAN_ARCHV.Where(p => p.ID_R.Equals(id.TrimEnd())).ToList();

                ra.Status = 200;

                if (trans != null && trans.Count > 0)
                {
                    ra.ViewString = RazorViewToString.RenderViewToString(this, "TransSearchResults", trans);
                }
                else if (arch != null && arch.Count > 0)
                {
                    ra.ViewString = RazorViewToString.RenderViewToString(this, "ArchSearchResults", arch);
                }
                else
                {
                    ra.Status = 300;
                    ra.ViewString = "";
                }
                return Json(ra, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ArchSearchResults(string id)
        {
            ReturnArgs ra = new ReturnArgs();

            using (var db = new MISC_INVENTORYEntities1())
            {
               
                List<T115_MISC_TRAN_ARCHV> arch = db.T115_MISC_TRAN_ARCHV.Where(p => p.ID_R.Equals(id.TrimEnd())).ToList();

                ra.Status = 200;

                if (arch != null && arch.Count > 0)
                {
                    ra.ViewString = RazorViewToString.RenderViewToString(this, "ArchSearchResults", arch);
                }
                else
                {
                    ra.Status = 300;
                    ra.ViewString = "";
                }
                return Json(ra, JsonRequestBehavior.AllowGet);
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
   

   
 