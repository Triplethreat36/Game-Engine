using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Hive hive;

    public void Init(Hive hive)
    {
        this.hive = hive;
    }

    public void CheckAnyFlower()
    {
        Flower[] flowers = FindObjectsOfType<Flower>();
        if (flowers.Length > 0)
        {
            Flower flowerToCheck = flowers[Random.Range(0, flowers.Length)];
            transform.DOMove(flowerToCheck.transform.position, 1f).OnComplete(() =>
            {
                if (flowerToCheck.HasNectar())
                {
                    GoToHive();
                    flowerToCheck.TakeNectar();
                }
            });
        }
    }

    private void GoToHive()
    {
        transform.DOMove(hive.transform.position, 1f).OnComplete(() =>
        {
            hive.GiveNectar();
        });
    }
}
