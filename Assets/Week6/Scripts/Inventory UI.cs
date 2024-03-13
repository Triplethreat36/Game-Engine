using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
        keyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInvetory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();
    }
    private TextMeshProUGUI keyText;

    // Start is called before the first frame update
   
    public void UpdateKeyText(PlayerInvetory playerInventory)
    {
        keyText.text = playerInventory.NumberOfKey.ToString();
    }

}
