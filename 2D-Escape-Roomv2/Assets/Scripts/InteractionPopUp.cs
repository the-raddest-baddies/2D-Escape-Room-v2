using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPopUp : MonoBehaviour
{
    public Text interactText;
    public string action;
    public string itemName;
    private bool canInteract;

    public static InteractionPopUp instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract && !DialogManager.instance.dialogBox.activeInHierarchy){
            interactText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player") {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player") {
            canInteract = false;
        }
    }
}
