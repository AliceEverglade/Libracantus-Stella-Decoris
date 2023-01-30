using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange = 1f;
    [SerializeField] private InventoryItemData itemData;
    private SphereCollider collider;

    private void Awake()
    {
        collider = GetComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = pickupRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
        if(inventory != null)
        {
            if (inventory.AddToInventory(itemData, 1))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
