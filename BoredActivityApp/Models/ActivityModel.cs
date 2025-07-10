using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoredActivityApp.Models;

public class ActivityModel
{
    public string Activity { get; set; }
    public string Type { get; set; }
    public int Participants { get; set; }
    public double Price { get; set; }
    public double Accessibility { get; set; }
    public int Key { get; set; }
    public double? Link { get; set; } // API ponekad vraća null
    public int? Duration { get; set; }
    public bool? KidFriendly => (Accessibility < 0.5);
}
