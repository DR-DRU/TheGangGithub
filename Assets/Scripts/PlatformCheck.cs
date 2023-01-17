using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCheck : MonoBehaviour
{
    BoxCollider bC;
    RaycastHit hit;
    Transform playerStandingOnTop;
    Ghost g;
    // Start is called before the first frame update
    void Start()
    {
        bC = GetComponent<BoxCollider>();
        g = GetComponent<Ghost>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStandingOnTop != null)
        {
            Debug.Log(g.positionalChange);
            playerStandingOnTop.position = playerStandingOnTop.position + g.positionalChange;
        }


        //Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), transform.up * 50, Color.green);
        if (Physics.BoxCast(bC.bounds.max,new Vector3(1,0.1f,1) ,transform.up, out hit, transform.rotation, 20.0f, LayerMask.GetMask("Character")))
        {
            if (hit.transform.gameObject.name == "PlayerCapsule")
            {
                playerStandingOnTop = hit.transform;
            }
       
            bC.isTrigger = false;
        }
        else
        {
            bC.isTrigger = true;
            playerStandingOnTop = null;
        }
        
    }
}
