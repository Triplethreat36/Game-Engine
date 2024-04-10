using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInvetory : MonoBehaviour
{
    public int NumberOfDiamonds {  get; private set; }

    public UnityEvent<PlayerInvetory> OnDiamondCollected;

    public void ResetInventory()
    {
        NumberOfDiamonds = 0; 
        NumberOfKey = 0;    

        OnDiamondCollected.Invoke(this);
        OnKeyCollected.Invoke(this);
    }
    public void DiamondCollected()
    {
        NumberOfDiamonds++;
    
        OnDiamondCollected.Invoke(this);

    }
    public int NumberOfKey { get; private set; }

    public UnityEvent<PlayerInvetory> OnKeyCollected;

    public void KeyCollected()
    {
        NumberOfKey++;

        OnKeyCollected.Invoke(this);

    }
}
