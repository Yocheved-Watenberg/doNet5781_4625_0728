﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    internal interface IEnumerable
    {
        //   void AddLine(Line lineToAdd);
        IEnumerator<Line> GetEnumerator();
    }
}
