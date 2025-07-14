using UnityEngine;

public class RoadDetedect : MonoBehaviour
{
    public AudioSource audioSource;   // 사운드 재생용 AudioSource
    public AudioClip detectClip;      // 충돌 시 재생할 오디오 클립

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            if (audioSource != null && detectClip != null && !audioSource.isPlaying)
            {
                audioSource.clip = detectClip;
                audioSource.Play();
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
}
