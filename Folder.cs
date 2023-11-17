using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_11_16
{
    public class Folder
    {
        //[(primary)Key] nebutina nurodyti nes EntityFrmwrk pats mato
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<File> Files { get; set; }

    }
}
