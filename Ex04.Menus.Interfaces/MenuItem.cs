using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private Menu m_Menu;
        private IActionMenuItemObserver m_ActionItemObserver;

        public MenuItem(string i_Title = null)
        {
            m_Title = i_Title;
            m_ActionItemObserver = null;
            m_Menu = null;
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        internal void OnSelected()
        {
            Console.Clear();
            if (isActionMenuItem())
            {
                m_ActionItemObserver.SetAction(m_Title);
            }
            else
            {
                m_Menu.Show();
            }
        }

        public void Initialize(List<MenuItem> i_SubMenuItems)
        {
            m_Menu = new Menu();
            m_Menu.AddSubMenuItems(i_SubMenuItems);
            m_ActionItemObserver = null;
        }

        private bool isActionMenuItem()
        {
            return m_ActionItemObserver != null;
        }

        public void Initialize(IActionMenuItemObserver i_ActionMenuItemObserver)
        {
            m_ActionItemObserver = i_ActionMenuItemObserver;
            m_Menu = null;
        }

    }
}
