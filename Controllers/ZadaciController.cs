
using Microsoft.AspNetCore.Mvc;
using Todos.Models;

namespace Todos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ZadaciController : ControllerBase
    {
        private readonly ZadaciContext _db;

        public ZadaciController(ZadaciContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetZadaci()
        {
            var zadaci = _db.Zadacis.ToList();
            return Ok(zadaci);
        }

        // get podatke odredjenog tipa
        [HttpGet]
        public IActionResult getZadatakbyId(int id)
        {
            Zadaci rezultat = _db.Zadacis.Where(a => a.Id == id).FirstOrDefault();
            if (rezultat == null)
            {
                return NotFound("Zadatak nije pronadjen.");
            }

            return Ok(rezultat);
        }

        [HttpDelete]
        public IActionResult DeleteZadatakbyId(int id)
        {
            Zadaci rezultat = _db.Zadacis.Where(a => a.Id == id).FirstOrDefault();

            if(rezultat == null)
            {
                return NotFound("Zadatak se ne nalazi u BP.");
            }
            _db.Remove(rezultat);
            _db.SaveChanges();


            return Ok(rezultat);
        }

        [HttpPost]
         public IActionResult AddZadatak([FromBody] Zadaci zadaci)
        {
            //_db.Zadacis.Add(new Zadaci { NazivZadatka = zadaci.NazivZadatka  ,Stanje = zadaci.Stanje});

            //_db.SaveChanges();
            Zadaci noviZadatak = new Zadaci();
            noviZadatak.NazivZadatka = zadaci.NazivZadatka;
            noviZadatak.Stanje = zadaci.Stanje;

            _db.Add(noviZadatak);
            _db.SaveChanges();

            return Ok(noviZadatak);
        }
        [HttpPut ]
        public IActionResult EditZadaci([FromBody] Zadaci zadaci, int id)
        {
            var editZadatak = _db.Zadacis.Find(id);
            if (editZadatak == null)
            {
                return BadRequest("Nije pronadjen");
            }
            editZadatak.NazivZadatka = zadaci.NazivZadatka;
            editZadatak.Stanje = zadaci.Stanje;

            _db.SaveChanges();
            return Ok("Zadatak uspjesno editovan");
        }
    }
}
