using MerakiAlpha.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerakiAlpha.Models
{
    public class MerakiContext : DbContext
    {
        public MerakiContext(DbContextOptions<MerakiContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioIdentity> UsuariosIdentity { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EstadoUsuario> EstadoUsuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conductore> Conductores { get; set; }
        public DbSet<EstadoServicio> EstadoServicios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoCarga> TipoCargas { get; set; }
        public DbSet<TiposDocumento> TiposDocumentos { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Color> Colores { get; set; }

    }
}
