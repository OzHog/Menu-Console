using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Utils : IActionMenuItemObserver
    {
        void IActionMenuItemObserver.SetAction(string i_ActionItemTitle)
        {

            switch (i_ActionItemTitle)
            {
                case "Count Spaces":
                    CountSpaces();
                    break;
                case "Show Version":
                    ShowVersion();
                    break;
                case "Show Date":
                    ShowDate();
                    break;
                case "Show Time":
                    ShowTime();
                    break;

            }
        }

        public void ShowDate()
        {
            DateTime today = DateTime.Today;

            Console.WriteLine(today.ToString("d"));
            Console.ReadKey();
        }

        public void ShowTime()
        {
            DateTime now = DateTime.Now;
            string time = string.Format("{0}:{1}",now.Hour, now.Minute);

            Console.WriteLine(time);
            Console.ReadKey();
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version 20.3.4.8920");
            Console.ReadKey();
        }

        public void CountSpaces()
        {
            int spaceCounter = 0;

            Console.Write("Enter Text: ");
            string text = Console.ReadLine();

            foreach(char ch in text)
            {
                if(char.IsWhiteSpace(ch))
                {
                    spaceCounter++;
                }
            }

            string massageToDisplay = string.Format("Amount Of Spaces: {0}", spaceCounter);

            Console.WriteLine(massageToDisplay);
            Console.ReadKey();
        }
    }
}
