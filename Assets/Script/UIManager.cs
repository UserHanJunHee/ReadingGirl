using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager uIManager;
    public Text bookmessage;
    public ReadingGirl readinggirlScript;

    private void Awake()
    {
        if (uIManager == null)
        {
            uIManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Test()
    {
        Debug.Log("Test");
    }

    public void CloseUI(GameObject ui)
    {
        ui.SetActive(false);
        GameManager.instance.uiactiove = false;
    }
    public void OpenUI(GameObject ui)
    {
        if (!GameManager.instance.understandingbattleactive)
        {
            if (ui.activeSelf)
            {
                ui.SetActive(false);
                GameManager.instance.uiactiove = false;
            }
            else
            {
                if (!GameManager.instance.uiactiove)
                {
                    if (GameManager.instance.bookmessagebox.activeSelf)
                    {
                        GameManager.instance.bookmessagebox.SetActive(false);
                    }
                    ui.SetActive(true);
                    GameManager.instance.uiactiove = true;
                }
            }
        }
    }

    public void BookMessageBoxTextChange(string message)
    {
        bookmessage.text = message;
    }

}
