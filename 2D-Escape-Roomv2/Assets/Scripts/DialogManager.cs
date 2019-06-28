using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;

    public static DialogManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire2"))
            {


                if (currentLine >= dialogLines.Length)
                {
                    dialogBox.SetActive(false);
                    PlayerController.instance.canMove = true;
                }
                else
                {
                    CheckIfName();
                    dialogText.text = dialogLines[currentLine];
                    currentLine++;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[0];
        dialogBox.SetActive(true);

        PlayerController.instance.canMove = false;
        nameBox.SetActive(isPerson);
    }

    public void CheckIfName(){
        if(dialogLines[currentLine].StartsWith("n-")){
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
