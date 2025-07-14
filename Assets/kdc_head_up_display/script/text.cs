using UnityEngine;
using System.Collections;

public class text : MonoBehaviour
{
    [Header("텍스트 오브젝트")]
    public TextMesh speedText; // 3D TextMesh 사용

    [Header("트리거 오브젝트")]
    public Transform increaseSpeedTrigger; // 속도 증가 트리거 오브젝트 (1번째)
    public Transform decreaseSpeedTrigger; // 속도 감소 트리거 오브젝트 (2번째)
    public Transform increaseTargetPosition; // 1번째 오브젝트가 닿아야 할 위치
    public Transform decreaseTargetPosition; // 2번째 오브젝트가 닿아야 할 위치

    [Header("속도 설정")]
    public float minSpeed = 60f; // 최소 속도
    public float maxSpeed = 90f; // 최대 속도
    public float animationDuration = 2f; // 애니메이션 지속 시간 (초)

    [Header("트리거 설정")]
    public float detectionDistance = 1f; // 감지 거리
    public string speedUnit = "Km/s"; // 속도 단위

    private float currentSpeed;
    private bool isAnimating = false;
    private bool hasTriggeredIncrease = false;
    private bool hasTriggeredDecrease = false;

    void Start()
    {
        // 초기 속도 설정
        currentSpeed = minSpeed;
        UpdateSpeedText();
    }

    void Update()
    {
        CheckIncreaseSpeedTrigger();
        CheckDecreaseSpeedTrigger();
    }

    void CheckIncreaseSpeedTrigger()
    {
        if (increaseSpeedTrigger == null || increaseTargetPosition == null || isAnimating) return;

        float distance = Vector3.Distance(increaseSpeedTrigger.position, increaseTargetPosition.position);

        // 거리 내에 도달했고 아직 트리거되지 않았다면
        if (distance <= detectionDistance && !hasTriggeredIncrease)
        {
            hasTriggeredIncrease = true;
            StartSpeedAnimation(maxSpeed); // 90Km/s로 증가
        }
        // 거리 밖으로 나갔다면 트리거 리셋
        else if (distance > detectionDistance && hasTriggeredIncrease)
        {
            hasTriggeredIncrease = false;
        }
    }

    void CheckDecreaseSpeedTrigger()
    {
        if (decreaseSpeedTrigger == null || decreaseTargetPosition == null || isAnimating) return;

        float distance = Vector3.Distance(decreaseSpeedTrigger.position, decreaseTargetPosition.position);

        // 거리 내에 도달했고 아직 트리거되지 않았다면
        if (distance <= detectionDistance && !hasTriggeredDecrease)
        {
            hasTriggeredDecrease = true;
            StartSpeedAnimation(minSpeed); // 60Km/s로 감소
        }
        // 거리 밖으로 나갔다면 트리거 리셋
        else if (distance > detectionDistance && hasTriggeredDecrease)
        {
            hasTriggeredDecrease = false;
        }
    }

    void StartSpeedAnimation(float targetSpeed)
    {
        if (isAnimating) return;

        StartCoroutine(AnimateSpeed(currentSpeed, targetSpeed));
        Debug.Log($"속도 애니메이션 시작: {currentSpeed}Km/s → {targetSpeed}Km/s");
    }

    IEnumerator AnimateSpeed(float fromSpeed, float toSpeed)
    {
        isAnimating = true;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / animationDuration;

            // 부드러운 곡선 애니메이션 (EaseInOut)
            progress = Mathf.SmoothStep(0f, 1f, progress);

            currentSpeed = Mathf.Lerp(fromSpeed, toSpeed, progress);
            UpdateSpeedText();

            yield return null;
        }

        // 최종 값 설정
        currentSpeed = toSpeed;
        UpdateSpeedText();
        isAnimating = false;
    }

    void UpdateSpeedText()
    {
        string speedString = $"{currentSpeed:F0}{speedUnit}";

        // 3D TextMesh 사용
        if (speedText != null)
        {
            speedText.text = speedString;
        }
    }

    // 수동으로 속도 증가 애니메이션 시작 (테스트용)
    [ContextMenu("Test Increase Speed")]
    public void TestIncreaseSpeed()
    {
        StartSpeedAnimation(maxSpeed);
    }

    // 수동으로 속도 감소 애니메이션 시작 (테스트용)
    [ContextMenu("Test Decrease Speed")]
    public void TestDecreaseSpeed()
    {
        StartSpeedAnimation(minSpeed);
    }

    // 속도 초기화
    [ContextMenu("Reset Speed")]
    public void ResetSpeed()
    {
        StopAllCoroutines();
        currentSpeed = minSpeed;
        isAnimating = false;
        hasTriggeredIncrease = false;
        hasTriggeredDecrease = false;
        UpdateSpeedText();
    }

    // 에디터에서 시각적으로 확인하기 위한 기즈모
    void OnDrawGizmosSelected()
    {
        // 속도 증가 트리거 위치 표시
        if (increaseTargetPosition != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(increaseTargetPosition.position, detectionDistance);

            if (increaseSpeedTrigger != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(increaseSpeedTrigger.position, increaseTargetPosition.position);
            }
        }

        // 속도 감소 트리거 위치 표시
        if (decreaseTargetPosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(decreaseTargetPosition.position, detectionDistance);

            if (decreaseSpeedTrigger != null)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(decreaseSpeedTrigger.position, decreaseTargetPosition.position);
            }
        }
    }
}