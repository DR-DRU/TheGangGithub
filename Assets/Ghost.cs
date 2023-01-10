using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public List<Vector3> wayPoints = new List<Vector3>();
    float timeBetweenWaypoints = 0;
    int currentGoal = 1;
    float timePercentage = 0;
    public GameObject g;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenWaypoints = RunManager.instance.timeIntervall;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameManager.OnRunEnd += SelfDestruct;
    }

    private void OnDisable()
    {
        GameManager.OnRunEnd-= SelfDestruct;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGoal >= wayPoints.Count)
        {

        }
        else
        {
            timePercentage += Time.deltaTime / timeBetweenWaypoints;
            rb.MovePosition(Vector3.Lerp(wayPoints[currentGoal-1], wayPoints[currentGoal], timePercentage));
            /*if (Vector3.Distance(transform.position, wayPoints[currentGoal]) < 0.01f)
            {
                timePercentage = 0;
                currentGoal++;
            }*/
            if (timePercentage >= 1)
            {
                timePercentage = 0;
                currentGoal++;
            }
        }
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
