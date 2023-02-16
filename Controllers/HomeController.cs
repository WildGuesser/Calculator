using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Calculus _calculus = new Calculus { };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(_calculus);
        }

        public IActionResult Clear() 
        {
            return View(null);
        }

        public IActionResult Display (string number1, string action, string number2, string result, string display, string number, string op, string equal)
        {
            
            if(equal != null)
            {
                _calculus.number1 = number1;
                _calculus.number2 = number2;
                _calculus.action = action;
                var num1 = Convert.ToInt32(_calculus.number1);
                var num2 = Convert.ToInt32(_calculus.number2);

                int igual = Calculate(num1, _calculus.action, num2);
                _calculus.result = igual.ToString();
                _calculus.number1 = null;
                _calculus.number2 = null;
                _calculus.action = op;
                _calculus.display = _calculus.result + _calculus.action;
                
                return View("Index", _calculus);
            }

            if (number1 != null && number2 != null && action != null && op != null)
            {
                _calculus.number1 = number1;
                _calculus.number2 = number2;
                _calculus.action = action;
                var num1 = Convert.ToInt32(_calculus.number1);
                var num2 = Convert.ToInt32(_calculus.number2);

                int igual = Calculate(num1, _calculus.action, num2);
                _calculus.result = igual.ToString();
                _calculus.number1 = null;
                _calculus.number2 = null;
                _calculus.action = op;
                _calculus.display = _calculus.result + _calculus.action;
                return View("Index", _calculus);
            }
            else
            {

                if (number != null)
                {

                    if (result != null)
                    {
                        number1 = result;
                    }


                    if (number1 == null)
                    {

                        _calculus.number1 = number;
                        _calculus.display = number1 + number;
                        return View("Index", _calculus);
                    }
                    else if (number1 != null && action == null && number2 == null)
                    {
                        _calculus.number1 = number1 + number;
                        _calculus.display = number1 + number;
                        return View("Index", _calculus);
                    }
                    else if (number1 != null && action != null)
                    {
                        if (number2 == null)
                        {
                            _calculus.number1 = number1;
                            _calculus.action = action;
                            _calculus.number2 = number;
                            _calculus.display = number1 + action + number;
                            return View("Index", _calculus);
                        }
                        if (number2 != null)
                        {
                            _calculus.number1 = number1;
                            _calculus.action = action;
                            _calculus.number2 = number2 + number;
                            _calculus.display = number1 + action + _calculus.number2;
                            return View("Index", _calculus);
                        }
                    }
                    else
                    {
                        _calculus.number1 = number1;
                        _calculus.number2 = number2;
                        _calculus.action = action;
                        _calculus.display = display;
                        _calculus.result = result;
                        return View("Index", _calculus);
                    }
                }
                else if (op != null)
                {
                    if (result != null && action != null)
                    {
                        _calculus.number1 = number1;
                        _calculus.number2 = number2;
                        _calculus.action = op;
                        _calculus.display = result + _calculus.display;
                        _calculus.result = result;
                        return View("Index", _calculus);
                    }
                    if (number1 != null && (string.IsNullOrEmpty(action)))
                    {

                        _calculus.number1 = number1;
                        _calculus.action = op;
                        _calculus.display = number1 + op;
                        return View("Index", _calculus);

                    }
                    else
                    {
                        _calculus.number1 = number1;
                        _calculus.number2 = number2;
                        _calculus.action = action;
                        _calculus.display = display;
                        return View("Index", _calculus);
                    }
                }
                else
                {
                    _calculus.number1 = number1;
                    _calculus.number2 = number2;
                    _calculus.action = action;
                    _calculus.display = display;
                    return View("Index", _calculus);
                }
            }
            _calculus.number1 = number1;
            _calculus.number2 = number2;
            _calculus.action = action;
            _calculus.display = display;
            _calculus.result = result;   
            return View("Index", _calculus);
        }


        public int Calculate(int num1,string action, int num2)
        {
            int result = 0;
            switch (action)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }
            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}