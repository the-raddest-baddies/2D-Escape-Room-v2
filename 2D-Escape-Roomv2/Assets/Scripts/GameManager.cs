﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameMenuOpen;

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
}
