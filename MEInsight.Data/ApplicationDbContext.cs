using MEInsight.Entities.Core;
using MEInsight.Entities.Programs;
using MEInsight.Entities.Reference;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.RegularExpressions;

namespace MEInsight.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<RefOrganizationType> OrganizationTypes { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<RefLocation> Locations { get; set; }



        //Programs
        public DbSet<Program> Programs { get; set; } = null!;
        public DbSet<ProgramAssessment> ProgramAssessments { get; set; } = null!;
        public DbSet<Entities.Programs.Group> Groups { get; set; } = null!;
        public DbSet<GroupEnrollment> GroupEnrollments { get; set; } = null!;
        public DbSet<GroupEvaluation> GroupEvaluations { get; set; } = null!;


        //Base Entity
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<Organization>().OwnsOne(
                d => d.Data, data =>
                {
                    data.ToJson();
                    data.OwnsOne(a => a.Contacts);
                    data.OwnsMany(a => a.Languages);
                });


            //builder.Entity<Organization>(entity =>
            //{
            //    entity.OwnsOne(e => e.Data, data =>
            //    {
            //        data.ToJson();
            //        data.OwnsOne(d => d.Contacts, contact =>
            //        {
            //            contact.ToJson();

            //        });

            //        data.OwnsOne(d => d.Languages, language =>
            //        {
            //            language.ToJson();
            //        });
            //        data.OwnsOne(d => d.Contacts, contact =>
            //        {
            //            contact.ToJson();

            //        });
            //        data.OwnsMany(d => d.Languages, language =>
            //        {
            //            language.ToJson();
            //        });
            //    });
            //});

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {

            string? userName = null;
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                userName = httpContext.User?.Identity?.Name;
            }

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["IsDeleted"] = false;
                            entry.CurrentValues["CreatedDate"] = DateTimeOffset.UtcNow;
                            entry.CurrentValues["CreatedBy"] = userName;
                            break;

                        case EntityState.Modified:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = false;
                            entry.CurrentValues["CreatedDate"] = entry.GetDatabaseValues()?.GetValue<object>("CreatedDate");
                            entry.CurrentValues["CreatedBy"] = entry.GetDatabaseValues()?.GetValue<object>("CreatedBy");
                            entry.CurrentValues["ModifiedDate"] = DateTimeOffset.UtcNow;
                            entry.CurrentValues["ModifiedBy"] = userName;

                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            //Soft delete cascade
                            entry.CurrentValues["IsDeleted"] = true;
                            entry.CurrentValues["CreatedDate"] = entry.GetDatabaseValues()?.GetValue<object>("CreatedDate");
                            entry.CurrentValues["CreatedBy"] = entry.GetDatabaseValues()?.GetValue<object>("CreatedBy");
                            entry.CurrentValues["ModifiedDate"] = entry.GetDatabaseValues()?.GetValue<object>("ModifiedDate");
                            entry.CurrentValues["ModifiedBy"] = entry.GetDatabaseValues()?.GetValue<object>("ModifiedBy");
                            entry.CurrentValues["DeletedDate"] = DateTimeOffset.UtcNow;
                            entry.CurrentValues["DeletedBy"] = userName;
                            foreach (var navigationEntry in entry.Navigations.Where(x => !((IReadOnlyNavigation)x.Metadata).IsOnDependent))
                            {
                                if (navigationEntry is CollectionEntry collectionEntry)
                                {
                                    foreach (var dependentEntry in collectionEntry.CurrentValue!)
                                    {
                                        HandleDependent(Entry(dependentEntry));
                                    }
                                }
                                else
                                {
                                    var dependentEntry = navigationEntry.CurrentValue;
                                    if (dependentEntry != null)
                                    {
                                        HandleDependent(Entry(dependentEntry));
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }

        private static void HandleDependent(EntityEntry entry)
        {
            entry.CurrentValues["IsDeleted"] = true;
        }

    }
}
