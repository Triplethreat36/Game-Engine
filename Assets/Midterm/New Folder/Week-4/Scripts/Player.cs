using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo
{
    /*public class Player : MonoBehaviour
    {
        public int health = 10;

        public void Damage(int amt)
        {
            health -= amt;
        }

        private Enemy FindNewTarget()
        {
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTag");
            int randomIndex = Random.Range(0, enemyObjects.Length);
            return enemyObjects[randomIndex].GetComponent<Enemy>();

            /*GameObject enemyObject = GameObject.Find("EnemyObject");
            return enemyObject.GetComponent<Enemy>();*/

            /*Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            int randomIndex = Random.Range(0, enemies.Length);
            return enemies[randomIndex];*/
        /*}

        [ContextMenu("Attack")]
        void Attack()
        {
            Enemy target = FindNewTarget();
            target.Damage(10);
        }

    }*/
}