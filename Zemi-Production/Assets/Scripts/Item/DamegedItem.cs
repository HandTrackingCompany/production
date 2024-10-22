using System;
using UnityEngine;

namespace Item
{
    public class DamegedItem : MonoBehaviour
    {
        private Vector3 startPosition;

        private GameObject repopItem;

        private void Start()
        {
            startPosition = transform.position;
            repopItem = this.gameObject;
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
    }
}