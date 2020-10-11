using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public sealed class MainMenu 
    {
        private Menu m_Menu;
        
        public MainMenu()
        {
            m_Menu = null;
        }

        public void Initialize(List<MenuItem> i_SubMenuItems)
        {
            m_Menu = new Menu("Exit");
            m_Menu.AddSubMenuItems(i_SubMenuItems);
        }

        public void Show()
        {
            if (m_Menu != null)
            {
                m_Menu.Show();
            }
        }

    }
}
