using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal interface IMenuUIObserver
    {
        void MenuOptionSelected(int i_MenuOptionNumber);
    }
}
