using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv9
{
    internal class Calculator
    {
        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };
        private Stav _stav;
        private enum Operator
        {
            Plus,
            Minus,
            Krat,
            Delene
        };
        public String Display { get; set; }
        public String Pamat { get; set; }

        private string first = "";
        private Operator operation;
        private string second = "";
        private string result = "";

        public void Tlacitko(String btn)
        {

            var cislo = "";

            switch (btn)
            {
                case "0":
                    cislo += "0";
                    break;
                case "1":
                    cislo += "1";
                    break;
                case "2":
                    cislo += "2";
                    break;
                case "3":
                    cislo += "3";
                    break;
                case "4":
                    cislo += "4";
                    break;
                case "5":
                    cislo += "5";
                    break;
                case "6":
                    cislo += "6";
                    break;
                case "7":
                    cislo += "7";
                    break;
                case "8":
                    cislo += "8";
                    break;
                case "9":
                    cislo += "9";
                    break;

                case "+":
                    _stav = Stav.Operace;
                    operation = Operator.Plus;
                    break;
                case "-":
                    _stav = Stav.Operace;
                    operation = Operator.Minus;
                    break;
                case "*":
                    _stav = Stav.Operace;
                    operation = Operator.Krat;
                    break;
                case "/":
                    _stav = Stav.Operace;
                    operation = Operator.Delene;
                    break;
                case "=":
                    _stav = Stav.Vysledek;
                    result = FindAnswer();
                    Display = result;
                    first = "";
                    second = "";
                    result = "";

                    break;

                case "C":
                    if (_stav == Stav.PrvniCislo)
                    {
                        first = "";
                        Display = first;
                    }
                    if (_stav == Stav.DruheCislo)
                    {
                        second = "";
                        Display = second;
                    }

                    break;

                case "CE":
                    _stav = Stav.PrvniCislo;
                    Display = result;
                    first = "";
                    second = "";
                    result = "";
                    break;

                case "MS":
                    Pamat = Display;
                    break;

                case "MR":
                    if (_stav == Stav.PrvniCislo)
                    {
                        first = Pamat;
                    }
                    if (_stav == Stav.DruheCislo)
                    {
                        second = Pamat;
                    }

                    Display = Pamat;
                    break;

                case "MC":
                    Pamat = "";
                    break;

                default:
                    break;

            }

            switch (_stav)
            {
                case Stav.PrvniCislo:
                    first += cislo;
                    Display = first;
                    break;
                case Stav.DruheCislo:
                    second += cislo;
                    Display = second;
                    break;
                case Stav.Operace:
                    _stav = Stav.DruheCislo;
                    break;
                case Stav.Vysledek:
                    _stav = Stav.PrvniCislo;
                    break;
            }
        }
        private string FindAnswer()
        {
            var a = Convert.ToDouble(first);
            var b = Convert.ToDouble(second);
            double ans = 0;

            switch (operation)
            {
                case Operator.Plus:
                    ans = a + b;
                    break;
                case Operator.Minus:
                    ans = a - b;
                    break;
                case Operator.Krat:
                    ans = a * b;
                    break;
                case Operator.Delene:
                    ans = a / b;
                    break;
            }

            return "" + ans;
        }
    }
}
