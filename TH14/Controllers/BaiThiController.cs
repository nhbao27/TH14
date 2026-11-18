using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TH14.Models;

namespace TH14.Controllers
{
    public class BaiThiController : Controller
    {
        private readonly QlnhaSachContext db;

        public BaiThiController(QlnhaSachContext db)
        {
            this.db = db;
        }
        private List<Sach> saches;

        public IActionResult Index()
        {
            // Thêm điều kiện x.Gia != null để tránh lỗi khi so sánh dữ liệu Null trong C# / EF
            saches = db.Saches.Where(x => x.Gia != null && x.Gia >= 100).ToList();
            return View(saches);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpGet]
        public IActionResult FilterByCategory(int? maloai)
        {
            var dsHang = db.Saches.AsQueryable();
            if (maloai > 0)
            {
                dsHang = dsHang.Where(h => h.MaTl == maloai);
            }
            return PartialView("PartialList", dsHang.ToList());
        }
    }
}
