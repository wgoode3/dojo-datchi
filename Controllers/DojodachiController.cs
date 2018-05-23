using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi;

namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        public static Dojodachi dojodachi = new Dojodachi();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string img = (TempData["img"] == null) ? "/imgs/normal.png" : TempData["img"].ToString();
            ViewBag.img = img;
            ViewBag.message = TempData["msg"];
            ViewBag.happiness = dojodachi.happiness;
            ViewBag.fullness = dojodachi.fullness;
            ViewBag.energy = dojodachi.energy;
            ViewBag.meals = dojodachi.meals;
            return View("index");
        }

        [HttpGet]
        [Route("dojodachi/{act}")]
        public IActionResult Action(String act)
        {
            if (act == "feed")
            {
                TempData["msg"] = dojodachi.Feed();
                if (TempData["msg"].ToString().EndsWith(":("))
                {
                    TempData["img"] = "/imgs/badfood.png";
                }
                else
                {
                    TempData["img"] = "/imgs/goodfood.png";
                }
            }
            else if (act == "play")
            {
                TempData["msg"] = dojodachi.Play();
                if (TempData["msg"].ToString().EndsWith(":("))
                {
                    TempData["img"] = "/imgs/badplay.png";
                }
                else
                {
                    TempData["img"] = "/imgs/goodplay.png";
                }
            }
            else if (act == "work")
            {
                TempData["img"] = "/imgs/work.png";
                TempData["msg"] = dojodachi.Work();
            }
            else if (act == "sleep")
            {
                TempData["img"] = "/imgs/sleep.png";
                TempData["msg"] = dojodachi.Sleep();
            }

            if (dojodachi.energy <= 0)
            {
                TempData["img"] = "/imgs/lose.png";
                TempData["msg"] = "Your dojodachi died from lack of energy!";
                return RedirectToAction("EndGame");
            }
            else if (dojodachi.happiness <= 0)
            {
                TempData["img"] = "/imgs/lose.png";
                TempData["msg"] = "Your dojodachi died from unhappiness!";
                return RedirectToAction("EndGame");
            }
            else if (dojodachi.fullness <= 0)
            {
                TempData["img"] = "/imgs/lose.png";
                TempData["msg"] = "Your dojodachi died from starvation!";
                return RedirectToAction("EndGame");
            }
            else if (dojodachi.happiness > 99 && dojodachi.energy > 99 && dojodachi.fullness > 99)
            {
                TempData["img"] = "/imgs/win.png";
                TempData["msg"] = "Your dojodachi loves you. You win forever!";
                return RedirectToAction("EndGame");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("endgame")]
        public IActionResult EndGame()
        {
            string img = (TempData["img"] == null) ? "/imgs/win.png" : TempData["img"].ToString();
            ViewBag.img = img;
            ViewBag.message = TempData["msg"];
            ViewBag.happiness = dojodachi.happiness;
            ViewBag.fullness = dojodachi.fullness;
            ViewBag.energy = dojodachi.energy;
            ViewBag.meals = dojodachi.meals;
            return View("endgame");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            dojodachi = new Dojodachi();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}