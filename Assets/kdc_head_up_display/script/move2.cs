using UnityEngine;
using System.Collections;

public class move2 : MonoBehaviour
{
    [Header("도로 이동 설정")]
    public float minSpeed = 60f; // 최소 속도 (60Km/s)
    public float maxSpeed = 90f; // 최대 속도 (90Km/s)
    public float resetPositionZ = -100f; // 리셋될 Z 위치
    public Vector3 resetPosition = new Vector3(0, 0, 0); // 리셋 위치

    [Header("트리거 오브젝트")]
    public Transform accelerateTrigger; // 가속 트리거 오브젝트 (1번째)
    public Transform decelerateTrigger; // 감속 트리거 오브젝트 (2번째)
    public Transform accelerateTargetPosition; // 1번째 오브젝트가 닿아야 할 위치
    public Transform decelerateTargetPosition; // 2번째 오브젝트가 닿아야 할 위치

    [Header("애니메이션 설정")]
    public float speedChangesDuration = 2f; // 속도 변화 지속 시간 (초)
    public float detectionDistance = 1f; // 감지 거리

    private float currentSpeed;
    private bool isAnimating = false;
    private bool hasTriggeredAccelerate = false;
    private bool hasTriggeredDecelerate = false;

    void Start()
    {
        // 초기 속도 설정 (60Km/s)
        currentSpeed = minSpeed;
    }

    void Update()
    {
        // 도로 이동
        MoveRoad();

        // 트리거 체크
        CheckAccelerateTrigger();
        CheckDecelerateTrigger();
    }

    void MoveRoad()
    {
        // 현재 속도로 도로 이동 (Km/s를 Unity 단위로 변환)
        float moveSpeed = currentSpeed;
        transform.Translate(new Vector3(0, 0, -moveSpeed) * Time.deltaTime, Space.World);

        // 리셋 위치에 도달하면 원위치로 돌아가기
        if (transform.position.z < resetPositionZ)
        {
            transform.position = resetPosition;
        }
    }

    void CheckAccelerateTrigger()
    {
        if (accelerateTrigger == null || accelerateTargetPosition == null || isAnimating) return;

        float distance = Vector3.Distance(accelerateTrigger.position, accelerateTargetPosition.position);

        // 거리 내에 도달했고 아직 트리거되지 않았다면
        if (distance <= detectionDistance && !hasTriggeredAccelerate)
        {
            hasTriggeredAccelerate = true;
            StartSpeedAnimation(maxSpeed); // 90Km/s로 가속
        }
        // 거리 밖으로 나갔다면 트리거 리셋
        else if (distance > detectionDistance && hasTriggeredAccelerate)
        {
            hasTriggeredAccelerate = false;
        }
    }

    void CheckDecelerateTrigger()
    {
        if (decelerateTrigger == null || decelerateTargetPosition == null || isAnimating) return;

        float distance = Vector3.Distance(decelerateTrigger.position, decelerateTargetPosition.position);

        // 거리 내에 도달했고 아직 트리거되지 않았다면
        if (distance <= detectionDistance && !hasTriggeredDecelerate)
        {
            hasTriggeredDecelerate = true;
            StartSpeedAnimation(minSpeed); // 60Km/s로 감속
        }
        // 거리 밖으로 나갔다면 트리거 리셋
        else if (distance > detectionDistance && hasTriggeredDecelerate)
        {
            hasTriggeredDecelerate = false;
        }
    }

    void StartSpeedAnimation(float targetSpeed)
    {
        if (isAnimating) return;

        StartCoroutine(AnimateSpeed(currentSpeed, targetSpeed));
        Debug.Log($"도로 속도 변화 시작: {currentSpeed}Km/s → {targetSpeed}Km/s");
    }

    IEnumerator AnimateSpeed(float fromSpeed, float toSpeed)
    {
        isAnimating = true;
        float elapsedTime = 0f;

        while (elapsedTime < speedChangesDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / speedChangesDuration;

            // 부드러운 곡선 애니메이션 (EaseInOut)
            progress = Mathf.SmoothStep(0f, 1f, progress);

            currentSpeed = Mathf.Lerp(fromSpeed, toSpeed, progress);

            yield return null;
        }

        // 최종 값 설정
        currentSpeed = toSpeed;
        isAnimating = false;

        Debug.Log($"도로 속도 변화 완료: {currentSpeed}Km/s");
    }

    // 수동으로 가속 테스트 (테스트용)
    [ContextMenu("Test Accelerate")]
    public void TestAccelerate()
    {
        StartSpeedAnimation(maxSpeed);
    }

    // 수동으로 감속 테스트 (테스트용)
    [ContextMenu("Test Decelerate")]
    public void TestDecelerate()
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
        hasTriggeredAccelerate = false;
        hasTriggeredDecelerate = false;
    }

    // 현재 속도 반환 (다른 스크립트에서 사용 가능)
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    // 에디터에서 시각적으로 확인하기 위한 기즈모
    void OnDrawGizmosSelected()
    {
        // 가속 트리거 위치 표시
        if (accelerateTargetPosition != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(accelerateTargetPosition.position, detectionDistance);

            if (accelerateTrigger != null)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(accelerateTrigger.position, accelerateTargetPosition.position);
            }
        }

        // 감속 트리거 위치 표시
        if (decelerateTargetPosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(decelerateTargetPosition.position, detectionDistance);

            if (decelerateTrigger != null)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(decelerateTrigger.position, decelerateTargetPosition.position);
            }
        }

        // 리셋 위치 표시
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, resetPositionZ), Vector3.one);
    }
}