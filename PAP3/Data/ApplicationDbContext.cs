using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PAP3.Models;

namespace PAP3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetalhesPedido> DetalhesPedidos { get; set; }

        public DbSet<ProdutosTag> ProdutosTags { get; set; }

        public DbSet<CloudTag> CloudTags { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutosTag>()
                .HasKey(bc => new { bc.TagId, bc.ProdutoId });
            modelBuilder.Entity<ProdutosTag>()
                .HasOne(bc => bc.Produto)
                .WithMany(b => b.ProdutosTags)
                .HasForeignKey(bc => bc.ProdutoId);
            modelBuilder.Entity<ProdutosTag>()
                .HasOne(bc => bc.CloudTag)
                .WithMany(c => c.ProdutosTags)
                .HasForeignKey(bc => bc.TagId);
        }

    }



}
