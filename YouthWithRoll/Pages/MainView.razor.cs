using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthWithRoll.Models;

namespace YouthWithRoll.Pages
{
    public partial class MainView
    {
        public List<Trainer> Trainers { get; set; }

        public MainView()
        {
            Trainers = new List<Trainer>() { new Trainer() {
                Name = "ABC",
                Id=1,
                PicName = "trainer-data/dzm.jpg"
                
            } 
            };
        }
    }
}
