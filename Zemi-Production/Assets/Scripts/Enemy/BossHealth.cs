using System;
using Item;
using Player;
using TMPro;
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

        [SerializeField] private int rndValue = 6;
        private int rndWeakness = 0;
        private bool changeWeakness = false;

        private float time = 0;
        [SerializeField] private float coolTime = 5;
        private float clearTime = 0;
        [SerializeField] private TextMeshProUGUI clearTimeText;
        [SerializeField] private Score score;

        private bool alive = true;

        private bool bin = false;
        private bool fireBin = false;
        private bool bowlingPin = false;
        private bool ironBall = false;
        private bool grenade = false;
        private bool bowlingBall = false;
        [SerializeField] private Renderer weaknessFlag;

        [SerializeField] private GameObject restartSwitch;
        [SerializeField] private AudioClip[] clip;
        protected AudioSource source;
        
        [SerializeField] private GameObject goo;
        [SerializeField] private GameObject scissors;
        [SerializeField] private GameObject paper;
        [SerializeField] private GameObject ball;
        [SerializeField] private GameObject MetalBall;
        [SerializeField] private GameObject GrenadeBall;
        [SerializeField] private GameObject BowlingBall;
        [SerializeField] private GameObject bottle;
        [SerializeField] private GameObject petbottle;
        [SerializeField] private GameObject Kaenbin;
        [SerializeField] private GameObject BowlingPin;
        
        private void Start()
        {
            bossMaxHealth = bossHealth;
            source = GetComponent<AudioSource>();
            UpDateBossHealthBar();
        }

        private void Update()
        {
            clearTime += Time.deltaTime;
            clearTimeText.text = "Time:" + clearTime.ToString("F2");
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else if (time <= 0 || !changeWeakness)
            {
                changeWeakness = true;
            }

            if (changeWeakness && alive)
            {
                ChangeWeakness();
                ShowWeakness();
            }
        }

        private void ShowWeakness()
        {
            source.PlayOneShot(clip[2]);
            if (bin)
            {
                weaknessFlag.material.color = Color.cyan;
                goo.SetActive(true);
                petbottle.SetActive(true);
            }
            else if (fireBin)
            {
                weaknessFlag.material.color = Color.red;
                scissors.SetActive(true);
                Kaenbin.SetActive(true);
            }
            else if (bowlingPin)
            {
                weaknessFlag.material.color = Color.gray;
                paper.SetActive(true);
                BowlingPin.SetActive(true);
            }
            else if (ironBall)
            {
                weaknessFlag.material.color = Color.yellow;
                goo.SetActive(true);
                MetalBall.SetActive(true);
            }
            else if (grenade)
            {
                weaknessFlag.material.color = Color.black;
                scissors.SetActive(true);
                GrenadeBall.SetActive(true);
            }
            else if (bowlingBall)
            {
                weaknessFlag.material.color = Color.blue;
                paper.SetActive(true);
                BowlingBall.SetActive(true);
            }
        }

        private void ChangeWeakness()
        {
            AllFalse();
            rndWeakness = Random.Range(1, rndValue + 1);
            switch (rndWeakness)
            {
                case 1 :
                    bin = true;
                    break;
                case 2 :
                    fireBin = true;
                    break;
                case 3 :
                    bowlingPin = true;
                    break;
                case 4 :
                    ironBall = true;
                    break;
                case 5 :
                    grenade = true;
                    break;
                case 6 :
                    bowlingBall = true;
                    break;
            }
            time = coolTime;
            changeWeakness = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bin"))
            {
                if (bin)
                {
                    bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage();
                    time = 0;
                    source.PlayOneShot(clip[0]);
                    AllFalse();
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
                else
                {
                    source.PlayOneShot(clip[1]);
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
            }
            else if (other.gameObject.CompareTag("FireBin"))
            {
                if (fireBin)
                {
                    bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage();
                    time = 0;
                    source.PlayOneShot(clip[0]);
                    AllFalse();
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
                else
                {
                    source.PlayOneShot(clip[1]);
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
            }
            else if (other.gameObject.CompareTag("BowlingPin"))
            {
                if (bowlingPin)
                {
                    bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage();
                    time = 0;
                    source.PlayOneShot(clip[0]);
                    AllFalse();
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
                else
                {
                    source.PlayOneShot(clip[1]);
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
            }
            else if (other.gameObject.CompareTag("IronBall"))
            {
                if (ironBall)
                {
                    bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage();
                    time = 0;
                    source.PlayOneShot(clip[0]);
                    AllFalse();
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
                else
                {
                    source.PlayOneShot(clip[1]);
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
            }
            else if (other.gameObject.CompareTag("Grenade"))
            {
                if (grenade)
                {
                    bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage();
                    time = 0;
                    source.PlayOneShot(clip[0]);
                    AllFalse();
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
                else
                {
                    source.PlayOneShot(clip[1]);
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
            }
            else if (other.gameObject.CompareTag("BowlingBall"))
            {
                if (bowlingBall)
                {
                    bossHealth -= other.gameObject.GetComponent<DamegedItem>().AttackDamage();
                    time = 0;
                    source.PlayOneShot(clip[0]);
                    AllFalse();
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
                else
                {
                    source.PlayOneShot(clip[1]);
                    other.gameObject.GetComponent<DamegedItem>().Repop();
                }
            }
            UpDateBossHealthBar();
        }

        private void AllFalse()
        {
            bin = false;
            fireBin = false;
            bowlingPin = false;
            ironBall = false;
            grenade = false;
            bowlingBall = false;
            goo.SetActive(false);
            scissors.SetActive(false);
            paper.SetActive(false);
            ball.SetActive(false);
            MetalBall.SetActive(false);
            GrenadeBall.SetActive(false);
            BowlingBall.SetActive(false);
            bottle.SetActive(false);
            petbottle.SetActive(false);
            Kaenbin.SetActive(false);
            BowlingPin.SetActive(false);
        }

        private void UpDateBossHealthBar()
        {
            BossHealthBar.value = bossHealth / bossMaxHealth;
            if (bossHealth <= 0)
            {
                alive = false;
                restartSwitch.SetActive(true);
                score.Result();
                source.PlayOneShot(clip[3]);
            }
        }

        public float Hp()
        {
            return bossHealth;
        }

        public float ClearTime()
        {
            return clearTime;
        }
    }
}