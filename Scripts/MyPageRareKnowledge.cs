using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPageRareKnowledge : MonoBehaviour
{
    private bool making = false;
    //오른쪽 탭
    private GameObject rightTap;
    private Image rightTapImage;
    private Text righTapNameText;
    private Text rightTapContentText;

    //본인 관련
    private Image rareknowledgeimage;
    private RareKnowledge rareKnowledge;

    private void OnEnable()
    {
        if (making)
        {
            if(rareKnowledge.acquisition)
                rareknowledgeimage.color = new Color(255, 255, 255);
        }
            
    }
    private void Awake()
    {
        rareknowledgeimage = transform.GetChild(0).GetComponent<Image>();
    }


    public void ClickRareKnowledge()
    {
        if (!rightTap.activeSelf)
            rightTap.SetActive(true);

        rightTapImage.sprite = rareKnowledge.sprites[rareKnowledge.sprites.Length-1];

        if(rareKnowledge.acquisition)
        {
            rightTapImage.GetComponent<Image>().color = new Color(255, 255, 255);
            righTapNameText.text = rareKnowledge.name;
            rightTapContentText.text = $"{rareKnowledge.content}\n{rareKnowledge.effect}";
        }
        else
        {
            rightTapImage.GetComponent<Image>().color = new Color(0, 0, 0);
            righTapNameText.text = "???";
            rightTapContentText.text = $"{rareKnowledge.acquisitionPlace}";
            //rightTapContentText.text = $"미 획득";
        }
    }

    public void StartSetting(RareKnowledge rareKnowledge, Transform parenttransform, GameObject rightTap, Image rightimage, Text righTapNameText, Text rightTapContentText)
    {
        this.rareKnowledge = rareKnowledge;
        this.transform.SetParent(parenttransform);

        this.rightTap = rightTap;
        this.rightTapImage = rightimage;
        this.righTapNameText = righTapNameText;
        this.rightTapContentText = rightTapContentText;

        rareknowledgeimage.sprite = rareKnowledge.sprites[rareKnowledge.sprites.Length-1];
        if(!rareKnowledge.acquisition)
            rareknowledgeimage.color = new Color(0, 0, 0);

        making = true;
    }
}
