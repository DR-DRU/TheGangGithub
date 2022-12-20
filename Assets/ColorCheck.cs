using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    public int color = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ColorChangingPlatform ccp = collision.gameObject.GetComponent<ColorChangingPlatform>();

        if (ccp != null)
        {
            if (ccp.currentColor == color)

            {
                ccp.NextColor();
            }

        }
    }

}
