using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.API.DTOs;
using PFA.Library.Models;
using PFA.Library.Services;

namespace PFA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EtudiantsController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("IsUserExists/{id}")]
        public async Task<ActionResult<bool>> IsUserExists(int id)
        {
            return _context.Etudiants.Any(e=>e.Id== id);
        }
        // GET: api/Etudiants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> GetEtudiants()
        {
          if (_context.Etudiants == null)
          {
              return NotFound();
          }
            return await _context.Etudiants.ToListAsync();
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetEtudiant(int id)
        {
          if (_context.Etudiants == null)
          {
              return NotFound();
          }
            var etudiant = await _context.Etudiants.FindAsync(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return etudiant;
        }

        // PUT: api/Etudiants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Etudiants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etudiant>> PostEtudiant(Etudiant etudiant)
        {
          if (_context.Etudiants == null)
          {
              return Problem("Entity set 'DatabaseContext.Etudiants'  is null.");
          }
            _context.Etudiants.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.Id }, etudiant);
        }
        [HttpGet("LoginWithApp/{numeroApp}")]
        public async Task<ActionResult<LoginResponse>> LoginWithApp(string numeroApp)
        {
            LoginResponse loginResponse = new();
            if (!_context.Etudiants.Any(e => e.N_Apo == numeroApp))
                return loginResponse;
            loginResponse.IsValid= true;
            Etudiant etudiant=_context.Etudiants.Single(e => e.N_Apo == numeroApp);
            foreach (var examEtudiant in etudiant.ExamEtudiants)
            {
                var dd = examEtudiant.Exam.DateDebut;
                var df = examEtudiant.Exam.DateFin;
                var salle = examEtudiant.SalleId;
                var tables = examEtudiant.Table;

                loginResponse.Appointments.Add(new Appointment()
                {
                    title = $"{examEtudiant.Exam.Label.ToUpper()}  {dd.ToString("HH:mm")} => {df.ToString("HH:mm")}",
                    startDate= dd.ToString("yyyy-MM-ddTHH:mm"),
                    endDate= df.ToString("yyyy-MM-ddTHH:mm")

                });
                //fill exam details
                loginResponse.ExamDetails.Add(new ExamDetails()
                {
                    DayDate = dd.ToString("yyyy-MM-dd"),
                    Matie = examEtudiant.Exam.Label,
                    StartDate = dd.ToString("HH:mm"),
                    EndDate = df.ToString("HH:mm"),
                    Salles = examEtudiant.Salle.Label,
                    Table = examEtudiant.Table
                });
            }
            loginResponse.Nom = etudiant.Nom;
            loginResponse.Prenom=etudiant.Prenom;
            loginResponse.NumeroApp = etudiant.N_Apo;

            return loginResponse;
        }
     
        [HttpGet("Login/{login}/{password}")]
        public async Task<ActionResult<Etudiant>> Login(string login, string password)
        {
            var etudiant = _context.Etudiants.SingleOrDefault(e => e.Login == login && e.Password == password, null);
            if (etudiant == null)
                return NotFound();
            return etudiant;
        }

     

       

        [HttpGet("GetSchedulerData1/{id}")]
        public async Task<ActionResult<List<object>>> GetSchedulerData1(int id)
        {
            List<object> schedulerData = new List<object>();

            foreach (var examEtudiant in _context.Etudiants.Find(id).ExamEtudiants)
            {
                var dd = examEtudiant.Exam.DateDebut;
                var df = examEtudiant.Exam.DateFin;

                var schedulerEvent = new
                {
                    startDate = dd.ToString("yyyy-MM-ddTHH:mm"),
                    endDate = df.ToString("yyyy-MM-ddTHH:mm"),
                    title = examEtudiant.Exam.Label
                };

                schedulerData.Add(schedulerEvent);
            }

            return schedulerData;
        }
      
        
            [HttpGet("ExamnDetails/{id}")]
        public async Task<ActionResult<List<object>>> ExamnDetails(int id)
        {
            List<object> Datas = new List<object>();

            var etudiant = await _context.Etudiants.FindAsync(id); // Rechercher l'étudiant par ID
             
            if (etudiant != null)
            {
                foreach (var examEtudiant in etudiant.ExamEtudiants)
                {
                    var dd = examEtudiant.Exam.DateDebut;
                    var df = examEtudiant.Exam.DateFin;
                    var salle = examEtudiant.SalleId;
                    var tables = examEtudiant.Table;

                    var sal = await _context.Salles.FindAsync(salle);
                    var dataevent = new
                    {
                        dayDate = dd.ToString("yyyy-MM-dd"),
                        startDate = dd.ToString("HH:mm"),
                        endDate = df.ToString("HH:mm"),
                        matie = examEtudiant.Exam.Label.ToUpper(),
                        salles = sal.Label.ToUpper(),
                        table = tables.ToString(),

                    };

                    Datas.Add(dataevent);
                }
            }
            else
            {
                return NotFound(); 
            }

            return Datas;
        }


        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(int id)
        {
            if (_context.Etudiants == null)
            {
                return NotFound();
            }
            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtudiantExists(int id)
        {
            return (_context.Etudiants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
