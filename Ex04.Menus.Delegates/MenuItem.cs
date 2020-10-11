using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_Title;
        private Menu m_Menu;
        internal event ActionItemDelegate Selected;

        public MenuItem(string i_Title = null)
        {
            m_Title = i_Title;
            m_Menu = null;
            Selected = null;
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
        }
        
        internal void OnSelected()
        {
            Console.Clear();
            if (isActionMenuItem())
            {
                Selected.Invoke();
            }
            else
            {
                m_Menu.Show();
            }
        }

        private bool isActionMenuItem()
        {
            return Selected != null;
        }

        public void Initialize(List<MenuItem> i_SubMenuItems)
        {
            m_Menu = new Menu();
            m_Menu.AddSubMenuItems(i_SubMenuItems);
            Selected = null;
        }

        public void Initialize(ActionItemDelegate i_Selected)
        {
            Selected += i_Selected;
            m_Menu = null;
        }
    }
}
