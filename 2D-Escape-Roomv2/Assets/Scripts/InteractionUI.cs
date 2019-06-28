using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public GameObject interactText;
    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract && !DialogManager.instance.dialogBox.activeInHierarchy && !PauseMenuController.instance.pauseMenu.activeInHierarchy){
            interactText.SetActive(true);
        }else{interactText.SetActive(false);
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
    // public void ShowInteraction(string newAction)
    // {
    //     itemInteract = newAction;

    //     interactText.text = itemInteract;
    //     interactionUI.SetActive(true);
    // }
}
