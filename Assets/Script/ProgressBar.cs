using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image progressbar;

    private void Awake()
    {
        progressbar = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        progressbar.fillAmount = (float)GameManager.instance.choicebook.progresslevel / (float)GameManager.instance.choicebook.maxprogresslevel;
        //Debug.Log(progressbar.fillAmount);
    }
}
