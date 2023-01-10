using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCheck : MonoBehaviour
{
    BoxCollider bC;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        bC = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), transform.up * 50, Color.green);
        if (Physics.BoxCast(bC.bounds.max,new Vector3(1,0.1f,1) ,transform.up, transform.rotation, 20.0f, LayerMask.GetMask("Character")))
        {
            bC.isTrigger = false;
            Debug.Log("Hey");
        }
        else
        {
            bC.isTrigger = true;
        }
        
    }
}
