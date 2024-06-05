using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MEInsight.Data;
using MEInsight.Entities.Core;

namespace MEInsight.Web.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Participants.Include(p => p.Locations).Include(p => p.Organizations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .Include(p => p.Locations)
                .Include(p => p.Organizations)
                .FirstOrDefaultAsync(m => m.ParticipantId == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId");
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId");
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipantId,RegistrationDate,OrganizationId,RefParticipantTypeId,ParticipantCode,FirstName,MiddleName,LastName,RefSexId,BirthDate,Age,Disability,RefDisabilityTypeId,Phone,Mobile,Email,Facebook,InstantMessenger,RefLocationId,Address,AdditionalData")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                participant.ParticipantId = Guid.NewGuid();
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId", participant.RefLocationId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", participant.OrganizationId);
            return View(participant);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId", participant.RefLocationId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", participant.OrganizationId);
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ParticipantId,RegistrationDate,OrganizationId,RefParticipantTypeId,ParticipantCode,FirstName,MiddleName,LastName,RefSexId,BirthDate,Age,Disability,RefDisabilityTypeId,Phone,Mobile,Email,Facebook,InstantMessenger,RefLocationId,Address,AdditionalData")] Participant participant)
        {
            if (id != participant.ParticipantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.ParticipantId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId", participant.RefLocationId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", participant.OrganizationId);
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .Include(p => p.Locations)
                .Include(p => p.Organizations)
                .FirstOrDefaultAsync(m => m.ParticipantId == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(Guid id)
        {
            return _context.Participants.Any(e => e.ParticipantId == id);
        }
    }
}
