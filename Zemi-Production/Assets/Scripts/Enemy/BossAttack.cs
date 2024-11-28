using System;
using Item;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class BossAttack : MonoBehaviour
    {
        [SerializeField] private float DamagedItemPower = 10;

        [SerializeField] private ParticleSystem chargeParticle;

        public PlayerState player;
        private int rnd = 0;
        [SerializeField] private int randomValue = 5;
        [SerializeField] private float coolTime = 5;
        private float time;
        private bool chooseNumber = false;
        [SerializeField] private float chargeTime = 3; 
        
        [SerializeField] private AudioClip[] clip;
        protected AudioSource source;

        private void Start()
        {
            chargeParticle.Stop();
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time > coolTime)
            {
                AttackTrigger();
            }
        }

        private void AttackTrigger()
        {
            if (!chooseNumber)
            {
                rnd = Random.Range(1, randomValue + 1);
                chooseNumber = true;
                Debug.Log("rnd = " + rnd);
                if (rnd == randomValue)
                {
                    chargeParticle.Play(); 
                    source.PlayOneShot(clip[0]);
                }
            }
            
            if (rnd == randomValue)
            {
                if (time > coolTime + chargeTime)
                {
                    Attack();
                    Debug.Log("Attack");
                    rnd = 0;
                }
            }
            else
            {
                chooseNumber = false;
                time = 0;
            }
        }


        private void Attack()
        {
            chargeParticle.Stop();
            player.Attacked();
            player.UpdateHealthBar();
        }
    }
}