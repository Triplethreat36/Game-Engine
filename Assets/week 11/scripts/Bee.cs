using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beee : MonoBehaviour
{
    //public static UnityEvent BeeKilled
    public void Awake()
    {
        GameManager.AddGameOverEventListener(OnGameOver);
    }
    private void OnGameOver()
    {
        gameObject.SetActive(false);
    }

}
