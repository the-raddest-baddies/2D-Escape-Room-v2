using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour {

    public string[] lines;
    public bool inventoryItem;
    public string ItemName;
    public bool isPerson = false;

    private bool canActivate;



    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetButtonDown("Fire2") && !DialogManager.instance.dialogBox.activeInHierarchy){
            if(inventoryItem) {
                if(ItemName == "workbench")
                {
                    if(GameManager.instance.currentHeld() < 3)
                    {
                        lines[0] = "Hmm, looks like Im missing something";
                    }
                    else 
                    {
                        lines[0] = "Wow! You crafted a makeshift fishing pole!";
                        GameManager.instance.addFinalItem("fishing");
                    }
                }
                else if(ItemName == "keyVent")
                {
                    if(GameManager.instance.currentHeld() == 1 && GameManager.instance.itemsHeld[0] == "Fishing Pole")
                    {
                        lines[0] = "Woohoo, I got the key!";
                        GameManager.instance.addFinalItem("key");
                    }
                    else
                    {
                        lines[0] = "Seems I can't reach that key...";
                    }
                }
                else if(ItemName == "door")
                {
                    if(GameManager.instance.currentHeld() == 1 && GameManager.instance.itemsHeld[0] == "key")
                    {
                        lines[0] = "FREEDOM!";
                        
                    }
                    else
                    {
                        lines[0] = "Door seems to be locked. There's got to be a key somewhere around here!";
                    }
                }
                else 
                {
                    GameManager.instance.addItemToInventory(ItemName);
                }
            }
            DialogManager.instance.ShowDialog(lines, isPerson); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player") {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player") {
            canActivate = false;
        }
    }
}
