using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Ev
    {

        //public delegate void EventHandler(object sender, MyEventArgs e);
        public event EventHandler<MyEventArgs> StateChanged;

        private int state;

        public int State
        {
            get
            { return state; }
            set
            {
                state = value;
                StateChanged(this, new MyEventArgs(state));
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
         {
            Ev e = new Ev();
            e.StateChanged += E_StateChanged;
            e.State = 10;
         }

        private static void E_StateChanged(object sender, MyEventArgs e)
        {
            Console.WriteLine("State Changed to {0}",e.State);
        }

        public static void TestSwitchFallThrough()
        {
            DateTime dt = DateTime.Today;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("Today is a weekday");
                    break;
                default:
                    Console.WriteLine("Today is a weekend day");
                    break;
            }
        }
        private static void TryCatchFinallyTest()
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText("data.txt");
                Console.WriteLine(sr.ReadToEnd());
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }

    public class MyEventArgs:EventArgs
    {
        public int State { set; get; }
        public MyEventArgs(int state)
            {
            State = state;
            }
    }
}
