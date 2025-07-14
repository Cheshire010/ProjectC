using UnityEngine;

public class LineBack : MonoBehaviour
{
    public GameObject minLimitObj; // 제한 최소 좌표 오브젝트 (Inspector에서 할당)
    public GameObject maxLimitObj; // 제한 최대 좌표 오브젝트 (Inspector에서 할당)

    private GameObject santafeObj; // Santafe_Final_2(Clone)
    private Transform minXTransform; // 하위 자식 MinX
    private Transform maxXTransform; // 하위 자식 MaxX

    void Start()
    {
        // Santafe 오브젝트 찾기
        santafeObj = GameObject.Find("Santafe_Final_2(Clone)");

        minXTransform = santafeObj.transform.Find("MinX");
        maxXTransform = santafeObj.transform.Find("MaxX");

    }

    void Update()
    {
        if (santafeObj == null || minXTransform == null || maxXTransform == null
            || minLimitObj == null || maxLimitObj == null) return;

        // 제한 오브젝트의 X좌표를 Santafe 하위 MinX/MaxX에 동기화
        Vector3 minXLocal = minXTransform.localPosition;
        Vector3 maxXLocal = maxXTransform.localPosition;

        // MinX, MaxX의 상대 위치(로컬 좌표)만큼 Santafe의 이동 허용 범위 계산
        float minLimit = minLimitObj.transform.position.x - minXLocal.x;
        float maxLimit = maxLimitObj.transform.position.x - maxXLocal.x;

        // Santafe의 현재 위치
        Vector3 pos = santafeObj.transform.position;
        pos.x = Mathf.Clamp(pos.x, Mathf.Min(minLimit, maxLimit), Mathf.Max(minLimit, maxLimit));
        santafeObj.transform.position = pos;

    }
}
