using System;
using System.Xml.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Dynamic;

namespace DICE
{
    class Program
    {
        public class ArrDie
        {
            private Die[] die1;
            public ArrDie(int NewNum)
            {
                this.die1 = new Die[NewNum];
                for (int i = 0; i < NewNum; i++)
                {
                    Console.WriteLine("input mimad: ");
                    int mimad = int.Parse(Console.ReadLine());
                    this.die1[i] = new Die(mimad);
                }

            }

            public int Gettotal()
            {
                int total = 0;
                for (int i = 0; i < this.die1.Length; i++)
                {
                    total += this.die1[i].GetVal();
                }
                Random rnd = new Random();
                int x = rnd.Next(1, 101);
                Console.WriteLine("Random % => {0}", x);
                Console.WriteLine("total => ", total);
                Console.WriteLine("after (total % X) => ", total % x);

                // פה יש איזו שהיא בעיה הטוטאל לא מחבר את כל הציונים ביחד   
                // הפונקציה צריכה להחזיר את הערך טוטאל בכל הקוביות מודולו המספר הרנדומלי

                return (total % x);
            }
        }

        public class Die
        {
            private int mimad;
            private int val;
            public Die(int mimad)
            {
                this.mimad = mimad;
                Random rnd = new Random();
                this.val = rnd.Next(1, this.mimad + 1);
                Console.WriteLine("Dice=> {0}", this.val);
            }
            /*public Die()
            {
                this.x = x;
                if (x == 1)
                {
                    this.str = "\n|__*__|";
                }
                if (x == 2)
                {
                    this.str = "|__*__|\n|__*__|";
                }
                if (x == 3)
                {
                    this.str = "\n|__*__|\n|__*__|\n|__*__|";
                }
                if (x == 4)
                {
                    this.str = "\n|_*_*_|\n|_*_*_|";
                }
                if (x == 5)
                {
                    this.str = "\n|_*_*_|\n|__*__|\n|_*_*_|";
                }
                if (x == 6)
                {
                    this.str = "\n|_*_*_|\n|_*_*_|\n|_*_*_|";
                }
            }*/
            public void SetVal(int x)
            {
                this.val = x;
            }
            public int Getmimad()
            {
                return this.mimad;
            }
            public int GetVal()
            {
                return this.val;
            }

        }
        public class Game
        {
            private int pnum;
            private int[] arrPoints;
            private string[] ArrName;
            public Game()
            {
                Console.WriteLine("how much plyers?");
                int NewPnum = int.Parse(Console.ReadLine());

                this.pnum = NewPnum;
                this.ArrName = new string[this.pnum];
                this.arrPoints = new int[this.pnum];
                for (int i = 0; i < this.ArrName.Length; i++)
                {
                    Console.WriteLine("player {0} input your name: ", i + 1);
                    this.ArrName[i] = Console.ReadLine();
                }
                for (int i = 0; i < this.ArrName.Length; i++)
                {
                    Console.WriteLine("Player {0}: {1}", i + 1, this.ArrName[i]);
                }

                Console.WriteLine("\n___________");
                Play();
            }
            public string GetArrName(int index)
            {
                string str = "";

                str += this.ArrName[index];

                return str;
            }

            public void Play()
            {
                for (int i = 0; i < this.pnum; i++)
                {
                How_Much_Cube:
                    Console.WriteLine("{0} How Much Cube You Whant: ", this.ArrName[i]);
                    int numofdices = int.Parse(Console.ReadLine());
                    try
                    {
                        if (numofdices <= 0)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Number Must Be > 0");
                        goto How_Much_Cube;
                    }

                    ArrDie d1 = new ArrDie(numofdices);
                    this.arrPoints[i] = d1.Gettotal();
                }

            }
            public string Winner()
            {
                Console.WriteLine("\t________________Scoreboard___________________");
                for (int i = 0; i < this.ArrName.Length; i++)
                {
                    Console.WriteLine("\tplayer: {0} | you have: {1} points.", this.ArrName[i], this.arrPoints[i]);

                }
                string winner ="";
                for (int i = 0; i < this.arrPoints.Length - 1; i++)
                {
                    if (this.arrPoints[i] > this.arrPoints[i + 1])
                    {
                        winner = this.ArrName[i];
                    }
                    else
                    {
                        winner = this.ArrName[i+1];
                    }
                }
                return "\tMazel Tov !!winner : " + winner+" !!!"+"\n\t_____________________________________________";
            }
            /*   
                   //  System.Threading.Thread.Sleep(1500);
                   Console.WriteLine("{0} Rolling Dice..", name);
                   //   System.Threading.Thread.Sleep(2000);
                   Random rnd = new Random();
                   int r = rnd.Next(1, this.n + 1);
                   Die di1 = new Die(r);
                   Console.WriteLine(di1);
                   Console.WriteLine("\njust a sec >>\n");
                   //  System.Threading.Thread.Sleep(1500);
                   Console.WriteLine("Computer Rolling Dice..");
                   //   System.Threading.Thread.Sleep(2000);
                   Random rnd2 = new Random();
                   int r2 = rnd.Next(1, this.n + 1);
                   Die di2 = new Die(r2);
                   Console.WriteLine(di2);

                   if (di1.GetX() > di2.GetX())
                       Console.WriteLine("VERY GOOD! \n{0} Win!", name);
                   else if (di1.GetX() < di2.GetX())
                       Console.WriteLine("Ohhh! \nComputer Win!");
                   else
                       Console.WriteLine("== Equality! ==");
                   char a;
                   Console.WriteLine("Play Agine? y/n");
                   a = char.Parse(Console.ReadLine());
                   if (a == 'y' || a == 'Y')

                   if (a == 'n' || a == 'N')
                       goto finish;
                   else
                   {
                       throw new Exception();
                   }
               finish: Console.WriteLine("GOODBAY!");
               }
               public override string ToString()
               {
                   return this.str + "\n";
               }
               */


            public bool Win()
            {
                for (int i = 0; i < this.arrPoints.Length; i++)
                {
                    if (this.arrPoints[i] > 1000)
                    {
                        return true;
                    }
                }
                return false;
            }



        }
        static void Main(string[] args)
        {
            Game g1 = new Game();
            Console.WriteLine(g1.Winner());
        } 
    }
           

}


