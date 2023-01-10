using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingPlatform : MonoBehaviour
{
    MeshRenderer mR;
    public int initialColor;
    public int currentColor { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentColor = initialColor;
        mR = GetComponent<MeshRenderer>();
        mR.material = GameManager.instance.materials[currentColor];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextColor()
    {
        currentColor++;
        if (currentColor >= GameManager.instance.materials.Length)
        {
            currentColor= 0;
        }

        mR.material = GameManager.instance.materials[currentColor];
    }

}
