using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPlusNumScirpt : MonoBehaviour
{

    private void Awake()
    {
        gameObject.GetComponent<Text>().text = $"+{UIManager.uIManager.readinggirlScript.intelligence}";
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        //gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        Destroy(gameObject, 2);
    }

}
