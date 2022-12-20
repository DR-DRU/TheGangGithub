using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicPlatform : MonoBehaviour
{
    public int health = 10;
    [SerializeField] TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            health--;
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
        healthText.text = health.ToString();
    }
}
