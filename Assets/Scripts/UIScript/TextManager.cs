using System.Collections;
using System.Collections.Generic;
using Oculus.VoiceSDK.UX;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    GameObject TextCanvas;
    GameObject npc;

    public string[] NPCText;
    public AudioClip[] voiceClips;

    public Text dialogueText;
    public Image Textimage;
    public Text NPCName;

    AudioSource NPC_Audio;
    bool isAudioPlaying = false;
    bool hasStarted = false;

    int currentline = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextCanvas = GameObject.Find("TextCanvas");
        npc = GameObject.Find("NPC");
        NPC_Audio = GameObject.Find("NPC").GetComponent<AudioSource>();

        TextCanvas.transform.position = npc.transform.position + npc.transform.right * 2.0f;
        TextCanvas.transform.eulerAngles = npc.transform.eulerAngles * 180.0f;
        TextCanvas.transform.parent = npc.transform;
        TextCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!TextCanvas.activeSelf)
            return;

        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (!hasStarted)
            {
                hasStarted = true;
                ShowLine();
            }
            else if (!isAudioPlaying)
            {
                ShowNextLine();
            }
        }
    }
    void ShowLine()
    {
        if (currentline < NPCText.Length)
        {
            dialogueText.text = NPCText[currentline];
            Textimage.enabled = true;
            NPCName.enabled = true;

            if (!TextCanvas.activeSelf)
                TextCanvas.SetActive(true);

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
    void ShowNextLine()
    {
        currentline++;
        ShowLine();
    }
    void AllowNextLine()
    {
        isAudioPlaying=false;
    }
}
