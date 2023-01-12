﻿using Microsoft.EntityFrameworkCore;
using ProdutosApi.Domain.Entities;
using ProdutosApi.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto do EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        /// <summary>
        /// Método para definir o caminho do banco de dados (ConnectionString)
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProdutosApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        /// <summary>
        /// Provedor de métodos para o repositorio (CRUD)
        /// </summary>
        public DbSet<Categoria> Categoria { get; set; }

        /// <summary>
        /// Provedor de métodos para o repositorio (CRUD)
        /// </summary>
        public DbSet<Produto> Produto { get; set; }
    }
}
