using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject[] spawns;
    public GameObject[] goals;
    public Material[] materials;
    public GameObject player;

    private int currentRunNumber = 0;

    [SerializeField]
    TextMeshProUGUI startText;
    [SerializeField]
    TextMeshProUGUI runText;
    [SerializeField]
    TextMeshProUGUI cycleText;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI runCounterText;

    [SerializeField]
    string nextSceneName;

    [SerializeField]
    Canvas GoalReachedCanvas;
    [SerializeField]
    TextMeshProUGUI runsUsedText;
    [SerializeField]
    TextMeshProUGUI timeUsedText;


    public delegate void RunStartDelegate();
    public static event RunStartDelegate OnRunStart;

    public delegate void RunEndDelegate();
    public static event RunEndDelegate OnRunEnd;

    public delegate void GoalReachedDelegate();
    public static event GoalReachedDelegate OnGoalReached;

    float currentRunTimer = 0;

    [HideInInspector]
    public bool goalReached = false;

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
        NextRun();
    }

    public void NextRun()
    {
        player.transform.position = spawns[0].transform.position;
        startText.enabled = true;
        timerText.enabled = false;
        //runText.enabled = true;
        //cycleText.enabled = true;

        Time.timeScale = 0;
        currentRunNumber++;

        /*if (currentRunNumber >= spawns.Length)
        {
            currentRunNumber = 0;
        }*/

        runCounterText.text = "Run: " + currentRunNumber;

        //runText.text = materials[currentRunNumber].name + " Run";
        //runText.color = materials[currentRunNumber].color;
        //Debug.Log(player.transform.position);
    }

    public void RunStarted()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 )
        {
            if (!goalReached)
            {
                PreRunInput();
            }
            else
            {
                FinishScreenInput();
            }
            
            
        }
        else
        {
            currentRunTimer += Time.deltaTime;
            float minutes = Mathf.FloorToInt(currentRunTimer / 60);
            float seconds = Mathf.FloorToInt(currentRunTimer % 60);
            //timerText.text = minutes + ":" + seconds;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            RunInput();
        }

        if (Input.GetButtonDown("ResetLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FinishScreenInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void RunInput()
    {
        if (Input.GetButtonDown("EndCurrentRun"))
        {
            if (OnRunEnd != null)
            {
                OnRunEnd();

            }
            NextRun();
            currentRunTimer = 0;
        }
    }

    void PreRunInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartRun();
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            NextRun();
        }*/
    }

    public void GoalReached()
    {
        Debug.Log("Goal Reached");
        goalReached = true;
        if (OnGoalReached != null)
        {
            OnGoalReached();
        }
        Time.timeScale = 0;
        GoalReachedCanvas.gameObject.SetActive(true);
        runsUsedText.text = "Runs Used: " + currentRunNumber;
        float minutes = Mathf.FloorToInt(currentRunTimer / 60);
        float seconds = Mathf.FloorToInt(currentRunTimer % 60);
        timeUsedText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StartRun()
    {
        Time.timeScale = 1;
        startText.enabled = false;
        timerText.enabled = true;
        //runText.enabled = false;
        //cycleText.enabled = false;
        if (OnRunStart != null)
        {
            OnRunStart();
        }



    }
}
