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

        public bool Guard = false;

        [SerializeField] private float bossAttackPower = 20;

        private void Start()
        {
            playerMaxHelth = Helth;
            PlayerHelthBar.value = Helth / playerMaxHelth;
        }

        public void Attacked()
        {
            if (!Guard)
            {
                Helth -= bossAttackPower;
            }
        }

        public void UpdateHelthBar()
        {
            PlayerHelthBar.value = Helth / playerMaxHelth;
        }
    }
}