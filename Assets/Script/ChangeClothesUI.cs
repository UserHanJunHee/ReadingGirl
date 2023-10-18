using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClothesUI : MonoBehaviour
{
    //[SerializeField]
    //ReadingGirl readinggirlScript;

    [SerializeField]
    private Texture2D[] clothes;




    public void ClotheButton(int i)//나중에 페에지를 만들든 쭉 나열하든 하자
    {
        Debug.Log("a");
        UIManager.uIManager.readinggirlScript.ChangeClothes(clothes[i]);
        //readinggirlScript.ChangeClothes(clothes[i]);
    }
}
