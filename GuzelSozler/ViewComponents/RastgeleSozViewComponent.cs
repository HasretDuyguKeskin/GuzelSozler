using GuzelSozler.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozler.ViewComponents
{
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0
    public class RastgeleSozViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public RastgeleSozViewComponent(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool enYeniyiGoster = false)
        {
            if (enYeniyiGoster)
            {
                return View(await _db.GuzelSozler.OrderByDescending(x => x.Id).LastOrDefaultAsync());
            }
            int adet = _db.GuzelSozler.Count();
            int indexs = new Random().Next(adet);
            GuzelSoz soz = await _db.GuzelSozler.Skip(indexs).FirstOrDefaultAsync();
            return View(soz);
        }
    }
}
