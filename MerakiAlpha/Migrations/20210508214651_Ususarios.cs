using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerakiAlpha.Migrations
{
    public partial class Ususarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoServicios",
                columns: table => new
                {
                    IdEstadoServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoServicios", x => x.IdEstadoServicio);
                });

            migrationBuilder.CreateTable(
                name: "EstadoUsuarios",
                columns: table => new
                {
                    IdEstadoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoUsuarios", x => x.IdEstadoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TipoCargas",
                columns: table => new
                {
                    IdTipoCarga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCargas", x => x.IdTipoCarga);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentos",
                columns: table => new
                {
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentos", x => x.IdTipoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculos",
                columns: table => new
                {
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculos", x => x.IdTipoVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: true),
                    IdEstadoNavigationIdEstadoUsuario = table.Column<int>(type: "int", nullable: true),
                    IdRolNavigationIdRol = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_EstadoUsuarios_IdEstadoNavigationIdEstadoUsuario",
                        column: x => x.IdEstadoNavigationIdEstadoUsuario,
                        principalTable: "EstadoUsuarios",
                        principalColumn: "IdEstadoUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Roles_IdRolNavigationIdRol",
                        column: x => x.IdRolNavigationIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", nullable: true),
                    Correo = table.Column<string>(type: "varchar(75)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    IdGeneroNavigationIdGenero = table.Column<int>(type: "int", nullable: true),
                    IdTipoDocumentoNavigationIdTipoDocumento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Generos_IdGeneroNavigationIdGenero",
                        column: x => x.IdGeneroNavigationIdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_TiposDocumentos_IdTipoDocumentoNavigationIdTipoDocumento",
                        column: x => x.IdTipoDocumentoNavigationIdTipoDocumento,
                        principalTable: "TiposDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    IdPropietario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    IdGeneroNavigationIdGenero = table.Column<int>(type: "int", nullable: true),
                    IdTipoDocumentoNavigationIdTipoDocumento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.IdPropietario);
                    table.ForeignKey(
                        name: "FK_Propietarios_Generos_IdGeneroNavigationIdGenero",
                        column: x => x.IdGeneroNavigationIdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Propietarios_TiposDocumentos_IdTipoDocumentoNavigationIdTipoDocumento",
                        column: x => x.IdTipoDocumentoNavigationIdTipoDocumento,
                        principalTable: "TiposDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    CodigoV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idColor = table.Column<int>(type: "int", nullable: false),
                    Cilindraje = table.Column<int>(type: "int", nullable: false),
                    Soat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnoMecanica = table.Column<string>(type: "varchar(300)", nullable: true),
                    Placa = table.Column<string>(type: "varchar(8)", nullable: true),
                    FotoV = table.Column<string>(type: "varchar(300)", nullable: true),
                    SeguroCarga = table.Column<string>(type: "varchar(300)", nullable: true),
                    IdPropietario = table.Column<int>(type: "int", nullable: false),
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdPropietarioNavigationIdPropietario = table.Column<int>(type: "int", nullable: true),
                    IdTipoVehiculoNavigationIdTipoVehiculo = table.Column<int>(type: "int", nullable: true),
                    IdMarcasId = table.Column<int>(type: "int", nullable: true),
                    IdColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.CodigoV);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Colores_IdColorId",
                        column: x => x.IdColorId,
                        principalTable: "Colores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Marcas_IdMarcasId",
                        column: x => x.IdMarcasId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Propietarios_IdPropietarioNavigationIdPropietario",
                        column: x => x.IdPropietarioNavigationIdPropietario,
                        principalTable: "Propietarios",
                        principalColumn: "IdPropietario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TipoVehiculos_IdTipoVehiculoNavigationIdTipoVehiculo",
                        column: x => x.IdTipoVehiculoNavigationIdTipoVehiculo,
                        principalTable: "TipoVehiculos",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    IdConductor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "varchar(75)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "Date", nullable: false),
                    FotoConductor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoVNavigationCodigoV = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdGeneroNavigationIdGenero = table.Column<int>(type: "int", nullable: true),
                    IdTipoDocumentoNavigationIdTipoDocumento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.IdConductor);
                    table.ForeignKey(
                        name: "FK_Conductores_Generos_IdGeneroNavigationIdGenero",
                        column: x => x.IdGeneroNavigationIdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conductores_TiposDocumentos_IdTipoDocumentoNavigationIdTipoDocumento",
                        column: x => x.IdTipoDocumentoNavigationIdTipoDocumento,
                        principalTable: "TiposDocumentos",
                        principalColumn: "IdTipoDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conductores_Vehiculos_CodigoVNavigationCodigoV",
                        column: x => x.CodigoVNavigationCodigoV,
                        principalTable: "Vehiculos",
                        principalColumn: "CodigoV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdTipoCarga = table.Column<int>(type: "int", nullable: false),
                    IdTipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    DireccionCarga = table.Column<string>(type: "varchar(100)", nullable: true),
                    DireccionEntrega = table.Column<string>(type: "varchar(100)", nullable: true),
                    PersonaRecibe = table.Column<string>(type: "varchar(100)", nullable: true),
                    CelularRecibe = table.Column<int>(type: "int", nullable: false),
                    IdConductor = table.Column<int>(type: "int", nullable: false),
                    PrecioServicio = table.Column<double>(type: "float", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoServicio = table.Column<int>(type: "int", nullable: false),
                    IdClienteNavigationIdCliente = table.Column<int>(type: "int", nullable: true),
                    IdConductorNavigationIdConductor = table.Column<int>(type: "int", nullable: true),
                    IdEstadoServicioNavigationIdEstadoServicio = table.Column<int>(type: "int", nullable: true),
                    IdTipoCargaNavigationIdTipoCarga = table.Column<int>(type: "int", nullable: true),
                    IdTipoVehiculoNavigationIdTipoVehiculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                    table.ForeignKey(
                        name: "FK_Servicios_Clientes_IdClienteNavigationIdCliente",
                        column: x => x.IdClienteNavigationIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Conductores_IdConductorNavigationIdConductor",
                        column: x => x.IdConductorNavigationIdConductor,
                        principalTable: "Conductores",
                        principalColumn: "IdConductor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_EstadoServicios_IdEstadoServicioNavigationIdEstadoServicio",
                        column: x => x.IdEstadoServicioNavigationIdEstadoServicio,
                        principalTable: "EstadoServicios",
                        principalColumn: "IdEstadoServicio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_TipoCargas_IdTipoCargaNavigationIdTipoCarga",
                        column: x => x.IdTipoCargaNavigationIdTipoCarga,
                        principalTable: "TipoCargas",
                        principalColumn: "IdTipoCarga",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_TipoVehiculos_IdTipoVehiculoNavigationIdTipoVehiculo",
                        column: x => x.IdTipoVehiculoNavigationIdTipoVehiculo,
                        principalTable: "TipoVehiculos",
                        principalColumn: "IdTipoVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdEstadoNavigationIdEstadoUsuario",
                table: "AspNetUsers",
                column: "IdEstadoNavigationIdEstadoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdRolNavigationIdRol",
                table: "AspNetUsers",
                column: "IdRolNavigationIdRol");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdGeneroNavigationIdGenero",
                table: "Clientes",
                column: "IdGeneroNavigationIdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdTipoDocumentoNavigationIdTipoDocumento",
                table: "Clientes",
                column: "IdTipoDocumentoNavigationIdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_CodigoVNavigationCodigoV",
                table: "Conductores",
                column: "CodigoVNavigationCodigoV");

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_IdGeneroNavigationIdGenero",
                table: "Conductores",
                column: "IdGeneroNavigationIdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_IdTipoDocumentoNavigationIdTipoDocumento",
                table: "Conductores",
                column: "IdTipoDocumentoNavigationIdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_IdGeneroNavigationIdGenero",
                table: "Propietarios",
                column: "IdGeneroNavigationIdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_IdTipoDocumentoNavigationIdTipoDocumento",
                table: "Propietarios",
                column: "IdTipoDocumentoNavigationIdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdClienteNavigationIdCliente",
                table: "Servicios",
                column: "IdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdConductorNavigationIdConductor",
                table: "Servicios",
                column: "IdConductorNavigationIdConductor");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdEstadoServicioNavigationIdEstadoServicio",
                table: "Servicios",
                column: "IdEstadoServicioNavigationIdEstadoServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdTipoCargaNavigationIdTipoCarga",
                table: "Servicios",
                column: "IdTipoCargaNavigationIdTipoCarga");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdTipoVehiculoNavigationIdTipoVehiculo",
                table: "Servicios",
                column: "IdTipoVehiculoNavigationIdTipoVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdColorId",
                table: "Vehiculos",
                column: "IdColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdMarcasId",
                table: "Vehiculos",
                column: "IdMarcasId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdPropietarioNavigationIdPropietario",
                table: "Vehiculos",
                column: "IdPropietarioNavigationIdPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdTipoVehiculoNavigationIdTipoVehiculo",
                table: "Vehiculos",
                column: "IdTipoVehiculoNavigationIdTipoVehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "EstadoServicios");

            migrationBuilder.DropTable(
                name: "TipoCargas");

            migrationBuilder.DropTable(
                name: "EstadoUsuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "TipoVehiculos");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");
        }
    }
}
