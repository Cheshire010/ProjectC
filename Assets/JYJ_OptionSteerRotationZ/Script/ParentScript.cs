using UnityEngine;

public class ParentScript : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject object1;
    public GameObject object2;

    void Start()
    {
        // "Santafe_Final_2(Clone)" 이름의 오브젝트를 자동으로 찾음
        GameObject parentObject = GameObject.Find("Santafe_Final_2(Clone)");
        if (parentObject != null)
        {
            if (canvas1 != null) canvas1.transform.SetParent(parentObject.transform);
            if (canvas2 != null) canvas2.transform.SetParent(parentObject.transform);
            if (object1 != null) object1.transform.SetParent(parentObject.transform);
            if (object2 != null) object2.transform.SetParent(parentObject.transform);
        }
        else
        {
            Debug.LogWarning("\"Santafe_Final_2(Clone)\" 오브젝트를 찾을 수 없습니다!");
        }
    }
}
