using System;
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
            if (other.gameObject.CompareTag("DamagedItem"))
            {
                bossHealth -= DamagedItemPower;
                BossHealthBar.value = bossHealth / bossMaxHealth;
            }
        }
    }
}