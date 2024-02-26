using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float nectarProductionRate = 10f;
    private float nectarTimer = 0f;
    void Update()
    {
        if (!hasNectar)
        {
            nectarTimer += Time.deltaTime;
            if (nectarTimer >= nectarProductionRate)
            {
                ProduceNectar();
                nectarTimer = 0f;
            }
        }
    }
    private bool hasNectar = false;
    public SpriteRenderer spriteRenderer;
    public Color nectarReadyColor;
    public Color nectarNotReadyColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = nectarNotReadyColor; 
    }

    void SetFlowerColor(bool isNectarReady)
    {
        spriteRenderer.color = isNectarReady ? nectarReadyColor : nectarNotReadyColor;
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
            SetFlowerColor(false); 
            return true;
        }
        return false;
    }
    void ProduceNectar()
    {
        hasNectar = true;
        SetFlowerColor(true); // Update flower color
    }
    public bool GetNectar()
    {
        if (hasNectar)
        {
            hasNectar = false;
            
            return true;
        }
        return false;
    }


}