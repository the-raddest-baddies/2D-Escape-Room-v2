using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item itemForCrafting;
    [Range(1,1)]
    public int Quantity;
}

[CreateAssetMenu]
public class CraftRecipe : MonoBehaviour
{
    public List<ItemAmount> Ingredients;
    public List<ItemAmount> Result;
}
