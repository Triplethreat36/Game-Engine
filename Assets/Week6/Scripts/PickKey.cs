using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    public GameObject playerGameObject; // Reference to the player GameObject
    public GameObject doorGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGameObject) // Check if the colliding object is the player
        {
            if (doorGameObject != null) // Check if doorGameObject is not null
            {
                doorGameObject.GetComponent<OpenDoor>().HasKey = true;
                
            }
            /* else
             {
                 Debug.LogError("doorGameObject is not assigned.");
             }
         }
         else
         {
             Debug.Log("Colliding object is not the player.");
         }*/
        }
    }

}
