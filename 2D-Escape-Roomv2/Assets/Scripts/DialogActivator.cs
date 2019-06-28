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
                        GameManager.instance.addFinalItem();
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
