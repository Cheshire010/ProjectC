using UnityEngine;
using UnityEngine.UI;

public class UIChatManager : MonoBehaviour
{
    public string[] chatTexts;        // 채팅 메시지 배열
    public AudioSource audioSource;   // 오디오 소스
    public AudioClip[] audioClips;    // 오디오 클립 배열
    public Image canvasImage;         // 캔버스 이미지
    public Text mainText;             // 텍스트1 (메인 텍스트)
    public Text chatText;             // 텍스트2 (채팅 메시지 표시용)

    private int currentChatIndex = 0;
    private bool isChatActive = false;

    void Start()
    {
        // 처음부터 UI 요소를 모두 활성화
        if (canvasImage != null)
            canvasImage.gameObject.SetActive(true);
        if (mainText != null)
            mainText.gameObject.SetActive(true);
        if (chatText != null)
            chatText.gameObject.SetActive(true);

        currentChatIndex = 0;
        isChatActive = true;
        ShowNextChat();
    }

    void Update()
    {
        if (!isChatActive)
            return;

        // OVRInput A 버튼 눌림 감지
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            // 현재 재생 중인 사운드 즉시 정지
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            ShowNextChat();
        }
    }

    // 다음 채팅 메시지 표시 및 오디오 재생
    public void ShowNextChat()
    {
        if (chatTexts != null && chatTexts.Length > 0 && chatText != null)
        {
            if (currentChatIndex < chatTexts.Length)
            {
                chatText.text = chatTexts[currentChatIndex];

                // 오디오 클립이 있으면 재생
                if (audioClips != null && audioClips.Length > currentChatIndex && audioSource != null)
                {
                    audioSource.clip = audioClips[currentChatIndex];
                    audioSource.Play();
                }

                currentChatIndex++;
            }
            else
            {
                // 마지막 메시지 이후 비활성화
                if (canvasImage != null)
                    canvasImage.gameObject.SetActive(false);
                if (mainText != null)
                    mainText.gameObject.SetActive(false);
                if (chatText != null)
                    chatText.gameObject.SetActive(false);

                isChatActive = false;
                currentChatIndex = 0; // 다음 대화 시작을 위해 인덱스 초기화
            }
        }
    }
}
