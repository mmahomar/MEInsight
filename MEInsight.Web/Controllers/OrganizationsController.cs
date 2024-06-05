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
    public class OrganizationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Organizations.Include(o => o.Locations).Include(o => o.OrganizationTypes).Include(o => o.ParentOrganizations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = _context.Organizations
                                 .Include(o => o.OrganizationTypes)
                                 .Include(o => o.ParentOrganizations)
                                 .Include(o => o.Locations)
                                 .Include(o => o.Data)
                                     .ThenInclude(d => d.Languages)
                                 .SingleOrDefault(o => o.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId");
            ViewData["RefOrganizationTypeId"] = new SelectList(_context.OrganizationTypes, "RefOrganizationTypeId", "RefOrganizationTypeId");
            ViewData["ParentOrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizationId,Code,OrganizationName,RefOrganizationTypeId,ParentOrganizationId,RefLocationId,Latitude,Longitude,IsOrganizationUnit,Address,RegistrationDate, Data")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                organization.OrganizationId = Guid.NewGuid();
                _context.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId", organization.RefLocationId);
            ViewData["RefOrganizationTypeId"] = new SelectList(_context.OrganizationTypes, "RefOrganizationTypeId", "RefOrganizationTypeId", organization.RefOrganizationTypeId);
            ViewData["ParentOrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", organization.ParentOrganizationId);
            return View(organization);
        }

        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId", organization.RefLocationId);
            ViewData["RefOrganizationTypeId"] = new SelectList(_context.OrganizationTypes, "RefOrganizationTypeId", "RefOrganizationTypeId", organization.RefOrganizationTypeId);
            ViewData["ParentOrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", organization.ParentOrganizationId);
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrganizationId,Code,OrganizationName,RefOrganizationTypeId,ParentOrganizationId,RefLocationId,Latitude,Longitude,IsOrganizationUnit,Address,RegistrationDate, Data")] Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(organization);
                    //await _context.SaveChangesAsync();
                    var existingOrganization = _context.Organizations
                                               .Include(o => o.OrganizationTypes)
                                               .Include(o => o.ParentOrganizations)
                                               .Include(o => o.Locations)
                                               .Include(o => o.Data)
                                                   .ThenInclude(d => d.Languages)
                                               .SingleOrDefault(o => o.OrganizationId == organization.OrganizationId);

                    if (existingOrganization == null)
                    {
                        return NotFound();
                    }

                    existingOrganization.Code = organization.Code;
                    existingOrganization.OrganizationName = organization.OrganizationName;
                    existingOrganization.RefOrganizationTypeId = organization.RefOrganizationTypeId;
                    existingOrganization.ParentOrganizationId = organization.ParentOrganizationId;
                    existingOrganization.RefLocationId = organization.RefLocationId;
                    existingOrganization.Latitude = organization.Latitude;
                    existingOrganization.Longitude = organization.Longitude;
                    existingOrganization.IsOrganizationUnit = organization.IsOrganizationUnit;
                    existingOrganization.Address = organization.Address;
                    existingOrganization.RegistrationDate = organization.RegistrationDate;

                    if (existingOrganization !=null&& organization.Data != null)
                    {
                        existingOrganization.Data.Description = organization.Data.Description;
                        if (organization.Data.Contacts != null)
                        {
                            existingOrganization.Data.Contacts.Phone = organization.Data.Contacts.Phone;
                            existingOrganization.Data.Contacts.Contact = organization.Data.Contacts.Contact;
                        }

                        // Clear existing languages and add the new ones
                        existingOrganization.Data.Languages.Clear();
                        foreach (var language in organization.Data.Languages)
                        {
                            existingOrganization.Data.Languages.Add(new Organization.OrganizationData.Language
                            {
                                LanguageCode = language.LanguageCode,
                                LocaleCode = language.LocaleCode,
                                OrganizationName = language.OrganizationName
                            });
                        }
                    }

                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.OrganizationId))
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
            ViewData["RefLocationId"] = new SelectList(_context.Locations, "RefLocationId", "RefLocationId", organization.RefLocationId);
            ViewData["RefOrganizationTypeId"] = new SelectList(_context.OrganizationTypes, "RefOrganizationTypeId", "RefOrganizationTypeId", organization.RefOrganizationTypeId);
            ViewData["ParentOrganizationId"] = new SelectList(_context.Organizations, "OrganizationId", "OrganizationId", organization.ParentOrganizationId);
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .Include(o => o.Locations)
                .Include(o => o.OrganizationTypes)
                .Include(o => o.ParentOrganizations)
                .FirstOrDefaultAsync(m => m.OrganizationId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                _context.Organizations.Remove(organization);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationExists(Guid id)
        {
            return _context.Organizations.Any(e => e.OrganizationId == id);
        }
    }
}
