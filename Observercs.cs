using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignments
{
    public class Window
    {

        Button clearBtn = new Button();
        TextBox searchBtn = new TextBox();

        public Window()
        {
            Action _command = new Action(clrBtnClick);
            clearBtn.AddObserver(_command);
        }


        public void Show()
        {
           Console.WriteLine("Window Painted...");
        }

        private void clrBtnClick()
        {
            searchBtn.Clear();
        }
        public void btnClickSimulation()
        {
            clearBtn.OnClick();
        }


    }

      
    public class Button
    {
        Action Observer;
        public void OnClick()
        {
                Console.WriteLine("Button clicked...");
                this.NotifyObserver();
        }

        public void AddObserver(Action observer)
        {
                this.Observer += observer;
        }
        public void RemoveObserver(Action observer)
        {
                this.Observer -= observer;

        }
        private void NotifyObserver()
        {
            if (Observer != null)
            {

                    Observer.Invoke();
            }
            else
            {
                    Console.WriteLine("Not Subscribed");
            }

        }

    }
    public class TextBox
    {
        public void Clear()
        {
                Console.WriteLine("TextBox Content Cleared......");
        }
    }
    class Observer
    {
        static void Main()
        {
                Window Win = new Window();

                Win.Show();
                while (true)
                {
                    Win.btnClickSimulation();
                    System.Threading.Thread.Sleep(500);
                }
        }
    }

    
    
}
