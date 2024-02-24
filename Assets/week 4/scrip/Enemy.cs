using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo
{
    public class Enemy : MonoBehaviour
    {
        private static int count;
        public int health = 10;

        [SerializeField] private Player target;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amt"></param>
       /* public void Awake()
        {
             = 0;
        }
        public static void GetNumberOfEnemies()
        {
            return count;
        }*/
        public void Damage(int amt)
        {
            
            health -= amt;
        }
        [ContextMenu("Attack")]
        void Attack()
        {
            
           // target.Damage(3);
        }
    }
}
