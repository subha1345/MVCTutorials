using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCTutorial.Controllers
{
    public class HomeController : Controller
    {
        CancellationTokenSource _token = null;
        public delegate void SomeMethodPtr();
        

        public ActionResult Index()
        {
            //ReverseWords("Hello");
            //Palindrom("noon");
            //Test();
            //DelegateClass obj = new DelegateClass();
            //obj.LongRunning(CallBack);
            //ReverseString("auto");
            //SkipCount(100);
            //TestDelegate();
            //--CancellationToken
            //Task.Run(() => Click());
            return View();

        }

        public void CallBack(int i)
        {
            Console.WriteLine(i);
        }

        #region delegate
        //delegate is a representative to communicate between two parties
        //we can pass method as parameter using delegate
        public class DelegateClass
        {
            public delegate void CallBack(int i);
            public void LongRunning(CallBack obj)
            {
                for (int i = 0; i < 1000; i++)
                {
                    obj(i);
                }
            }
        }
        //---------------------------------------------------------------
        public void delegateMethod()
        {
            SomeMethodPtr obj = new SomeMethodPtr(SomeMethod);
            obj.Invoke();
        }

        public void SomeMethod()
        {
            Console.WriteLine("Method Invoked");
        }
        #endregion

        #region passMethodasParameter

        public int Method1(string input)
        {
            return 0;
        }

        public int Method2(string input)
        {
            return 1;
        }

        public bool RunMethod(Func<string, int> MethodName)
        {
            int i = MethodName("This is a string");
            return true;
        }

        public bool Test()
        {
            return RunMethod(Method1);
        }

        #endregion

        public void TestDelegate()
        {
            
            string a = "100";
            var c = Convert.ToInt32(a);
            System.Diagnostics.Debug.WriteLine(a.ToString());
        }

        public async void Click()
        {
            _token = new CancellationTokenSource();
            var token = _token.Token;
            await Task.Run(() => LongCount(2000, token));
            System.Diagnostics.Debug.WriteLine("Async Test");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public void LongCount(int count, CancellationToken token)
        {
            for (int x = 0; x < count; x++)
            {
                Thread.Sleep(20000);
                System.Diagnostics.Debug.WriteLine("Token request started");
                _token.Cancel();
                System.Diagnostics.Debug.WriteLine(token.IsCancellationRequested);
                Console.WriteLine(token);
                if (token.IsCancellationRequested)
                {
                    System.Diagnostics.Debug.WriteLine("Token request created");
                    return;
                }
            }
            System.Diagnostics.Debug.WriteLine("LongCount Complete");
        }

        public void SkipCount(int value)
        {
            for (int i = 0; i < value;i++)
            {
                i = i + 3;
                System.Diagnostics.Debug.WriteLine(i);
                i--;
            }
        }

        public void ReverseString(string value)
        {
            var value1 = "";
            char[] chararray = value.ToCharArray();
            var count  = chararray.Count();
            for(int i = 0; i < count; i++)
            {
                var counter = count - i;
                value1 = value1 + chararray[counter - 1].ToString();

            }
        }

        public void Palindrom(string str)
        {
            bool flag = false;
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                var value0 = str.Length / 2;
                var value1 = i;
                var value2 = j;

                var value21 = str[i];
                var value22 = str[j];

                if (str[i] != str[j])
                {
                    flag = false;
                    break;
                }
                else
                    flag = true;
            }
            if (flag)
            {
                Debug.WriteLine("Palindrome");
            }
            else
                Debug.WriteLine("Not Palindrome");
        }

        internal static void ReverseWords(string str)
        {
            StringBuilder output = new StringBuilder();
            List<char> charlist = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    if (i == str.Length - 1) 
                        charlist.Add(str[i]);
                    for (int j = charlist.Count - 1; j >= 0; j--)
                        output.Append(charlist[j]);

                    output.Append(' ');
                    charlist = new List<char>();
                }
            }
            Console.WriteLine(output.ToString());
        }

        internal static void removeduplicate(string str)
        {
            string result = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (!result.Contains(str[i]))
                {
                    result += str[i]; 
                }
            }
            Console.WriteLine(result);
        }
    }
}

