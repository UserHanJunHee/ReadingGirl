using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookMessageBox : MonoBehaviour
{

    float activetime = 5f;
    float time;
    Image image;
    SpriteRenderer sprite;
    void Start()
    {
        
    }
    private void Awake()
    {
        time = activetime;
        image = gameObject.GetComponent<Image>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        GameManager.instance.bookmessageboxactive = true;
    }
    private void OnDisable()
    {
        GameManager.instance.bookmessageboxactive = false;
        time = activetime;
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprite.sprite;
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void TimerResrt()
    {
        time = activetime;
    }
}
