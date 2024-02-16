using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
namespace ClassDemo
{
    public class Enemy : MonoBehaviour
    {
        public int health = 10;

        [SerializeField] private Player player;
        public void Damage(int amt)
        {
            
            health -= amt;
        }
        void Attack()
        {
            target.Damage(3);
        }
    }
}
