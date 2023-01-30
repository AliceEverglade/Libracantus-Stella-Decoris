using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private Image borderSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button button;
    public InventorySlot AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay ParentDisplay {get; private set; }

    private void Awake()
    {
        ClearSlot();
        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if(slot.ItemData != null)
        {
            borderSprite.color = slot.ItemData.SetRarityColor(slot.ItemData.Rarity);
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;
        }
        else
        {
            ClearSlot();
        }
        if(slot.StackSize > 1)
        {
            itemCount.text = slot.StackSize.ToString();
        }
    }
    public void UpdateUISlot()
    {
        if(assignedInventorySlot != null)
        {
            UpdateUISlot(assignedInventorySlot);
        }
    }

    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        borderSprite.color = Color.white;
        itemCount.text = "";
    }

    private void OnUISlotClick()
    {
        ParentDisplay?.SlotClicked(this);
    }
}
