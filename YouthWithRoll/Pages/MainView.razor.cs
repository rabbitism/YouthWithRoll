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
        private List<(int, int)> _rankOrders = new List<(int, int)>();
        private int _level = 0;
        private Random _random = new Random();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();

        public List<Trainer> RankedTrainers { get; set; } = new List<Trainer>();

        public string Tooltip = string.Empty;

        [Inject]
        private HttpClient Http { get; set; }

        public MainView()
        {
            
        }

        protected override async Task OnInitializedAsync()
        {
            Trainers = (await Http.GetFromJsonAsync<Trainer[]>("trainer-data/trainers.json")).ToList();
            Trainers.Sort((a,b)=>a.Id-b.Id);
            foreach(var trainer in Trainers)
            {
                trainer.PicName = "trainer-data/" + trainer.PicName;
            }
            _level = 0;
            InitializeRanks();
            Tooltip = GetNextIntervalTooltip(_level);
        }

        public void Roll()
        {
            if (_level >= _rankOrders.Count)
            {
                return;
            }
            (int, int) interval = _rankOrders[_level];
            for(int i = interval.Item1; i>interval.Item2; i--)
            {
                int index = _random.Next(Trainers.Count-1);
                Trainer trainer = Trainers[index];
                trainer.Rank = i;
                Trainers.RemoveAt(index);
                RankedTrainers.Add(trainer);
            }
            RankedTrainers.Sort((a, b) => a.Rank - b.Rank);
            _level++;
            Tooltip = GetNextIntervalTooltip(_level);
            if (_level == _rankOrders.Count)
            {

            }
        }

        public async void Reset()
        {
            RankedTrainers = new List<Trainer>();
            await OnInitializedAsync();
            _level = 0;
            Tooltip = GetNextIntervalTooltip(_level);
        }

        private void InitializeRanks()
        {
            _rankOrders = new List<(int, int)>()
            {
                (119,110), (110,100), (100,90), (90,80), (80,70), (70,62),(62,61),(61,60),(60,59),(59,58),
                (58,50),(50,40),(40,36),(36,35),(35,34),(34,33),
                (33,30),(30,21),(21,20),(20,19),(19,18),
                (18,12),(8,7),(7,6),(6,5),(5,4),(4,3),(3,2),(2,1),(1,0),
                (12,11),(11,10),(10,9),(9,8)
            };
        }

        private string GetNextIntervalTooltip(int level)
        {
            if(level == _rankOrders.Count)
            {
                return "恭喜摇号成团！";
            }
            else
            {
                (int, int) interval = _rankOrders[level];
                if (interval.Item1 - interval.Item2 == 1)
                {
                    return $"第{interval.Item1}名";
                }
                else
                {
                    return $"第{interval.Item1}-{interval.Item2+1}名";
                }
            }
        }
    }
}
