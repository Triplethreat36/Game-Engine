using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private float nectarProductionRate = 5f;
    [SerializeField] private Color nectarReadyColor = Color.yellow;
    [SerializeField] private Color nectarNotReadyColor = Color.white;

    private bool hasNectar = false;
    private float productionTimer = 0f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateFlowerColor();
    }

    private void Update()
    {
        if (!hasNectar)
        {
            productionTimer += Time.deltaTime;
            if (productionTimer >= nectarProductionRate)
            {
                hasNectar = true;
                productionTimer = 0f;
                UpdateFlowerColor();
            }
        }
    }

    private void UpdateFlowerColor()
    {
        spriteRenderer.color = hasNectar ? nectarReadyColor : nectarNotReadyColor;
    }

    public bool HasNectar()
    {
        return hasNectar;
    }

    public bool TakeNectar()
    {
        if (hasNectar)
        {
            hasNectar = false;
            UpdateFlowerColor();
            return true;
        }
        else
        {
            return false;
        }
    }
}
