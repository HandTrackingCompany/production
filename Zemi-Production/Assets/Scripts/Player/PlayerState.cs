using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerState : MonoBehaviour
    {
        public float Helth = 100;
        [SerializeField] private Slider PlayerHelthBar;
        private float playerMaxHelth;

        private bool guard = false;

        [SerializeField] private float bossAttackPower = 20;

        private void Start()
        {
            playerMaxHelth = Helth;
            PlayerHelthBar.value = Helth / playerMaxHelth;
        }

        public void Attacked()
        {
            if (!guard)
            {
                Helth -= bossAttackPower;
            }
        }

        public void Guard()
        {
            guard = true;
        }

        public void GuardCancel()
        {
            guard = false;
        }
        

        public void UpdateHelthBar()
        {
            PlayerHelthBar.value = Helth / playerMaxHelth;
        }
    }
}