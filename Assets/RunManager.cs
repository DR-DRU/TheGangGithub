using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public float timeIntervall;

    [SerializeField]
    GameObject ghostPrefab;
    public static RunManager instance { get; private set; }

    List<List<Vector3>> runs= new List<List<Vector3>>();

    [SerializeField]
    List<Vector3> currentRun = new List<Vector3>();

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartPlayback(0);
        }
    }

    public void StartNewList()
    {
        currentRun = new List<Vector3>();
        runs.Add(currentRun);
    }

    public void AddToCurrentList(Vector3 v3)
    {
        Debug.Log("e");
        currentRun.Add(v3);
    }

    void StartPlayback(int runNumber)
    {
        GameObject g = Instantiate(ghostPrefab, currentRun[0], new Quaternion());
        g.GetComponent<Ghost>().wayPoints = currentRun;

    }
}
