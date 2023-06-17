using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/NewItemList", order = 9000)]
public class ItemList : ScriptableObject
{
    public List<GameObject> PrefabsOfItems;
    private List<GameObject> UnlockedPrefabs;
    private List<GameObject> CType, UType, RType, SType, EType;
    private char Rarity;

    /// <summary>
    /// sorts the items when the game loads
    /// </summary>
    public void sort()
    {
        foreach (GameObject SortingItem in PrefabsOfItems)
        {
            switch(SortingItem.GetComponent<ItemCollectionV2>().power.getRarity()){
                case 'c':
                    CType.Add(SortingItem);
                    break;
                case 'C':
                    CType.Add(SortingItem);
                    break;
                case 'u':
                    UType.Add(SortingItem);
                    break;
                case 'U':
                    UType.Add(SortingItem);
                    break;
                case 'r':
                    RType.Add(SortingItem);
                    break;
                case 'R':
                    RType.Add(SortingItem);
                    break;
                case 's':
                    SType.Add(SortingItem);
                    break;
                case 'S':
                    SType.Add(SortingItem);
                    break;
                case 'e':
                    EType.Add(SortingItem);
                    break;
                case 'E':
                    EType.Add(SortingItem);
                    break;
                default:
                    break;

            }
        }
    }
    
    /// <summary>
    /// locking and unlocking of objects
    /// </summary>
    public void unlockedObjects()
    {
        //TODO: Check if object by id is currently available.
    }
    /// <summary>
    /// gets a list with a char from CURSE
    /// </summary>
    /// <param name="letter">Decides what list is grabbed</param>
    /// <returns>a list of GameObjects</returns>
    public List<GameObject> getList(char letter)
    {
        switch (letter)
        {
            case 'c':
            case 'C':
                return CType;
            case 'u':
            case 'U':
                return UType;
            case 'r':
            case 'R':
                return RType;
            case 's':
            case 'S':
                return SType;
            case 'e':
            case 'E':
                return EType;
            default:
                return SType;
        }
    }
}
