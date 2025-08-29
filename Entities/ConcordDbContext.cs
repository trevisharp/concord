using Microsoft.EntityFrameworkCore;

namespace Concord.Entities;

public class ConcordDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permition> Permitions => Set<Permition>();
    public DbSet<Member> Members => Set<Member>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>();

        model.Entity<Room>()
            .HasOne(r => r.Creator)
            .WithMany(p => p.CreatedRooms)
            .HasForeignKey(r => r.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Role>()
            .HasOne(r => r.Room)
            .WithMany(r => r.Roles)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Permition>()
            .HasMany(p => p.Roles)
            .WithMany(r => r.Permitions);

        model.Entity<Member>()
            .HasOne(m => m.Profile)
            .WithMany(p => p.Members)
            .HasForeignKey(m => m.ProfileId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Member>()
            .HasOne(m => m.Role)
            .WithMany(r => r.Members)
            .HasForeignKey(m => m.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Member>()
            .HasOne(m => m.Room)
            .WithMany(r => r.Members)
            .HasForeignKey(m => m.RoomId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}