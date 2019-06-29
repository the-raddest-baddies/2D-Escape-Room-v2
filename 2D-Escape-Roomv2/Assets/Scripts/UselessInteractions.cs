using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessInteractions : MonoBehaviour
{

    public Animator interactionAnimation;
    private bool canUse;
    public static UselessInteractions instance;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canUse && interactionAnimation.GetBool("IsOn")==false && Input.GetButtonDown("Fire2")){
            interactionAnimation.SetBool("IsOn", true);
        // }else if(interactionAnimation.GetBool("IsOn")==true && canUse && Input.GetButtonDown("Fire2")){
        //     interactionAnimation.SetBool("IsOn", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player") {
            canUse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player") {
            canUse = false;
        }
    }
}
