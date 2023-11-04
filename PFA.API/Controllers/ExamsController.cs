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
    public class ExamsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ExamsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
          if (_context.Exams == null)
          {
              return NotFound();
          }
            return await _context.Exams.ToListAsync();
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
          if (_context.Exams == null)
          {
              return NotFound();
          }
            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<ExamDTO>> PutExam(ExamDTO exam)
        {
			foreach (ExamEtudiantDTO examEtudiant in exam.ExamEtudiants)
			{
				ExamEtudiant ex = _context.ExamEtudiants.Single(e => e.ExamId == examEtudiant.ExamId && e.EtudiantId == examEtudiant.EtudiantId);
				ex.IsPresent = examEtudiant.IsPresent;
				await _context.SaveChangesAsync();
			}
			return exam;
        }

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            foreach(ExamEtudiant examEtudiant in exam.ExamEtudiants)
            {
                ExamEtudiant ex = _context.ExamEtudiants.Single(e => e.ExamId == examEtudiant.ExamId && e.EtudiantId == examEtudiant.EtudiantId);
                ex.IsPresent = examEtudiant.IsPresent;
				await _context.SaveChangesAsync();
            }

            return exam;
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            if (_context.Exams == null)
            {
                return NotFound();
            }
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
