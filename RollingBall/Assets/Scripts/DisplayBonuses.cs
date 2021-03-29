using UnityEngine.UI;
using UnityEngine;
using System;

namespace RollingBall
{
    public sealed class DisplayBonuses
    {
        private Text _bonusLable;

        public DisplayBonuses(GameObject bonus)
        {
            _bonusLable = bonus.GetComponentInChildren<Text>();
            _bonusLable.text = String.Empty;
        }

        public void Display(int value)
        {
            _bonusLable.text = $"Вы набрали {value}";
        }
    }
}