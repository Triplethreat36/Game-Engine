using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInvetory playerInventory = other.GetComponent<PlayerInvetory>();
        if (playerInventory != null)
        {
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}

