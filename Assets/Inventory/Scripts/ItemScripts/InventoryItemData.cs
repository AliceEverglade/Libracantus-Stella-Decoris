using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/InventoryItem")]
public class InventoryItemData : ScriptableObject
{
    public int ID;
    public string DisplayName;

    [TextArea(4, 4)]
    public string Description;

    public Sprite Icon;
    public int MaxStackSize;
    public itemTypes Type;
    public Rarities Rarity;
    public enum itemTypes
    {
        Consumable,
        CraftingMaterial,
        Weapon,
        Armor,
        Accessory,
        QuestItem,

    }
    public enum Rarities
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Mythical,
        Artifact,
    }
}
