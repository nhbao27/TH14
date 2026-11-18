using Microsoft.AspNetCore.Mvc;
using TH14.Models;

namespace TH14.ViewComponents
{
    public class MenuHeaderViewComponent:ViewComponent
    {
        private readonly QlnhaSachContext db;
        private List<TheLoai> theLoais;
        public MenuHeaderViewComponent(QlnhaSachContext db)
        {
            theLoais = db.TheLoais.ToList();
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Menu", theLoais);
        }
    }
}
