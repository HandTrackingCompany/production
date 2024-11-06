using System;
using Item;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] private float bossHealth = 100;
        [SerializeField] private Slider BossHealthBar;
        private float bossMaxHealth;

        [SerializeField] private float DamagedItemPower = 10;

        public PlayerState player;
        private int rnd = 0;
        [SerializeField] private int randomValue = 5;
        [SerializeField] private float coolTime = 5;
        private float time;
        private bool chooseNumber = false;
        [SerializeField] private float chargeTime = 3; 
        

        private void Start()
        {
            bossMaxHealth = bossHealth;
            BossHealthBar.value = bossHealth / bossMaxHealth;
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
            player.Attacked();
            player.UpdateHelthBar();
        }

        private void OnTriggerEnter(Collider other)
        {
            bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage(); 
            BossHealthBar.value = bossHealth / bossMaxHealth;
        }
    }
}