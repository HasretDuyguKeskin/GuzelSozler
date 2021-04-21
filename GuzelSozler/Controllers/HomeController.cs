using GuzelSozler.Data;
using GuzelSozler.Extensions;
using GuzelSozler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GuzelSozler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }
        // Navigation property ler Include edilmeli
        public IActionResult Index()
        {
            return View(_db.GuzelSozler.Include(x=>x.Begenenler).ToList());
        }

        [Authorize]//sadece üyeler kullanabilir
        [HttpPost]
        public IActionResult BegeniDurumunuGuncelle(int id, bool begenildiMi)
        {
            try
            {
                string userId = User.GetUserId();
                //Kullanici kul = _db.Users.Find(userId);
                var begeni = new KullaniciSoz() { GuzelSozId = id, KullaniciId = userId };
                //_db.Entry(begeni).State = begenildiMi ? EntityState.Added : EntityState.Deleted;

                if (begenildiMi)
                {
                    if (!_db.KullaniciSozler.Contains(begeni))
                    {
                        _db.KullaniciSozler.Add(begeni);
                    }
                }
                else
                {
                    if (_db.KullaniciSozler.Contains(begeni))
                    {
                        _db.KullaniciSozler.Remove(begeni);
                    }
                }
                _db.SaveChanges();

                return new EmptyResult();
            }
            catch (Exception)
            {

                return BadRequest(); ;
            }

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
