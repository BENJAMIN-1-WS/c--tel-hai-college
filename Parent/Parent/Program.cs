using System;
using System.Collections.Generic;
using System.Linq;

namespace Parent
{
    class Program
    {
        public class Student
        {
            private int id;// מספר סידורי סטודנט
            private string name;//שם סטודנט
            private string phonenum;//טלפון סטודנט
            private Parent parent;//אבא של הסטודנט
            public Student(string name, string phonenum, Parent parent, int id)//בנאי סטודנט
            {
                this.id = id;// מספר סידורי סטודנט
                this.name = name;//שם סטודנט
                this.phonenum = phonenum;//טלפון סטודנט
                this.parent = parent;// אבא של הסטודנט
            }
            public Student(Student s)// בנאי מעתיק
            {
                this.id = s.GetId();
                this.name = s.GetName();
                this.phonenum = s.GetphoneNum();
                this.parent = s.GetParent();
            }
            public int GetId() { return this.id; }// מחזיק מספר סידורי סטודנט
            public string GetName() { return this.name; }//מחזיר שם סטודנט
            public string GetphoneNum() { return this.phonenum; }//מחזיר טלפון סטודנט
            public Parent GetParent() { return this.parent; }//מחזיר אבא של סטודנט
            public void SetPhoneNum(string phone) { this.phonenum = phone; }//שינוי טלפון של סטודנט
            public override string ToString()//מדפיס סטודנט + אבא
            {
                return "\tStudent name: " + this.name + " | phonenum: " + this.phonenum + " | id: " +this.id + " (" + this.parent + ")";
            }
        }

        public class Parent
        {
            private string id;//ת.זהות אבא 
            private string name;// שם האבא
            private string cellnum;// טלפון של האבא
            public Parent(string name, string cellnum, string id)// בנאי אבא 
            {
                this.id = id;
                this.name = name;
                this.cellnum = cellnum;
            }
            public Parent(Parent p)//בנאי מעתיק אבא
            {
                this.id = p.GetId();
                this.name = p.GetName();
                this.cellnum = p.GetCellNum();
            }
            public string GetId() { return this.id; }//מחזיר ת.זהות אבא
            public string GetName() { return this.name; }//מחזיר שם אבא
            public string GetCellNum() { return this.cellnum; }//מחזיר טלפון אבא
            public void SetCellNum(string s) { this.cellnum = s; }//שינוי טלפון אבא 
            public override string ToString()// מדפיס אבא
            {
                return "Parent name: " + this.name + " | cellnum: " + this.cellnum + " | id: " + this.id;
            }
        }
        public static void input_Parent_Stdent()
        {
            start: try
            {   
                Console.WriteLine("\tParent Please Put Your Name:");
                string name = Console.ReadLine();
                Console.WriteLine("\tParent Please Put Your id:");
                string id = Console.ReadLine();
                Console.WriteLine("\tParent Please Put Your cell Phone:");
                string cellnum = Console.ReadLine();
                Parent p1 = new Parent(name, cellnum, id);
                Console.WriteLine("_________________");

                Console.WriteLine("\tStdent Please Put Your Name:");
                string NameStdent = Console.ReadLine();
                Console.WriteLine("\tStdent Please Put Your id:");
                int idStdent = int.Parse(Console.ReadLine());
                Console.WriteLine("\tStdent Please Put Your cell Phone:");
                string phonenum = Console.ReadLine();
                Student s1 = new Student(NameStdent, phonenum, p1, idStdent);
                string NameStdent2 = "aaa";
                Student s2 = new Student(NameStdent2, phonenum, p1, idStdent);
                Studentlist L1 = new Studentlist(70);
                L1.AddStudent(s1);
                L1.AddStudent(s2);

                Console.WriteLine("\n" + p1);
                Console.WriteLine("_________________");
                Console.WriteLine(s1);
                Console.WriteLine( L1.ToString());
                bool bo = true;
                do{
                   
                    Console.WriteLine("You Want To Add One More Again (Y/N)?");
                    char check = char.Parse(Console.ReadLine());
                    if (check == 'y' || check == 'Y')
                        bo = true;
                    if (check == 'N' || check == 'n')
                        bo = false;
                } while (bo);

            }
                
            catch(Exception)
            {
                to_try: 
                Console.WriteLine("Somting Worng!");
                Console.WriteLine("You Want To try Again (Y/N)?");
                char check = char.Parse(Console.ReadLine());
                if (check == 'y' || check == 'Y')
                    goto start;
                if (check == 'N' || check == 'n')
                    Console.WriteLine("END");
                else
                    goto to_try;
            }

        }
        public class Studentlist
        {
            private int max;
            private Student[] students;
            private int pos;
            public Studentlist(int max)
            {
                this.max = max;
                this.students = new Student[max];
                this.pos = 0;
            }
            public void AddStudent(Student st)
            {
                for (int i = 0; i < pos; i++)
                {
                    if (this.students[i].GetName().CompareTo(this.students[i + 1]) == -1)
                    {
                        for (int j = 0; j < pos; j++)
                        {
                            students[pos] = students[pos-1]; 
                            students[pos - 1] = new Student(st);
                        }
                    }
                    if (this.students[i].GetName().CompareTo(this.students[i + 1]) == 1)
                    {
                        this.students[pos++] = new Student(st);
                    }
                    if (this.students[i].GetName().CompareTo(this.students[i + 1]) == 0)
                    {
                        this.students[pos++] = new Student(st);
                    }
                }
            }
            public string DelStudent(int id)
            {
                for (int i = 0; i < this.students.Length; i++)
                {
                    if (id == this.students[i].GetId())
                        return this.students[i].ToString();
                }
                return "null";
            }
            public int GetStudent(int id)
            {
                for (int i = 0; i < this.students.Length; i++)
                {
                    if (id == this.students[i].GetId())
                        return i;
                }
                return -100;
            }
            public override string ToString()
            {
                string str = "list: ";
                for (int i = 0; i <this.pos; i++)
                {
                    str += $"\n  " + i+1 + " : " + this.students[i];
                }
                return str;
            }
        }
        static void Main(string[] args)
        {
           
            try
            {
                int x = 9;
                List<Student> n = new List<Student>();
                for (int i = 0; i < 900; i++)
                {
                  strings e = new strings();
                  Parent p= new Parent(i+e.RandomString(10), e.RandomString(10), e.RandomString(10));
                Student s = new Student(e.RandomString(10), e.RandomString(10), p, e.RandomNumber(2134,323444));

                n.Add(s);
                }
                    var listAlphabetically=  n.OrderBy(x => x.GetName());
                foreach (Student i in listAlphabetically)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine(n.Count());

            } 
            catch (Exception)
            {   
                Console.WriteLine("Somting Worng!");
                //הפעלה מחדש
            }
            finally
            {
                Console.WriteLine("all is good!");
            }
        }
    }
}
