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

    private void OnEnable()
    {
        GameManager.OnRunStart += StartRecording;
        GameManager.OnRunEnd += EndRun;
    }

    private void OnDisable()
    {
        GameManager.OnRunStart -= StartRecording;
        GameManager.OnRunEnd -= EndRun;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.V))
        {
            StartRecording();
        }*/

        /*if (Input.GetKeyDown(KeyCode.B))
        {
            
        }*/

        /*if (Input.GetButtonDown("EndCurrentRun"))
        {
            EndRun();
        }*/

    }

    void StartRecording()
    {
        StartCoroutine(coroutine);
    }

    void EndRun()
    {
        
        StopCoroutine(coroutine);


    }

    IEnumerator SendPosition()
    {
        while (true)
        {
            //Debug.Log("s");
            RunManager.instance.AddToCurrentList(transform.position + new Vector3(0,1,0));
            yield return new WaitForSeconds(RunManager.instance.timeIntervall);
        }
   
    }
}
