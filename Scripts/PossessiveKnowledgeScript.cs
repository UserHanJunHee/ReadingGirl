using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessiveKnowledgeScript : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = $"지식 : {GameManager.instance.possessiveknowledge}";
    }
}
