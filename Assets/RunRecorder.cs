using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRecorder : MonoBehaviour
{

    private IEnumerator coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        coroutine = SendPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(coroutine);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator SendPosition()
    {
        while (true)
        {
            Debug.Log("s");
            RunManager.instance.AddToCurrentList(transform.position + new Vector3(0,1,0));
            yield return new WaitForSeconds(RunManager.instance.timeIntervall);
        }
   
    }
}
