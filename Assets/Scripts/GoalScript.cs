using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public IngameButton[] buttons;

    public Material solvedMaterial;
    public Material unsolvedMaterial;

    MeshRenderer mR;
    bool solved = true;

    // Start is called before the first frame update
    void Start()
    {
        mR = GetComponent<MeshRenderer>();
        AllButtonsPressedCheck();
    }

    public void AllButtonsPressedCheck()
    {
        if (buttons != null && buttons.Length > 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].triggered == false)
                {
                    mR.material = unsolvedMaterial;
                    solved = false;
                    return;
                }
            }
            mR.material = solvedMaterial;
        }

        solved = true;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (solved)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.instance.GoalReached();
            }
        }

    }
}
