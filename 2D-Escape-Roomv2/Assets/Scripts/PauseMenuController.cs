using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] windows;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                //PlayerController.instance.canMove = true;
            }
            else 
            {
                pauseMenu.SetActive(true);
                //PlayerController.instance.canMove = false;

            }
        }
        
    }

    public void toggleWindow(int windowLocation) 
    {
        for(int i =0; i < windows.Length; i++) {
            if(windowLocation == i) {
                windows[i].SetActive(! windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
            
        }
    }
}
