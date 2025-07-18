using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager_TestScene : MonoBehaviour
{
    GameObject TextCanvas;
    GameObject npc;

    public string[] NPCText;
    public AudioClip[] voiceClips;

    public Text dialogueText;
    public Image Textimage;
    public Text NPCName;

    AudioSource NPC_Audio;

    int currentline = 0;

    void Start()
    {
        TextCanvas = GameObject.Find("TextCanvas");
        npc = GameObject.Find("NPC");
        NPC_Audio = npc.GetComponent<AudioSource>();

        StartDialogue(); // 자동 시작
    }

    void StartDialogue()
    {
        currentline = 0;
        dialogueText.gameObject.SetActive(true);
        Textimage.enabled = true;
        NPCName.enabled = true;
        TextCanvas.SetActive(true);
        StartCoroutine(PlayDialogueSequence());
    }

    IEnumerator PlayDialogueSequence()
    {
        while (currentline < NPCText.Length)
        {
            dialogueText.text = NPCText[currentline];

            if (voiceClips.Length > currentline && voiceClips[currentline] != null)
            {
                NPC_Audio.Stop();
                NPC_Audio.clip = voiceClips[currentline];
                NPC_Audio.Play();
                yield return new WaitForSeconds(voiceClips[currentline].length + 0.2f); // 약간의 딜레이 추가
            }
            else
            {
                yield return new WaitForSeconds(2.0f); // 음성이 없으면 기본 대기
            }

            currentline++;
        }

        EndDialogue();
    }

    void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        Textimage.enabled = false;
        NPCName.enabled = false;
        NPC_Audio.Stop();
        TextCanvas.SetActive(false);
    }
}
