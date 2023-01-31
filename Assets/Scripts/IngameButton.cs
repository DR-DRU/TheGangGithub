using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameButton : MonoBehaviour
{
    [HideInInspector]
    public bool triggered = false;

    public Material triggeredMaterial;
    public Material notTriggeredMaterial;

    public GoalScript gS;
    MeshRenderer mR;

    int amountOfObjectsInTrigger = 0;

    void OnEnable()
    {
        mR = GetComponent<MeshRenderer>(); 
        GameManager.OnRunEnd += Reset;
    }

    private void Reset()
    {
        amountOfObjectsInTrigger = 0;
        mR.material = notTriggeredMaterial;
        triggered = false;
        gS.AllButtonsPressedCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        mR.material = triggeredMaterial;
        amountOfObjectsInTrigger++;
        triggered= true;
        gS.AllButtonsPressedCheck();
    }


    private void OnTriggerExit(Collider other)
    {
        amountOfObjectsInTrigger--;
        if (amountOfObjectsInTrigger == 0)
        {
            mR.material = notTriggeredMaterial;
            triggered = false;
            gS.AllButtonsPressedCheck();
        }
    }

    private void OnDisable()
    {
        GameManager.OnRunEnd -= Reset;
    }
}
