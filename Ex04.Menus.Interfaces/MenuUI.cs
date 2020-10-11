using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class MenuUI
    {
        private readonly List<string> r_ItemsTitle;
        private readonly int r_MinValue;
        private string m_ExitMenuText;
        internal IMenuUIObserver m_MenuUIObserver;

        internal MenuUI()
        {
            r_ItemsTitle = new List<string>(0);
            m_ExitMenuText = "Back";
            r_MinValue = 0;
        }

        internal string ExitMenuText
        {
            get
            {
                return m_ExitMenuText;
            }
            set
            {
                m_ExitMenuText = value;
            }
        }

        public int MaxValue
        {
            get
            {
                return r_ItemsTitle.Count;
            }
        }

        internal void Display()
        {
            bool legalInput = false;
            string userInput = null;

            showMenu();
            while(!legalInput)
            {
                userInput = getUserInput();
                try
                {
                    legalInput = isUserInputLegal(userInput);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }

            int menuOptionNumber = int.Parse(userInput);

            onMenuOptionSelect(menuOptionNumber);
        }
        
        private void onMenuOptionSelect(int i_MenuOptionNumber)
        {
            m_MenuUIObserver.MenuOptionSelected(i_MenuOptionNumber);
        }
        
        private void showMenu()
        {
            int menuOptionNumber = 1;
            foreach(string itemTitle in r_ItemsTitle)
            {
                string menuOptionText = createMenuOptionText(menuOptionNumber, itemTitle);
                Console.WriteLine(menuOptionText);
                menuOptionNumber++;
            }

            string exitOptionStr = createMenuOptionText(0, m_ExitMenuText);
            Console.WriteLine(exitOptionStr);
        }

        private static string getUserInput(string i_InputLabel = ">>")
        {
            Console.Write("{0} ", i_InputLabel);

            return Console.ReadLine();
        }
        
        internal void AddItemToDisplay(string i_ItemTitle)
        {
            r_ItemsTitle.Add(i_ItemTitle);
        }

        private static string createMenuOptionText(int i_MenuOptionNumber, string i_ItemTitle)
        {
            return string.Format("{0}. {1}", i_MenuOptionNumber, i_ItemTitle);
        }

        private bool isUserInputLegal(string i_UserInput)
        {
            bool inputLegal = int.TryParse(i_UserInput, out int intInput);

            if (inputLegal)
            {
                
                inputLegal = intInput <= MaxValue && intInput >= r_MinValue;
                if (!inputLegal)
                {
                    throw new ValueOutOfRangeException(MaxValue, r_MinValue);
                }
            }
            else
            {
                throw new ValueNotNumericalException(i_UserInput);
            }

            return inputLegal;
        }

        internal void AttachObserver(IMenuUIObserver i_MenuUIObserver)
        {
            m_MenuUIObserver = i_MenuUIObserver;
        }
    }
}
