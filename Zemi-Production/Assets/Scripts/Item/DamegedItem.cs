using System;
using UnityEngine;

namespace Item
{
    public class DamegedItem : MonoBehaviour
    {
        private Vector3 startPosition;

        private GameObject repopItem;

        private float attackDamage;

        [SerializeField] private DamagePrams damage;
        private void Start()
        {
            startPosition = transform.position;
            repopItem = this.gameObject;
            if (gameObject.CompareTag("Box"))
            {
                attackDamage = damage.BoxDamage;
            }
            else if (gameObject.CompareTag("Bottle"))
            {
                attackDamage = damage.BottleDamage;
            }
            else if (gameObject.CompareTag("Ball"))
            {
                attackDamage = damage.BallDamage;
            }
        }

        private void Repop()
        {
            Instantiate(repopItem,startPosition,Quaternion.identity);
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                Repop();
            }
        }

        public float AttackDamage()
        {
            return attackDamage;
        }
    }
}