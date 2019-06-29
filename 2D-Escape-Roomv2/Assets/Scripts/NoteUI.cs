using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUI : MonoBehaviour
{
    public GameObject noteUI;
    public bool canActivate;
    public static NoteUI instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetButtonDown("Fire2") && !noteUI.activeInHierarchy && !DialogManager.instance.dialogBox.activeInHierarchy && !PauseMenuController.instance.pauseMenu.activeInHierarchy){
            noteUI.SetActive(true);
        } else if(canActivate && Input.GetButtonDown("Fire2") && noteUI.activeInHierarchy && !DialogManager.instance.dialogBox.activeInHierarchy && !PauseMenuController.instance.pauseMenu.activeInHierarchy){
            noteUI.SetActive(false);
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
