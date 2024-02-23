using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace ClassDemo
{
    public class Player : MonoBehaviour
    {
        public int health = 10;

        public void Damge(int amt)
        {
            health -= amt;
        }
        private Enemy FindNewTarget()
        {

            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTag");
            int randomIndex = Random.Range(0, enemyObjects.Length);
            return enemyObjects[randomIndex].GetComponent<Enemy>();

            /*Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
             int randomIndex = Random.Range(0, enemies.Length);
             return enemies[randomIndex];*/

        }
        [ContextMenu("Attack")]
        void Attack()
        {
            Enemy target = FindNewTarget();
            target.Damage(10);
        }
        /* private void Awake()
         {
             Enemy target = FindNewTarget();
             target.Damage(10);
         }*/
    }
}
