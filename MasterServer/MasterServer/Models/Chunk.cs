using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterServer.Models {
    public class Chunk {
        public int Id { get; set; }
        public int FileId { get; set; }
        public int ChunkNumber { get; set; }
        public File File { get; set; }
        public string ChunkServerUrl { get; set; }
    }
}
