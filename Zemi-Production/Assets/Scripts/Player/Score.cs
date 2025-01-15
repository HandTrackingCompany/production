using Enemy;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private PlayerState playerState;
        [SerializeField] private BossHealth bossHealth;
        [SerializeField] private TextMeshProUGUI ScoreText;

        private float playerHP;
        private float time;
        private float total;

        public void Result()
        {
            playerHP = playerState.PlayerHelth();
            time = bossHealth.ClearTime();
            total = time * playerHP / 10;
            ScoreText.text = "Score : " + total.ToString("F2");
        }
    }
}