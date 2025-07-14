using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd1 : MonoBehaviour
{
    [Header("제어할 오브젝트")]
    public GameObject targetObject; // 특정 오브젝트(1) - 보이거나 숨길 오브젝트

    [Header("트리거 오브젝트들")]
    public Transform showTriggerObject; // 특정 오브젝트(2) - 보이게 만드는 오브젝트
    public Transform hideTriggerObject; // 특정 오브젝트(3) - 숨기게 만드는 오브젝트

    [Header("목표 위치")]
    public Transform showTargetPosition; // 오브젝트(2)가 도달해야 하는 위치
    public Transform hideTargetPosition; // 오브젝트(3)이 도달해야 하는 위치

    [Header("설정")]
    public float detectionDistance = 1f; // 도달 판정 거리
    public bool useRenderer = true; // Renderer 사용 여부 (false시 GameObject.SetActive 사용)

    private Renderer targetRenderer;
    private bool isVisible = false;

    void Start()
    {
        // 초기 설정
        if (targetObject == null)
        {
            Debug.LogError("Target Object가 설정되지 않았습니다!");
            return;
        }

        // Renderer 컴포넌트 가져오기
        if (useRenderer)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
            if (targetRenderer == null)
            {
                Debug.LogError("Target Object에 Renderer 컴포넌트가 없습니다!");
                return;
            }
        }

        // 초기 상태를 숨김으로 설정
        SetObjectVisibility(false);
    }

    void Update()
    {
        CheckTriggerConditions();
    }

    void CheckTriggerConditions()
    {
        // 오브젝트(2)가 지정된 위치에 도달했는지 확인
        if (showTriggerObject != null && showTargetPosition != null)
        {
            float showDistance = Vector3.Distance(showTriggerObject.position, showTargetPosition.position);

            if (showDistance <= detectionDistance && !isVisible)
            {
                SetObjectVisibility(true);
                Debug.Log($"{showTriggerObject.name}이 목표 위치에 도달했습니다. 오브젝트를 표시합니다.");
            }
        }

        // 오브젝트(3)이 지정된 위치에 도달했는지 확인
        if (hideTriggerObject != null && hideTargetPosition != null)
        {
            float hideDistance = Vector3.Distance(hideTriggerObject.position, hideTargetPosition.position);

            if (hideDistance <= detectionDistance && isVisible)
            {
                SetObjectVisibility(false);
                Debug.Log($"{hideTriggerObject.name}이 목표 위치에 도달했습니다. 오브젝트를 숨깁니다.");
            }
        }
    }

    void SetObjectVisibility(bool visible)
    {
        if (targetObject == null) return;

        isVisible = visible;

        if (useRenderer && targetRenderer != null)
        {
            // Renderer의 enabled 속성으로 제어
            targetRenderer.enabled = visible;
        }
        else
        {
            // GameObject의 SetActive로 제어
            targetObject.SetActive(visible);
        }
    }

    // 에디터에서 시각적으로 확인하기 위한 기즈모
    void OnDrawGizmosSelected()
    {
        // 탐지 거리 표시
        if (showTargetPosition != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(showTargetPosition.position, detectionDistance);
        }

        if (hideTargetPosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hideTargetPosition.position, detectionDistance);
        }

        // 현재 트리거 오브젝트들의 위치 표시
        if (showTriggerObject != null && showTargetPosition != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(showTriggerObject.position, showTargetPosition.position);
        }

        if (hideTriggerObject != null && hideTargetPosition != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(hideTriggerObject.position, hideTargetPosition.position);
        }
    }
}
