using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour
{

    float blinktime = 0;
    Animator eyeblink;

    private void Awake()
    {
        eyeblink = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(blinktime < 2)
        {
            blinktime += Time.deltaTime;
        }       
        else
        {
            int count = Random.Range(0, 3);
            if(count < 1)
            {
                eyeblink.SetTrigger("EyeBlink");
            }
            blinktime = 0;
        }
    }
}
