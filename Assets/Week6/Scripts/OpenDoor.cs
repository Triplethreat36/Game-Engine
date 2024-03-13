using ClassDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private bool hasKey = false;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private float interactionDistance = 2f;
    private GameObject player; // Reference to the player GameObject
    [SerializeField] private Vector3 positionOpenOffset;
    private Vector3 positionClose;
    private Vector3 positionOpen;
    private bool isOpening;
    private float alpha;

    void Start()
    {
        positionClose = transform.position;
        positionOpen = positionOpenOffset + positionClose;

        // Find the player GameObject dynamically
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Check if the player is close enough and presses the interact key
        if (IsPlayerCloseEnough() && Input.GetKeyDown(interactKey))
        {
            // Check if the player has the key
            if (hasKey)
            {
                isOpening = !isOpening; // Toggle the door opening state
            }
            else
            {
                Debug.Log("You need a key to open this door!");
            }
        }

        // Interpolate door position based on isOpening state
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

    bool IsPlayerCloseEnough()
    {
        // Check if the player GameObject and the door are not null
        if (player != null && Vector3.Distance(player.transform.position, transform.position) <= interactionDistance)
        {
            return true;
        }
        return false;
    }

    public bool HasKey
    {
        get { return hasKey; }
        set { hasKey = value; }
    }
}
