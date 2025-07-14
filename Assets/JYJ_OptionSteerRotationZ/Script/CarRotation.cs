using UnityEngine;

public class CarRotation : MonoBehaviour
{
    public RotationZ rotationZScript; // RotationZ 스크립트 참조
    public float maxAngle = 10f;      // 최대 회전 각도(절대값)
    public float maxMoveDistance = 1f; // 최대 X축 이동량(프레임당, 조절 가능)

    void Update()
    {
        if (rotationZScript == null)
            return;

        // RotationZ에서 관리하는 현재 Z축 각도값 가져오기
        float inputZ = rotationZScript.GetCurrentZ();

        // -maxAngle ~ +maxAngle 범위로 제한
        float clampedY = Mathf.Clamp(inputZ, -maxAngle, maxAngle);

        // 차의 회전 적용 (X, Z는 0, Y만 제한된 값 사용)
        transform.localRotation = Quaternion.Euler(0f, clampedY, 0f);

        // X축 이동량 계산: -maxAngle~+maxAngle → -maxMoveDistance~+maxMoveDistance로 선형 변환
        float xMove = 0f;
        if (maxAngle != 0f)
            xMove = (clampedY / maxAngle) * maxMoveDistance * Time.deltaTime;

        // 오른쪽으로 꺾으면 +X, 왼쪽으로 꺾이면 -X로 이동
        transform.Translate(new Vector3(xMove, 0f, 0f), Space.World);
    }
}
    