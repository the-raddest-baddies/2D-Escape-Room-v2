using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour {

    public string[] lines;
    public bool inventoryItem;
    public string ItemName;

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
                        lines[0] = "wow! created a new item";
                        GameManager.instance.addFinalItem("fishing");
                    }
                }
                else if(ItemName == "keyVent")
                {
                    Debug.Log("it the key vent");
                    if(GameManager.instance.currentHeld() == 1 && GameManager.instance.itemsHeld[0] == "Fishing Pole")
                    {
                        lines[0] = "Wow, I got the key";
                        GameManager.instance.addFinalItem("key");
                    }
                    else
                    {
                        lines[0] = "Seems I cant reach the key";
                    }
                }
                else 
                {
                    GameManager.instance.addItemToInventory(ItemName);
                }
                
            }
            DialogManager.instance.ShowDialog(lines);
            
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
