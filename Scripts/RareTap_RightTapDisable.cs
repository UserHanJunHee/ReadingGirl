using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareTap_RightTapDisable : MonoBehaviour
{
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
