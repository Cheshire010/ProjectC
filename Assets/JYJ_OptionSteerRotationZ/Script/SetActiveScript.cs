using UnityEngine;
using System.Collections;

public class SetActiveScript : MonoBehaviour
{
    public GameObject referenceObject;      // 기준이 되는 오브젝트
    public AudioSource audioSource;         // 방향지시등 소리 재생용
    public AudioClip indicatorClip;         // 방향지시등 소리 클립

    private GameObject prefabInstance;      

    void Start()
    {
        prefabInstance = GameObject.Find("Santafe_Final_2(Clone)");
        if (prefabInstance == null)
        {
            Debug.LogWarning("Santafe_Final_2(Clone) 오브젝트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        if (referenceObject == null || prefabInstance == null) return;

        float prefabX = prefabInstance.transform.position.x;
        float objectX = referenceObject.transform.position.x;

        // X값이 같을 때 사운드 즉시 정지
        if (Mathf.Abs(prefabX - objectX) < 0.1f)
        {
           audioSource.Stop();
           audioSource.loop = false;

        }

        if (prefabX > objectX)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                StartCoroutine(DisableAndEnableReference());
            }
        }
        else if (prefabX < objectX)
        {
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                StartCoroutine(DisableAndEnableReference());
            }
        }
    }


    private IEnumerator DisableAndEnableReference()
    {
        // 방향지시등 소리 재생
        if (audioSource != null && indicatorClip != null)
        {
            audioSource.clip = indicatorClip;
            audioSource.loop = true;
            audioSource.Play();
        }

        referenceObject.SetActive(false);   // 기준 오브젝트 비활성화
        yield return new WaitForSeconds(5f);

        referenceObject.SetActive(true);    // 5초 후 다시 활성화

        // 소리 정지
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.loop = false;
        }
    }
}
