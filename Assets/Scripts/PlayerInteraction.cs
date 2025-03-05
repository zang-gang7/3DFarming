using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerController playerController;

    // The land the player is currently selecting
    Land selectedLand = null;

    void Start()
    {
        // Get access to our PlayerController component
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    // Handles what happens when the interaction raycast hits something interactable
    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        // Check if the player is going to interact with land
        if(other.tag == "Land")
        {
            // Get the land conponent
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        //Unselect the land if the player is not standing on any land at the moment
        if(selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    // Handles the selection process of the land
    void SelectLand(Land land)
    {
        // Set the previously selected land to false (If any)
        if(selectedLand != null)
        {
            selectedLand.Select(false);
        }

        // Set the new selected land to the land we're selecting now
        selectedLand = land;
        land.Select(true);
    }

    // Triggered when the player presses the tool button
    public void Interact()
    {
        // Check if the player is selecting any land
        if(selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }
    }
}
