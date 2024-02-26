using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Hive hive;
    private Flower currentFlower;

    void Start()
    {
        CheckAnyFlower();
    }
    public void Init(Hive hiveReference)
    {
        hive = hiveReference;
    }

   
    public void CheckAnyFlower()
    {
        Flower[] flowers = GameObject.FindObjectsOfType<Flower>(); // Find all flowers in the scene

       
        if (flowers.Length > 0)
        {
           
            Flower currentFlower = flowers[Random.Range(0, flowers.Length)];

            
            transform.DOMove(currentFlower.transform.position, 1f).OnComplete(() =>
            {
               
                if (currentFlower.TakeNectar())
                {
                   
                    GoToHive();
                    hive.GiveNectar();
                }
                else
                {
                    
                    CheckAnyFlower();
                }
            }).SetEase(Ease.Linear);
        }
    }

 
    private void GoToHive()
    {
       
        transform.DOMove(hive.transform.position, 1f).OnComplete(() =>
        {
            // After delivering nectar to the hive, check for more flowers
            CheckAnyFlower();
        }).SetEase(Ease.Linear);
    }
}
