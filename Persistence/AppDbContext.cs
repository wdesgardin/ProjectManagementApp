using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public override int SaveChanges()
        {
            SetDtOnTrackedEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetDtOnTrackedEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetDtOnTrackedEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetDtOnTrackedEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetDtOnTrackedEntities()
        {
            var currentDt = DateTime.Now;
            SetCreateDtOnTrackedEntities(currentDt);
            SetEditDtOnTrackedEntities(currentDt);
        }

        private void SetCreateDtOnTrackedEntities(DateTime dt)
        {
            var trackedEntities = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity).OfType<ITrackCreateDt>();

            foreach (var entity in trackedEntities)
            {
                entity.CreateDt = dt;
            }
        }

        private void SetEditDtOnTrackedEntities(DateTime dt)
        {
            var trackedEntities = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity).OfType<ITrackEditDt>();

            foreach (var entity in trackedEntities)
            {
                entity.EditDt = dt;
            }
        }


    }
}