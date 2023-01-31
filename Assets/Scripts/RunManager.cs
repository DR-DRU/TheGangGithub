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

    private void OnEnable()
    {
        GameManager.OnRunStart += PlaybackAll;
        GameManager.OnRunEnd += StartNewList;
    }

    private void OnDisable()
    {
        GameManager.OnRunStart -= PlaybackAll;
        GameManager.OnRunEnd -= StartNewList;
    }

    public void StartNewList()
    {
        runs.Add(currentRun);
        currentRun = new List<Vector3>();
        
    }

    public void AddToCurrentList(Vector3 v3)
    {
        currentRun.Add(v3);
    }

    public void PlaybackAll()
    {
        for (int i = 0; i < runs.Count; i++)
        {
            StartPlayback(i);
        }
    }

    void StartPlayback(int runNumber)
    {
        GameObject g = Instantiate(ghostPrefab, runs[runNumber][0], new Quaternion());
        g.GetComponent<Ghost>().wayPoints = runs[runNumber];

    }
}
