using System;
using UnityEngine;

namespace Item
{
    public class DamegedItem : MonoBehaviour
    {
        private Vector3 startPosition;

        private GameObject repopItem;
        private Mesh repopMesh;

        public float attackDamage;

        private Renderer thisColor;

        [SerializeField] private DamagePrams damage;
        private void Start()
        {
            thisColor = GetComponent<Renderer>();
            startPosition = transform.position;
            repopItem = gameObject;
            repopMesh = GetComponent<MeshFilter>().mesh;
            
            if (gameObject.CompareTag("Bottle")||gameObject.CompareTag("Bin")||
                gameObject.CompareTag("FireBin")||gameObject.CompareTag("BowlingPin"))
            {
                attackDamage = damage.BottleDamage;
                gameObject.tag = "Bottle";
            }
            else if (gameObject.CompareTag("Ball")||gameObject.CompareTag("IronBall")||
                     gameObject.CompareTag("Grenade")||gameObject.CompareTag("BowlingBall"))
            {
                attackDamage = damage.BallDamage;
                gameObject.tag = "Ball";
            }
            Debug.Log(("damage:"+attackDamage));
        }

        private void Repop()
        {
            repopItem.GetComponent<MeshFilter>().mesh = repopMesh;
            repopItem.GetComponent<Renderer>().material.color = default;
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