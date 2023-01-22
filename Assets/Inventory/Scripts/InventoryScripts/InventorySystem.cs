using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int _size)
    {
        inventorySlots = new List<InventorySlot>(_size);
        for (int i = 0; i < _size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData item, int amount)
    {
        if(ContainsItem(item, out List<InventorySlot> slots)) // Check if item exists in inventory, add to that stack
        {
            foreach (var slot in slots)
            {
                if (slot.RoomLeftInStack(amount))
                {
                    slot.AddToStack(amount);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
            
        }
        if (HasFreeSlot(out InventorySlot freeSlot)) // gets the first available slot, add to that slot
        {
            freeSlot.UpdateInventorySlot(item, amount);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
        return false;
    }

    public bool ContainsItem(InventoryItemData item, out List<InventorySlot> slots)
    {
        slots = inventorySlots.Where(i => i.ItemData == item).ToList();

        return slots == null ? false : true;
    }
    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
