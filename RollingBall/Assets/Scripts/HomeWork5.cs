using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollingBall
{
    class Class1
    {
        public void List() // подсмотрел в интернете , но разширение Distinct классное
        {
            List<int> list = new List<int> { 1, 1, 1, 2, 2, 3, 3, 4, 5, 6, 6, };
            foreach (int value in list.Distinct())
            {
                Debug.Log($"{value} - {list.Where(x => x == value).Count()} раз");
            }
        }

        public void CodePart()
        {

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(pair => pair.Value); // это получилась лямбда ? 
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

        }

    }

    public static class StringExtensions
    {

        public static int CharCount(this string str , Char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    counter++;
                }
            }
            return counter;
        }

    }

}
