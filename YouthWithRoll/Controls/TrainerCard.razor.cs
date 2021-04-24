using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouthWithRoll.Models;

namespace YouthWithRoll.Controls
{
    public partial class TrainerCard
    {
        public int TestNumber { get; set; } = 2;

        [Parameter]
        public Trainer TrainerModel { get; set; }
    }
}
