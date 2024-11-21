using Microsoft.AspNetCore.Mvc;
using ClassLibrary_Lab5;
using ClassLibrary_Lab4;

namespace Lab5.Controllers
{
    public class LabController : Controller
    {
        public IActionResult Lab1Proj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab1Result(string userInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new ArgumentException("Input cannot be empty.");
                }

                if (!Lab1.IsStringOnlyLetters(userInput))
                {
                    throw new ArgumentException("Input contains non-letter characters.");
                }

                var result = Lab1.GoLab1(userInput);

                ViewBag.Result = result;
                ViewBag.Error = null;
            }
            catch (Exception ex)
            {
                ViewBag.Result = null;
                ViewBag.Error = ex.Message;
            }

            return View("Lab1Proj");
        }

        public IActionResult Lab2Proj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab2Result(string userInput)
        {
            try
            {
                // Перевірка на порожнє значення
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new ArgumentException("Input cannot be empty.");
                }

                // Перевірка на те, чи є введене значення числом
                if (!int.TryParse(userInput, out int n))
                {
                    throw new ArgumentException("Input must be a valid integer.");
                }

                // Перевірка на діапазон значення
                if (n < 1 || n > 1000)
                {
                    throw new ArgumentException("Input must be between 1 and 1000.");
                }

                // Виклик основної функції для обчислення
                var result = Lab2.CountStrings(n);

                ViewBag.Result = result;
                ViewBag.Error = null;
            }
            catch (Exception ex)
            {
                ViewBag.Result = null;
                ViewBag.Error = ex.Message;
            }

            return View("Lab2Proj");
        }

        public IActionResult Lab3Proj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab3Result(string userInput)
        {
            try
            {
                // Перевірка на порожнє значення
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    throw new ArgumentException("Input cannot be empty.");
                }

                string[] lines = userInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Перевірка на кількість рядків
                if (lines.Length < 4)
                {
                    throw new ArgumentException("Input must contain at least 4 lines.");
                }

                int result = Lab3.FindShortestPath(State.Read(lines, 0), State.Read(lines, 2));

                ViewBag.Result = result;
                ViewBag.Error = null;
            }
            catch (Exception ex)
            {
                ViewBag.Result = null;
                ViewBag.Error = ex.Message;
            }

            return View("Lab3Proj");
        }
    }
}
