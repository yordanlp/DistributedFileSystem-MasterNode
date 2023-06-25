using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterServer.Models {
    public class File {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfChunks { get; set; }
        public int Size { get; set; }
        public List<Chunk> Chunks { get; set; }

    }
}
