using System;

namespace TIME_PRO
{
    class Time
    {
        private int hour;
        private int min;
        private Time time;
        
        public Time(int h,int m)
        {
            this.min = m;
            this.hour = h;
        }
        public Time()
        {
            this.min = 00;
            this.hour = 8;
        }
        public override string ToString()
        {
            if (this.min < 10)
            {
                return this.hour + ":0" + this.min;
            } 
            return this.hour + ":" + this.min;
        }
        public int GetH()
        {
            return this.hour;
        }
        public int GetM()
        {
            return this.min;
        }
        public Time(Time t)
        {
            this.hour = t.GetH();
            this.min = t.GetM();
        }


        public int dis(Time time)
        {
            return Math.Abs((this.hour * 60 + this.min) - (time.GetH() * 60 + time.GetM()));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Time t = new Time(9, 3);
            Console.WriteLine(t);
        }
    }
}
