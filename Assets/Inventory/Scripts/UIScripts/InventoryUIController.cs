using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public DynamicInventoryDisplay inventoryPanel;
    public DynamicInventoryDisplay playerInventoryPanel;

    private void Awake()
    {
        inventoryPanel.gameObject.SetActive(false);
        playerInventoryPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerInventoryDisplayRequested += DisplayPlayerInventory;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerInventoryDisplayRequested -= DisplayPlayerInventory;
    }
    private void Update()
    {
        
        if(inventoryPanel.gameObject.activeInHierarchy && Input.GetKeyUp(KeyCode.Escape))
        {
            inventoryPanel.gameObject.SetActive(false);
        }
        if (playerInventoryPanel.gameObject.activeInHierarchy && Input.GetKeyUp(KeyCode.Escape))
        {
            playerInventoryPanel.gameObject.SetActive(false);
        }
    }

    private void DisplayInventory(InventorySystem inventory)
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.RefreshDynamicInventory(inventory);
    }
    private void DisplayPlayerInventory(InventorySystem inventory)
    {
        playerInventoryPanel.gameObject.SetActive(true);
        playerInventoryPanel.RefreshDynamicInventory(inventory);
    }
}
