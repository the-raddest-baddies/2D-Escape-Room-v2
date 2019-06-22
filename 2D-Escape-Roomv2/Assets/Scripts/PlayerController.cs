using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool canMove = true;

    public static PlayerController instance;

    public Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
      theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        } else {
            theRB.velocity=Vector2.zero;
        }

      myAnim.SetFloat("moveX", theRB.velocity.x);
      myAnim.SetFloat("moveY", theRB.velocity.y);

      if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
      {
          if(canMove){
          myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
          myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
          }
      }
    }
}
