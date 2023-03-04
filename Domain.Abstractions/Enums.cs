using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public enum FoodState
    {
        Open = 0,
        Closed = 1,
        Postponed = 2,
        Impossible = 3,
    }
}
