using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance {get; private set;}

    private void Awake()
    {
        // If there is more than one instance, destory the extra
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // Set the static instance to this instance
            Instance = this;
        }
    }

    [Header("Tools")]
    // Tool Slots
    public ItemData[] tools = new ItemData[8];
    // Tool in the player's hand
    public ItemData equippedTool = null;

    [Header("Items")]
    // Item Slots
    public ItemData[] items = new ItemData[8];
    // Item in the player's hand
    public ItemData equippedItem = null;

    void Update()
    {
        
    }
}
