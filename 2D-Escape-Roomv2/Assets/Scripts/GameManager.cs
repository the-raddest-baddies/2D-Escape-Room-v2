using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameMenuOpen;
    public string[] itemsHeld;
    public Item[] referanceItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen)
        {
            PlayerController.instance.canMove = false;
        } else 
        {
            PlayerController.instance.canMove = true;
        }
    }

    public Item getItemDetails(string itemToGrab)
    {
        for(int i = 0; i < referanceItems.Length; i++)
        {
            if(itemToGrab == referanceItems[i].name)
            {
                return referanceItems[i];
            }
        }
        return null;
    }
    public bool addItemToInventory(string ItemName)
    {
        bool addItem = false;
        for(int i =0; i < itemsHeld.Length; i++) {
            if(itemsHeld[i] == "")
            {
                itemsHeld[i] = ItemName;
                return true;
            }
        }
        return false;

    }
    public int currentHeld()
    {
        int totalItem = 0;
        for(int i = 0; i < itemsHeld.Length; i++)
        {
            if(itemsHeld[i] != "")
            {
                totalItem++;
            }
        }
        return totalItem;
    }
    public void addFinalItem()
    {
        for(int i = 0; i < itemsHeld.Length; i++)
        {
            itemsHeld[i] = "";
        }
        addItemToInventory("Fishing Pole");
    }
}
