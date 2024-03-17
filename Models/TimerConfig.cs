using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTimers.Models
{
    public class TimerConfig
    {
        public bool IsEnabled { get; set; }
        public double Duration { get; set; }
        public string? ModifierKeybind { get; set; }
        public string? Keybind { get; set; }
    }
}
