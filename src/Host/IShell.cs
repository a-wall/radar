﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    public interface IShell
    {
        void Show();
        void Close();
        void Shutdown();
    }
}
