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
            Debug.Log(ItemName);
            DialogManager.instance.ShowDialog(lines);
            if(inventoryItem) {
                GameManager.instance.addItemToInventory(ItemName);
            }
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
