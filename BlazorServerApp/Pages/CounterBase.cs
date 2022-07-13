using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public class CounterBase:ComponentBase
    {
        private int currentCount = 0;

        public int CurrentCount { get => currentCount; set => currentCount = value; }

        public void IncrementCount()
        {
            currentCount++;
        }
    }
}
