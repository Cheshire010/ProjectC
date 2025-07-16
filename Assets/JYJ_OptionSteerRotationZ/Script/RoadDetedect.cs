using System.Collections;
using UnityEngine;

public class RoadDetedect : MonoBehaviour
{
    public AudioSource audioSource;   // 사운드 재생용 AudioSource
    public AudioClip detectClip;      // 충돌 시 재생할 오디오 클립
    Coroutine Vibe;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            if (audioSource != null && detectClip != null && !audioSource.isPlaying)
            {
                audioSource.clip = detectClip;
                audioSource.Play();

                if (Vibe == null)
                {
                    Vibe = StartCoroutine(WarningVibration(2.0f));
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    IEnumerator WarningVibration(float _time)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
        yield return new WaitForSeconds(_time);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        Vibe = null;
    }
}
