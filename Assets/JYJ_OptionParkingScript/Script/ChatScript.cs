using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChatScript : MonoBehaviour
{
    public Canvas chatCanvas;
    public Text chatText;
    public string[] textArray;
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    private int currentIndex = 0;

    RayCastManager_R RayCastManager_R;
    public Transform playerCamera;
    void Start()
    {
        chatCanvas.gameObject.SetActive(false);
        RayCastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        RayCastManager_R.AA.AddListener(ADD);
    }

    void ADD(string _value)
    {
        if (_value == gameObject.name)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                chatCanvas.gameObject.SetActive(true);
                ShowCurrentTextAndAudio(); // 대사와 오디오 출력
            }
        }
    }

    void Update()
    {
        if (chatCanvas.gameObject.activeSelf)
        {
            Vector3 dir = chatCanvas.transform.position - playerCamera.position;
            chatCanvas.transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
        }
        // OVRInput으로 오른손 One(A) 버튼 입력 감지
        if (chatCanvas.gameObject.activeSelf &&
            OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            NextTextAndAudio();
        }
    }

    void ShowCurrentTextAndAudio()
    {
        chatText.text = textArray[currentIndex];
        audioSource.Stop();
        audioSource.clip = audioClips[currentIndex];
        audioSource.Play();
    }

    void NextTextAndAudio()
    {
        audioSource.Stop();
        currentIndex++;
        if (currentIndex < textArray.Length)
        {
            ShowCurrentTextAndAudio();
        }
        else
        {
            chatCanvas.gameObject.SetActive(false);
            currentIndex = 0;
        }
    }
}
