using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using YouthWithRoll.Models;

namespace YouthWithRoll.Pages
{
    public partial class MainView
    {
        public List<Trainer> Trainers { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        public MainView()
        {
            Trainers = new List<Trainer>();
        }

        protected override async Task OnInitializedAsync()
        {
            Trainers = (await Http.GetFromJsonAsync<Trainer[]>("trainer-data/trainers.json")).ToList();
            Trainers.Sort((a,b)=>a.Id-b.Id);
            foreach(var trainer in Trainers)
            {
                trainer.PicName = "trainer-data/" + trainer.PicName;
            }
            Console.WriteLine(Trainers.Count);
        }
    }
}
