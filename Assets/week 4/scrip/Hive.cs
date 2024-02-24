using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    [SerializeField] private float honeyProductionRate = 10f;
    [SerializeField] private int startingBees = 5;
    [SerializeField] private GameObject beePrefab;

    private int nectarCount = 0;
    private int honeyCount = 0;
    private float productionTimer = 0f;

    private void Start()
    {
        for (int i = 0; i < startingBees; i++)
        {
            GameObject beeObject = Instantiate(beePrefab, transform.position, Quaternion.identity);
            Bee bee = beeObject.GetComponent<Bee>();
            bee.Init(this);
        }
    }

    private void Update()
    {
        if (nectarCount > 0)
        {
            productionTimer += Time.deltaTime;
            if (productionTimer >= honeyProductionRate)
            {
                nectarCount--;
                honeyCount++;
                productionTimer = 0f;
            }
        }
    }

    public void GiveNectar()
    {
        nectarCount++;
        if (productionTimer == 0f)
        {
            productionTimer = honeyProductionRate;
        }
    }
}
