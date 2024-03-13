using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInvetory playerInventory = other.GetComponent<PlayerInvetory>();
        if (playerInventory != null)
        {
            playerInventory.KeyCollected();
            gameObject.SetActive(false);
        }
    }
}
