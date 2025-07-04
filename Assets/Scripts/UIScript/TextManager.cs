using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    GameObject TextCanvas;
    GameObject npc;
    public string[] NPCText;
    public Text dialogueText;
    int currentline = 0;
    public Image Textimage;
    public Text NPCName;
    // Start is called before the first frame update
    void Start()
    {
        TextCanvas = GameObject.Find("TextCanvas");
        npc = GameObject.Find("NPC");
        TextCanvas.transform.position = npc.transform.position - npc.transform.forward * -1.0f;
        TextCanvas.transform.eulerAngles = npc.transform.eulerAngles * 180.0f;
        TextCanvas.transform.parent = npc.transform;
        TextCanvas.SetActive(false);
        ShowLine();
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            ShowNextLine();
        }
    }
    void ShowLine()
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
    void ShowNextLine()
    {
        currentline++;
        ShowLine();
    }
}
