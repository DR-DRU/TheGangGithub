using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject[] spawns;
    public GameObject[] goals;
    public Material[] materials;
    public GameObject player;

    private int currentRunNumber = -1;

    [SerializeField]
    TextMeshProUGUI startText;
    [SerializeField]
    TextMeshProUGUI runText;
    [SerializeField]
    TextMeshProUGUI cycleText;




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
        startText.enabled = true;
        runText.enabled = true;
        cycleText.enabled = true;

        Time.timeScale = 0;
        currentRunNumber++;

        if (currentRunNumber >= spawns.Length)
        {
            currentRunNumber = 0;
        }

        runText.text = materials[currentRunNumber].name + " Run";
        runText.color = materials[currentRunNumber].color;
        player.transform.position = spawns[currentRunNumber].transform.position;
        Debug.Log(player.transform.position);
    }

    public void RunStarted()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0 )
        {
            PreRunInput();
            
        }
    }

    void PreRunInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartRun();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            NextRun();
        }
    }

    void StartRun()
    {
        Time.timeScale = 1;
        startText.enabled = false;
       runText.enabled = false;
        cycleText.enabled = false;
    }
}
