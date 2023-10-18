using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    Image image;
    SpriteRenderer sprite;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
    }
    private void Update()
    {
        image.sprite = sprite.sprite;
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

}

