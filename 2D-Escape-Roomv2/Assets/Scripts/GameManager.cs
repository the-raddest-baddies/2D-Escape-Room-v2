﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameMenuOpen;
    public bool dialogActive;
    public string[] itemsHeld;
    public Item[] referanceItems;
    public InteractionTextItem[] referanceItemTexts;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen || dialogActive)
        {
            PlayerController.instance.canMove = false;
        } else 
        {
            PlayerController.instance.canMove = true;
        }
    }

    public void removeItemFromSceen(string ItemName)
    {
        if(ItemName != "Fishing Pole") 
        {
            Item remove = getItemDetails(ItemName);
            remove.gameObject.SetActive(false);
        }
        if(ItemName == "Fishing Pole")
        {
            getItemTextDetails("bench").gameObject.SetActive(false);
            
            getItemDetails("bench").gameObject.GetComponent<BoxCollider2D> ().enabled = false;
        }
        else 
        {
            getItemTextDetails(ItemName).gameObject.SetActive(false);
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


    public InteractionTextItem getItemTextDetails(string itemToGrab)
    {
        for(int i = 0; i < referanceItemTexts.Length; i++)
        {
            if(itemToGrab == referanceItemTexts[i].name)
            {
                return referanceItemTexts[i];
            }
        }
        return null;
    }

    public bool addItemToInventory(string ItemName)
    {
        if(ItemName != "key")
        {
            removeItemFromSceen(ItemName);
        }
        
        
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
    public void addFinalItem(string item)
    {
        for(int i = 0; i < itemsHeld.Length; i++)
        {
            itemsHeld[i] = "";
        }
        if(item == "key")
        {
            addItemToInventory("key");
        }
        else {
            addItemToInventory("Fishing Pole");
        }
        
    }
    
}
