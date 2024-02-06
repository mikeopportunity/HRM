using HRM.Core.Entities;
using HRM.Core.Extensions;
using HRM.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Reflection;

namespace HRM.DAL
{
    public class HRMContext : DbContext
    {
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employeer> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        public HRMContext(DbContextOptions<HRMContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            var temporaryAuditEntities = await AuditNonTemporaryProperties();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await AuditTemporaryProperties(temporaryAuditEntities);
            return result;
        }

        private async Task<IEnumerable<Tuple<EntityEntry, Audit>>> AuditNonTemporaryProperties()
        {
            ChangeTracker.DetectChanges();
            var entitiesToTrack = ChangeTracker.Entries().Where(e => e.Entity is IAuditable && e.State != EntityState.Detached && e.State != EntityState.Unchanged);

            await Audits.AddRangeAsync(
                entitiesToTrack.Where(e => !e.Properties.Any(p => p.IsTemporary)).Select(e => new Audit()
                {
                    TableName = e.Metadata.GetDefaultTableName(),
                    Action = Enum.GetName(typeof(EntityState), e.State),
                    ChangeDate = DateTime.Now.ToUniversalTime(),
                    ChangeUserName = "user",//тут можно получать UserName по Identity из HttpContext'a,
                    KeyValues = JsonConvert.SerializeObject(e.Properties.Where(p => p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()),
                    NewValues = JsonConvert.SerializeObject(e.Properties.Where(p => e.State == EntityState.Added || e.State == EntityState.Modified).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()),
                    OldValues = JsonConvert.SerializeObject(e.Properties.Where(p => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToDictionary(p => p.Metadata.Name, p => p.OriginalValue).NullIfEmpty())
                }).ToList()
            );

            return entitiesToTrack.Where(e => e.Properties.Any(p => p.IsTemporary))
                 .Select(e => new Tuple<EntityEntry, Audit>(
                     e,
                 new Audit()
                 {
                     TableName = e.Metadata.GetDefaultTableName(), 
                     Action = Enum.GetName(typeof(EntityState), e.State),
                     ChangeDate = DateTime.Now.ToUniversalTime(),
                     ChangeUserName = "user",
                     NewValues = JsonConvert.SerializeObject(e.Properties.Where(p => !p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty())
                 }
                 )).ToList();
        }

        private async Task AuditTemporaryProperties(IEnumerable<Tuple<EntityEntry, Audit>> temporaryAuditEntities)
        {
            if (temporaryAuditEntities != null && temporaryAuditEntities.Any())
            {
                await Audits.AddRangeAsync(
                temporaryAuditEntities.ForEach(t => t.Item2.KeyValues = JsonConvert.SerializeObject(t.Item1.Properties.Where(p => p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()))
                    .Select(t => t.Item2)
                );
                await SaveChangesAsync();
            }
            await Task.CompletedTask;
        }
    }
}
