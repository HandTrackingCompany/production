﻿using System;
using System.Collections;
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
        [SerializeField] private ParticleSystem part1;
        [SerializeField] private ParticleSystem part2;
        [SerializeField] private ParticleSystem part3;

        public PlayerState player;
        private int rnd = 0;
        [SerializeField] private int randomValue = 5;
        [SerializeField] private float coolTime = 5;
        private float time;
        private bool chooseNumber = false;
        [SerializeField] private float chargeTime = 3;
        [SerializeField] private Animator animation;
        
        [SerializeField] private AudioClip[] clip;
        protected AudioSource source;

        private void Start()
        {
            chargeParticle.Stop();
            source = GetComponent<AudioSource>();
            part1.Stop();
            part2.Stop();
            part3.Stop();
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
                    animation.SetTrigger("Attack");
                    source.PlayOneShot(clip[0]);
                    StartCoroutine(AttackEffect());
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

        private IEnumerator AttackEffect()
        {
            yield return new WaitForSeconds(1.4f);
            
            part1.Play();
            yield return new WaitForSeconds(0.5f);
            part1.Stop();
            
            part2.Play();
            yield return new WaitForSeconds(0.5f);
            part2.Stop();
            
            part3.Play();
            yield return new WaitForSeconds(0.5f);
            part3.Stop();
        }


        private void Attack()
        {
            chargeParticle.Stop();
            player.Attacked();
            player.UpdateHealthBar();
        }
    }
}