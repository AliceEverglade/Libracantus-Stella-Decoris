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
    public Rarities rarity;
    public Rarities Rarity
    {
        get { return rarity; }
        set
        {
            RarityColor = SetRarityColor(value);
            rarity = value;
        }
    }
    public Color RarityColor;
    public List<Material> RarityMaterials;
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

    public Color SetRarityColor(Rarities rarity)
    {
        switch (rarity)
        {
            case Rarities.Common:
                return Color.gray;

            case Rarities.Uncommon:
                return Color.green;

            case Rarities.Rare:
                return Color.blue;

            case Rarities.Epic:
                return Color.magenta;

            case Rarities.Legendary:
                return Color.yellow;

            case Rarities.Mythical:
                return Color.red;

            case Rarities.Artifact:
                return Color.cyan;

            default:
                return Color.white;
        }

    }
}
