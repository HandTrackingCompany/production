using System;
using UnityEngine;

namespace Player
{
    public class IdentificationItem : MonoBehaviour
    {
        
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Box"))
            {
                
            }
            else if (other.gameObject.CompareTag("Bottle"))
            {
                
            }
        }
    }
}