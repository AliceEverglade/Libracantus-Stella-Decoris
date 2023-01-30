using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefab;

    protected override void Start()
    {
        base.Start();
        
    }

    private void OnDestroy()
    {
        //InventoryHolder.OnDynamicInventoryDisplayRequested -= RefreshDynamicInventory;
    }

    public void RefreshDynamicInventory(InventorySystem inventory)
    {
        ClearSlots();
        inventorySystem = inventory;
        if(inventorySystem != null)
        {
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        AssignSlot(inventory);
    }
    public override void AssignSlot(InventorySystem inventory)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();
        if (inventory == null) return;

        for (int i = 0; i < inventory.InventorySize; i++)
        {
            var UISlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(UISlot, inventory.InventorySlots[i]);
            UISlot.Init(inventory.InventorySlots[i]);
            UISlot.UpdateUISlot();
        }
    }

    private void ClearSlots()
    {
        foreach(var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }
        if(slotDictionary != null)
        {
            slotDictionary.Clear();
        }
    }

    private void OnDisable()
    {
        inventorySystem.OnInventorySlotChanged -= UpdateSlot;
    }
}
