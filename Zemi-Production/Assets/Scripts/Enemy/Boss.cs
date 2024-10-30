using System;
using Item;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] private float bossHealth = 100;
        [SerializeField] private Slider BossHealthBar;
        private float bossMaxHealth;

        [SerializeField] private float DamagedItemPower = 10;

        private void Start()
        {
            bossMaxHealth = bossHealth;
            BossHealthBar.value = bossHealth / bossMaxHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage(); 
            BossHealthBar.value = bossHealth / bossMaxHealth;
            
        }
    }
}