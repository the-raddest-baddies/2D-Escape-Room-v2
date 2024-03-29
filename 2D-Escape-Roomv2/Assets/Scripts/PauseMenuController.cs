﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] windows;
    public ItemButton[] itemButtons;
    public static PauseMenuController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            }
            else 
            {
                pauseMenu.SetActive(true);
                GameManager.instance.gameMenuOpen = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            toggleMenu();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            toggleWindow(0);
            showItems();
        }
        
    }

    public void toggleWindow(int windowLocation) 
    {
        for(int i =0; i < windows.Length; i++) {
            if(windowLocation == i) {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
            
        }
    }

    public void toggleMenu()
    {
        pauseMenu.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    public void showItems()
    {        
        for(int i = 0; i < 3; i++)
        {
            itemButtons[i].buttonValue = i;
            if(GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.getItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
            }
            else 
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
            }
        }
    }
}
