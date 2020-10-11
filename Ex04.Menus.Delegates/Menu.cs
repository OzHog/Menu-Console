using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    internal class Menu
    {
        protected readonly List<MenuItem> r_SubMenuItems;
        protected MenuUI m_UI;
        protected bool m_Enabled;

        internal Menu(string i_ExitMenuText = "Back")
        {
            r_SubMenuItems = new List<MenuItem>(0);
            m_UI = new MenuUI();
            m_UI.ExitMenuText = i_ExitMenuText;
            m_UI.NotificationDelegate += this.menuOption_Selected;
        }

        internal void Show()
        {
            m_Enabled = true;

            while (m_Enabled)
            {
                Console.Clear();
                m_UI.Display();
            }
        }

        internal void AddSubMenuItems(List<MenuItem> i_SubMenuItems)
        {
            foreach(MenuItem menuItem in i_SubMenuItems)
            {
                r_SubMenuItems.Add(menuItem);
                m_UI.AddItemToDisplay(menuItem.Title);
            }
        }

        private void menuOption_Selected(int i_MenuOptionNumber)
        {
            if (i_MenuOptionNumber == 0)
            {
                Close();
            }
            else
            {
                r_SubMenuItems[i_MenuOptionNumber - 1].OnSelected();
            }
        }

        internal void Close()
        {
            m_Enabled = false;
            Console.Clear();
        }
    }
}
