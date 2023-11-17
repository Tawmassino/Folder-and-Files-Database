using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_11_16
{
    public class File
    {
        //[(primary)Key] nebutina nurodyti nes EntityFrmwrk pats mato
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullDirectory { get; set; }

        public int Size { get; set; }

    }
}
