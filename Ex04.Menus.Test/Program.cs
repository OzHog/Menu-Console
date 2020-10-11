using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// $G$ SFN-004 (-3) You should display the type of menu (interface or delegate) each time we are at the main menu.
// $G$ SFN-004 (-3) You should display the title of each sub menu.

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            startMenus();
        }

        private static void startMenus()
        {
            Interfaces.MainMenu mainMenuInterfaces = createInterfacesMainMenu();
            Delegates.MainMenu mainMenuDelegates = createDelegateMainMenu();
            mainMenuInterfaces.Show();
            mainMenuDelegates.Show();
        }

        private static Interfaces.MainMenu createInterfacesMainMenu()
        {
            Utils actions = new Utils();
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu();
            List<Interfaces.MenuItem> subMenuItems = new List<Interfaces.MenuItem>();

            Interfaces.MenuItem versionAndSpacesMenu = new Interfaces.MenuItem("Version and Spaces");
            Interfaces.MenuItem countAction = new Interfaces.MenuItem("Count Spaces");
            countAction.Initialize(actions as Interfaces.IActionMenuItemObserver);
            Interfaces.MenuItem showVersionAction = new Interfaces.MenuItem("Show Version");
            showVersionAction.Initialize(actions as Interfaces.IActionMenuItemObserver);

            subMenuItems.Add(countAction);
            subMenuItems.Add(showVersionAction);
            versionAndSpacesMenu.Initialize(subMenuItems);
            subMenuItems.Clear();

            Interfaces.MenuItem showDateTimeMenu = new Interfaces.MenuItem("Show Date/Time");
            Interfaces.MenuItem dateAction = new Interfaces.MenuItem("Show Date");
            dateAction.Initialize(actions as Interfaces.IActionMenuItemObserver);
            Interfaces.MenuItem timeAction = new Interfaces.MenuItem("Show Time");
            timeAction.Initialize(actions as Interfaces.IActionMenuItemObserver);

            subMenuItems.Add(dateAction);
            subMenuItems.Add(timeAction);
            showDateTimeMenu.Initialize(subMenuItems);
            subMenuItems.Clear();


            subMenuItems.Add(versionAndSpacesMenu);
            subMenuItems.Add(showDateTimeMenu);
            mainMenu.Initialize(subMenuItems);
            return mainMenu;
        }

        private static Delegates.MainMenu createDelegateMainMenu()
        {
            Utils actions = new Utils();
            Delegates.MainMenu mainMenu = new Delegates.MainMenu();
            List<Delegates.MenuItem> subMenuItems = new List<Delegates.MenuItem>();

            Delegates.MenuItem versionAndSpacesMenu = new Delegates.MenuItem("Version and Spaces");
            Delegates.MenuItem countAction = new Delegates.MenuItem("Count Spaces");
            Delegates.MenuItem showVersionAction = new Delegates.MenuItem("Show Version");
            countAction.Initialize(new Delegates.ActionItemDelegate(actions.CountSpaces));
            showVersionAction.Initialize( new Delegates.ActionItemDelegate(actions.ShowVersion));
            subMenuItems.Add(countAction);
            subMenuItems.Add(showVersionAction);
            versionAndSpacesMenu.Initialize(subMenuItems);
            subMenuItems.Clear();

            Delegates.MenuItem showDateTimeMenu = new Delegates.MenuItem("Show Date/Time");
            Delegates.MenuItem dateAction = new Delegates.MenuItem("Show Date");
            Delegates.MenuItem timeAction = new Delegates.MenuItem("Show Time");
            dateAction.Initialize(new Delegates.ActionItemDelegate(actions.ShowDate));
            timeAction.Initialize(new Delegates.ActionItemDelegate(actions.ShowTime));
            subMenuItems.Add(dateAction);
            subMenuItems.Add(timeAction);
            showDateTimeMenu.Initialize(subMenuItems);
            subMenuItems.Clear();

            subMenuItems.Add(versionAndSpacesMenu);
            subMenuItems.Add(showDateTimeMenu);
            mainMenu.Initialize(subMenuItems);

            return mainMenu;
        }
    }
}
