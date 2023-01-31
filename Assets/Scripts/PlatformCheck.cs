using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCheck : MonoBehaviour
{
    BoxCollider bC;
    RaycastHit hit;
    public Transform playerStandingOnTop;
    // Start is called before the first frame update
    void Start()
    {
        bC = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.BoxCast(bC.bounds.max,new Vector3(1f,0,1f) ,transform.up, out hit, transform.rotation, 100.0f, LayerMask.GetMask("Character")))
        {
            if (hit.transform.gameObject.name == "PlayerCapsule")
            {
                if (hit.transform.GetComponent<CharacterController>().velocity.y < 0)
                {
                    playerStandingOnTop = hit.transform;
                    bC.isTrigger = false;
                }                       
            }
            
        }
        else
        {           
            if (playerStandingOnTop != null)
            {
                
                playerStandingOnTop = null;
            }
            bC.isTrigger = true;
        }
      
    }
}
