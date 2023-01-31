using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public List<Vector3> wayPoints = new List<Vector3>();
    float timeBetweenWaypoints = 0;

    int currentGoal = 1;

    float timePercentage = 0;

    public GameObject g;
    Rigidbody rb;

    public Vector3 positionalChange;
    PlatformCheck platformCheck;
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenWaypoints = RunManager.instance.timeIntervall;
        rb = GetComponent<Rigidbody>();
        platformCheck = GetComponent<PlatformCheck>();
    }

    private void OnEnable()
    {
        GameManager.OnRunEnd += SelfDestruct;
    }

    private void OnDisable()
    {
        GameManager.OnRunEnd-= SelfDestruct;
    }

    private void FixedUpdate()
    {
        if (currentGoal >= wayPoints.Count)
        {
        }
        else
        {
            timePercentage += Time.deltaTime / timeBetweenWaypoints;
            Vector3 moveTo = Vector3.Lerp(wayPoints[currentGoal - 1], wayPoints[currentGoal], timePercentage);
            positionalChange = moveTo - transform.position;

                if(platformCheck.playerStandingOnTop != null)
                {
                platformCheck.playerStandingOnTop.transform.position += positionalChange;
                }

            rb.MovePosition(moveTo);

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
