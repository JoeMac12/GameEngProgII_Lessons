using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickups", menuName = "Pickups/Item Pickup")]
public class PickupObject : ScriptableObject
{
    public string itemName;

    public void PickUp()
    {
        Debug.Log("You picked up: " + itemName);
    }
}
