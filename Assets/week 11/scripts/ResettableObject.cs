using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    private void Start()
    {
        GameManager.AddRestartEventListener(ResetState);
    }

    private void OnDestroy()
    {
        GameManager.RemoveRestartEventListener(ResetState);
    }

    private void ResetState()
    {
        // Reset the state of this object
        gameObject.SetActive(true); // For example, activate the object again
    }
}
