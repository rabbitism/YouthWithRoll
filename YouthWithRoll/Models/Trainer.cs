using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouthWithRoll.Models
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string PicName { get; set; }
        public int Rank { get; set; } = 0;
    }
}
