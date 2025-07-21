using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,2,0)* 1.0f*Time.deltaTime);

        if (transform.position.y > 50.0f)
        {
            Destroy(gameObject);
        }
    }
}
