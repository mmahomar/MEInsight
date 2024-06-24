using MEInsight.Entities.Core;
using MEInsight.Entities.Programs;
using MEInsight.Entities.Reference;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.RegularExpressions;
using Group = MEInsight.Entities.Programs.Group;

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

        /// <summary>
        /// Core Entities
        /// </summary>
        #region
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<EducationCenter> EducationCenter { get; set; }
        public DbSet<EducationCenterClassroom> EducationCenterClassroom { get; set; }
        public DbSet<EducationCenterEnrollment> EducationCenterEnrollment { get; set; }
        public DbSet<EducationCenterPeriod> EducationCenterPeriod { get; set; }

        #endregion

        /// <summary>
        /// Ref Entities
        /// </summary>
        #region
        public DbSet<RefOrganizationType> OrganizationTypes { get; set; }
        public DbSet<RefLocation> Locations { get; set; } = null!;
        public DbSet<RefLocationType> LocationTypes { get; set; } = null!;
        public DbSet<RefDisabilityType> DisabilityTypes { get; set; } = null!;
        public DbSet<RefEducationCenterAdministrationType> EducationCenterAdministrationTypes { get; set; } = null!;
        public DbSet<RefEducationCenterCluster> EducationCenterClusters { get; set; } = null!;
        public DbSet<RefEducationCenterStatus> EducationCenterStatus { get; set; } = null!;
        public DbSet<RefEducationCenterLocation> EducationCenterLocations { get; set; } = null!;
        public DbSet<RefEducationCenterLanguage> EducationCenterLanguages { get; set; } = null!;
        public DbSet<RefEducationCenterType> EducationCenterTypes { get; set; } = null!;
        public DbSet<RefGradeLevel> GradeLevels { get; set; } = null!;
        public DbSet<RefParticipantType> ParticipantTypes { get; set; } = null!;
        public DbSet<RefParticipantCohort> ParticipantCohorts { get; set; } = null!;
        public DbSet<RefProgramType> ProgramTypes { get; set; } = null!;
        public DbSet<RefSex> Sex { get; set; } = null!;
        #endregion



        /// <summary>
        /// Programs
        /// </summary>
        #region
        public DbSet<Program> Programs { get; set; } = null!;
        public DbSet<ProgramAssessment> ProgramAssessments { get; set; } = null!;
        public DbSet<Entities.Programs.Group> Groups { get; set; } = null!;
        public DbSet<GroupEnrollment> GroupEnrollments { get; set; } = null!;
        public DbSet<GroupEvaluation> GroupEvaluations { get; set; } = null!;


        #endregion

        /// <summary>
        /// Base Entity
        /// </summary>
        #region
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
            builder.Entity<RefDisabilityType>().OwnsOne(
                d => d.Data, data =>
                {
                    data.ToJson();
                    data.OwnsMany(a => a.DisabilityLanguages);
                });
            builder.Entity<RefLocation>().OwnsOne(
              d => d.Data, data =>
              {
                  data.ToJson();
                  data.OwnsMany(a => a.LocationLanguages);
              });
            //Entities.Core
            builder.Entity<Organization>().HasQueryFilter(p => !p.IsDeleted);

            builder.Entity<EducationCenterPeriod>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<EducationCenterEnrollment>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<EducationCenterClassroom>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Participant>().HasQueryFilter(p => !p.IsDeleted);

            //Entities.Programs
            builder.Entity<MEInsight.Entities.Programs.Program>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<ProgramAssessment>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Group>().HasQueryFilter(p => !p.IsDeleted);

            builder.Entity<GroupEnrollment>(entity =>
            {
                entity.HasQueryFilter(p => !p.IsDeleted);
                entity.HasIndex(t => t.ParticipantId);

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.GroupEnrollments)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            builder.Entity<GroupEvaluation>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<GroupEvaluation>().HasIndex(t => t.GroupEnrollmentId);
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
        #endregion

    }
}
