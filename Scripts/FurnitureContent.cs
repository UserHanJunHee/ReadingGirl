using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureContent : MonoBehaviour
{
    Furniture furniture;
    Image image;
    GameObject button;
    Text pricetext;

    bool complete = false;
    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        button = transform.GetChild(1).gameObject;
        pricetext = transform.GetChild(1).GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        if(gameObject.activeSelf && !complete)
        {
            if (furniture.maxlevel >= furniture.level)
            {
                if (GameManager.instance.possessiveknowledge >= furniture.price[furniture.level])
                {
                    button.GetComponent<Button>().interactable = true;
                }
                else
                {
                    button.GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                complete = true;
                button.SetActive(false);
            }
        }
    }
    public void Buttonclick()
    {
        furniture.Effect();
        if (furniture.maxlevel >= furniture.level)
        {
            image.sprite = furniture.sprites[furniture.level];
            pricetext.text = $"${furniture.price[furniture.level]}";
        }
    }
    public void SettingFurniture(Furniture furniture, Transform parenttransform)
    {
        this.furniture = furniture;
        this.transform.SetParent(parenttransform);
        image.sprite = furniture.sprites[furniture.level];
        pricetext.text = $"${furniture.price[furniture.level]}";
    }
}
