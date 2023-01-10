using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    FirstPersonController controller;

    [SerializeField]
    AudioClip slowFootsteps;
    [SerializeField]
    AudioClip fastFootsteps;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<FirstPersonController>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.Grounded && Time.timeScale == 1)
        {
            if (controller._speed > 4)
            {
                source.clip = fastFootsteps;
                if (!source.isPlaying)
                {
                    source.Play();
                }

            }
            else if (controller._speed > 0)
            {
                source.clip = slowFootsteps;
                if (!source.isPlaying)
                {
                    source.Play();
                }

            }
            else
            {
                source.clip = null;
            }
        }
        else
        {
            source.clip = null;
        }

    }
}
