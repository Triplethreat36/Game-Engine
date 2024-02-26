using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public float honeyProductionRate = 10f; // Rate of honey production in seconds
    public int startingBees = 10; // Starting number of bees
    public GameObject beePrefab; // Reference to the bee prefab
    private int nectarCount = 0; // Amount of nectar stored
    private int honeyCount = 0; // Amount of honey stored
    private float honeyTimer = 0f; // Timer to track honey production

    void Start()
    {
        // Instantiate bees
        for (int i = 0; i < startingBees; i++)
        {
            GameObject newBee = Instantiate(beePrefab, transform.position, Quaternion.identity);
            Bee beeComponent = newBee.GetComponent<Bee>();
            beeComponent.Init(this); // Pass reference to this hive to each bee
        }
    }

    void Update()
    {
        // Only produce honey if there is nectar available
        if (nectarCount > 0)
        {
            honeyTimer += Time.deltaTime;
            if (honeyTimer >= honeyProductionRate)
            {
                ProduceHoney();
                honeyTimer = 0f;
            }
        }
    }

    // Function to give nectar to the hive
    public void GiveNectar()
    {
        nectarCount++;
        if (nectarCount == 1) // Start counting down to produce honey if it's the first nectar
        {
            honeyTimer = 0f;
        }
    }

    // Function to produce honey
    void ProduceHoney()
    {
        nectarCount--; // Consume nectar
        honeyCount++; // Produce honey
        if (nectarCount > 0) // Reset the timer if there's more nectar
        {
            honeyTimer = 0f;
        }
    }
}
