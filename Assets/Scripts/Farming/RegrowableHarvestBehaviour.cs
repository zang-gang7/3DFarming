using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegrowableHarvestBehaviour : InteractableObject
{
    CropBehaviour parentCrop;

    // Sets the parent crop
    public void SetParent(CropBehaviour parentCrop_)
    {
        parentCrop = parentCrop_;
    }
    public override void Pickup()
    {
        // Set the player's inventory to the item
        InventoryManager.Instance.EquipHandSlot(item);

        // Update the changes in the scene
        InventoryManager.Instance.RenderHand();

        // Set the parent crop back to seedling to regrow it
        parentCrop.Regrow();
    }
}
