using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "Item/Create StatusData")]
    public class DamagePrams : ScriptableObject
    {
        public float BoxDamage = 5;
        public float IronBoxDamage = 15;
        
        
        
        public float BottleDamage = 5;
        public float GrassDamage = 15;
        public float FireDamage = 10;

        public float BallDamage = 5;
        public float IronBallDamage = 15;
        public float GrenadesDamage = 10;
    }
}