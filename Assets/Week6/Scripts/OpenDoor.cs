using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private bool hasKey = false;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private Vector3 positionOpenOffset;
    private Vector3 positionClose;
    private Vector3 positionOpen;
    private bool isOpening;
    private float alpha;

    void Start()
    {
        positionClose = transform.position;
        positionOpen = positionOpenOffset + positionClose;
    }

    void Update()
    {
        if (hasKey && Input.GetKeyDown(interactKey))
        {
            isOpening = !isOpening;
        }

        if (isOpening)
        {
            alpha += Time.deltaTime;
        }
        else
        {
            alpha -= Time.deltaTime;
        }

        alpha = Mathf.Clamp01(alpha);
        transform.position = Vector3.Lerp(positionClose, positionOpen, alpha);
    }

    public bool HasKey
    {
        get { return hasKey; }
        set { hasKey = value; }
    }
}
