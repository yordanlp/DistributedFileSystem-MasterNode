using MasterServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterServer {
    public class AppDbContext : DbContext {
        public DbSet<File> Files { get; set; }
        public DbSet<Chunk> Chunks { get; set; }
        public DbSet<ChunkServer> ChunkServers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}
