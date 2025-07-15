using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager_TestScene : MonoBehaviour
{
    GameObject TextCanvas;
    GameObject NPC;

    public string[] NPCText;
    public AudioClip[] voiceClips;

    public Text dialogueText;
    public Image Textimage;
    public Text NPCName;

    AudioSource NPC_Audio;
    bool isAudioPlaying = false;

    int currentline = 0;
    // Start is called before the first frame update
    void Start()
    {
        TextCanvas = GameObject.Find("TextCanvas");
        NPC = GameObject.Find("NPC");
        NPC_Audio = GameObject.Find("NPC").GetComponent<AudioSource>();

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

            if (voiceClips.Length > currentline && voiceClips[currentline] != null)
            {
                NPC_Audio.Stop();
                NPC_Audio.clip = voiceClips[currentline];
                NPC_Audio.Play();
                isAudioPlaying = true;
                Invoke(nameof(AllowNextLine), voiceClips[currentline].length);
            }
            else
            {
                isAudioPlaying = false;
            }
        }
        else
        {
            dialogueText.gameObject.SetActive(false);
            Textimage.enabled = false;
            NPCName.enabled=false;

            NPC_Audio.Stop();
        }
    }
    void ShowNextLine_Test()
    {
        currentline++;
        ShowLine_Test();
    }

    void AllowNextLine()
    {
        isAudioPlaying = false;
    }
}
