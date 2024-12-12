using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace Player
{
    public class PlayerState : MonoBehaviour
    {
        public float Helth = 100;
        [SerializeField] private Slider PlayerHelthBar;
        private float playerMaxHelth;

        private bool guard = false;

        [SerializeField] private float bossAttackPower = 20;
        [SerializeField] private GameObject restartSwitch;

        [SerializeField] private AudioClip[] clip;
        protected AudioSource source;
    
        private void Start()
        {
            playerMaxHelth = Helth;
            PlayerHelthBar.value = Helth / playerMaxHelth;
            source = GetComponent<AudioSource>();
        }

        public void Attacked()
        {
            if (!guard)
            {
                Helth -= bossAttackPower;
                source.PlayOneShot(clip[0]);
                if (Helth <= 0)
                {
                    restartSwitch.SetActive(true);
                }
            }
            else
            {
                source.PlayOneShot(clip[1]);
            }
        }

        public void Guard()
        {
            guard = true;
            source.PlayOneShot(clip[2]);
        }

        public void GuardCancel()
        {
            guard = false;
            source.PlayOneShot(clip[3]);
        }
        

        public void UpdateHealthBar()
        {
            PlayerHelthBar.value = Helth / playerMaxHelth;
        }
    }
}