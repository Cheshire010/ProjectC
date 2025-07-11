using UnityEngine;

public class KeySpawnScript : MonoBehaviour
{
   void Start()
   {
       GameObject parentObj = GameObject.Find("OVRControllerPrefab_L");
       if (parentObj != null)
       {
           transform.SetParent(parentObj.transform, false);
           Vector3 pos = transform.localPosition;
           pos.y = 0.1f;
           transform.localPosition = pos;
       }
   }
}
