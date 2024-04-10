using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent GameOverEvent;
    public UnityEvent RestartEvent;

    private void Awake()
    {
        instance = this;
       
    }

    public void GameOver()
    {
        GameOverEvent?.Invoke();
    }

    public void Restart()
    {
        RestartEvent?.Invoke();
    }

    public static void AddGameOverEventListener(UnityAction action)
    {
        instance.GameOverEvent.AddListener(action);
    }

    public static void AddRestartEventListener(UnityAction action)
    {
        instance.RestartEvent.AddListener(action);
    }

    public static void RemoveGameOverEventListener(UnityAction action)
    {
        instance.GameOverEvent.RemoveListener(action);
    }

    public static void RemoveRestartEventListener(UnityAction action)
    {
        instance.RestartEvent.RemoveListener(action);
    }
}
