using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public GameObject MyPageTap;
    public GameObject RareTap;


    public void MyPageOpen()
    {
        if (!MyPageTap.activeSelf)
        {
            MyPageTap.SetActive(true);

            if(RareTap.activeSelf)
            {
                RareTap.SetActive(false);
            }
        }
    }

    public void RareTapOpen()
    {
        if (!RareTap.activeSelf)
        {
            RareTap.SetActive(true);

            if (MyPageTap.activeSelf)
            {
                MyPageTap.SetActive(false);
            }
        }
    }
}
