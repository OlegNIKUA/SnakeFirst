﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeFirst
{
   public class SnakePart
    {
       
        
        public int X { get; set; }
        public int Y { get; set; }

        public SnakePart(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        
    }
}
