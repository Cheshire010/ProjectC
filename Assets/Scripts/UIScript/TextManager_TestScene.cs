using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager_TestScene : MonoBehaviour
{
    GameObject TextCanvas;
    public string[] NPCText;
    public Text dialogueText;
    int currentline = 0;
    public Image Textimage;
    public Text NPCName;
    // Start is called before the first frame update
    void Start()
    {
        TextCanvas = GameObject.Find("TextCanvas");
        ShowLine_Test();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            ShowNextLine_Test();
        }
    }
    void ShowLine_Test()
    {
        if (currentline < NPCText.Length)
        {
            dialogueText.text = NPCText[currentline];
            Textimage.enabled = true;
            NPCName.enabled = true;
        }
        else
        {
            dialogueText.gameObject.SetActive(false);
            Textimage.enabled = false;
            NPCName.enabled=false;
        }
    }
    void ShowNextLine_Test()
    {
        currentline++;
        ShowLine_Test();
    }
}
