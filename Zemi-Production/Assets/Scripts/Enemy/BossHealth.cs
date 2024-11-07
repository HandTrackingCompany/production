using System;
using Item;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class BossHealth : MonoBehaviour
    {
        [SerializeField] private float bossHealth = 100;
        [SerializeField] private Slider BossHealthBar;
        private float bossMaxHealth;

        private int rndWeakness = 0;

        private float time = 0;
        [SerializeField] private float coolTime = 5;
        private void Start()
        {
            bossMaxHealth = bossHealth;
            UpDateBossHealthBar();
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time > coolTime)
            {
                ChangeWeakness();
                ShowWeakness();
            }
        }

        private void ShowWeakness()
        {
            
        }

        private void ChangeWeakness()
        {
            rndWeakness = Random.Range(1, 7);
        }

        private void OnTriggerEnter(Collider other)
        {
            bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage(); 
            UpDateBossHealthBar();
        }

        private void UpDateBossHealthBar()
        {
            BossHealthBar.value = bossHealth / bossMaxHealth;
        }
    }
}