using AdminSeguridad.Models;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("name=DefaultConnection") 
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Permiso> Permisos { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<PermisoMenu> PermisosMenus { get; set; }
    public DbSet<UsuarioPermiso> UsuariosPermisos { get; set; }

    // Configuración adicional
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configurar llaves compuestas
        modelBuilder.Entity<PermisoMenu>()
            .HasKey(pm => new { pm.MenuID, pm.PermisoID });

        modelBuilder.Entity<UsuarioPermiso>()
            .HasKey(up => new { up.UsuarioID, up.PermisoID });

        base.OnModelCreating(modelBuilder); // Llama al método base si es necesario
    }
}

