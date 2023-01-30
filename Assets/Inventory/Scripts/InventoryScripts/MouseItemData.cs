using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    [SerializeField] private Image ItemSprite;
    [SerializeField] private TextMeshProUGUI ItemCount;
    [SerializeField] public InventorySlot AssignedInventorySlot;

    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot slot)
    {
        AssignedInventorySlot.AssignItem(slot);
        ItemSprite.sprite = slot.ItemData.Icon;
        ItemCount.text = slot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }

    private void Update()
    {
        if(AssignedInventorySlot.ItemData != null)
        {
            //transform.position = Mouse.current.position.ReadValue(); // new input system
            transform.position = Input.mousePosition;
            if (Input.GetMouseButtonDown(0) /*Mouse.current.leftButton.wasPressedThisFrame*/ && !IsPointerOverUIObject())
            {
                //destroy or drop the mouse item (implement dropping it urself)
                ClearSlot();
            }

        }
    }

    public void ClearSlot()
    {
        AssignedInventorySlot.ClearSlot();
        ItemSprite.sprite = null;
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }

    public static bool IsPointerOverUIObject()
    {
        
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        //eventDataCurrentPosition.position = Mouse.current.position.ReadValue(); // new input system
        eventDataCurrentPosition.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
