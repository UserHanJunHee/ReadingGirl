using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyPage : MonoBehaviour
{
    [SerializeField]
    ReadingGirl readingGirl;

    public Text intelligence;
    public Text wisdom;
    public Text understanding;
    public Text bookflipspeed;

    public Text intelligencepricetext;
    public Text wisdompricetext;
    public Text understandingpricetext;
    public Text bookflipspeedpricetext;

    public Button intelligencebuybutton;
    public Button wisdombuybutton;
    public Button understandingbuybutton;
    public Button bookflipspeedbuybutton;


    int intelligenceprice = 100;
    int wisdomprice = 1000;
    int understandingprice = 2000;
    int bookflipspeedprice=5000;

    private void Awake()
    {
        MyPageText();
        intelligencepricetext.text = $"{intelligenceprice}";
        wisdompricetext.text = $"{wisdomprice}";
        understandingpricetext.text = $"{understandingprice}";
        bookflipspeedpricetext.text = $"{bookflipspeedprice}";
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            CheckCanBuy();
        }
    }


    public void MyPageText()
    {
        intelligence.text = $"{readingGirl.intelligence}";
        wisdom.text = $"{readingGirl.intelligencecorrection} %";
        understanding.text = $"{readingGirl.findingknowledge} %";
        bookflipspeed.text = $"{readingGirl.bookflipspeed}";
    }

    public void BuyIntelligence()
    {
        readingGirl.intelligence++;
        GameManager.instance.possessiveknowledge -= intelligenceprice;
        intelligenceprice = (int)((float)intelligenceprice*(1f+10f/100f));
        GameManager.instance.RecalculationFinalIntelligence();
        CheckCanBuy();
        intelligence.text = $"{readingGirl.intelligence}";
        intelligencepricetext.text = $"{intelligenceprice}";
    }
    public void BuyWisdom()
    {
        readingGirl.intelligencecorrection += 10;
        GameManager.instance.possessiveknowledge -= wisdomprice;
        wisdomprice = (int)((float)wisdomprice * (1f + 10f / 100f));
        GameManager.instance.RecalculationFinalIntelligence();
        CheckCanBuy();
        wisdom.text = $"{readingGirl.intelligencecorrection} %";
        wisdompricetext.text = $"{wisdomprice}";
    }
    public void BuyUnderstanding()
    {
        readingGirl.findingknowledge += 10;
        GameManager.instance.possessiveknowledge -= understandingprice;
        understandingprice = (int)((float)understandingprice * (1f + 10f / 100f));
        GameManager.instance.RecalculationFinalFindRare();
        CheckCanBuy();
        understanding.text = $"{readingGirl.findingknowledge} %";
        understandingpricetext.text = $"{understandingprice}";
    }
    public void BuyBookflipspeed()
    {
        //Mathf.Round((goPosition.x+intervalX)/0.1f)*0.1f;
        readingGirl.bookflipspeed = (float)Math.Round(readingGirl.bookflipspeed + 0.1f, 2);
        GameManager.instance.possessiveknowledge -= bookflipspeedprice;
        bookflipspeedprice = (int)((float)bookflipspeedprice * (1f + 50f / 100f)); ;
        GameManager.instance.BookFlipSpeedAnimator();
        CheckCanBuy();
        bookflipspeed.text = $"{readingGirl.bookflipspeed}";
        bookflipspeedpricetext.text = $"{bookflipspeedprice}";
    }

    public void CheckCanBuy()
    {
        if (GameManager.instance.possessiveknowledge >= intelligenceprice)
        {
            if (!intelligencebuybutton.interactable)
                intelligencebuybutton.interactable = true;
        }
        else
        {
            if (intelligencebuybutton.interactable)
                intelligencebuybutton.interactable = false;
        }

        if (GameManager.instance.possessiveknowledge >= wisdomprice)
        {
            if (!wisdombuybutton.interactable)
                wisdombuybutton.interactable = true;
        }
        else
        {
            if (wisdombuybutton.interactable)
                wisdombuybutton.interactable = false;
        }

        if (GameManager.instance.possessiveknowledge >= understandingprice)
        {
            if (!understandingbuybutton.interactable)
                understandingbuybutton.interactable = true;
        }
        else
        {
            if (understandingbuybutton.interactable)
                understandingbuybutton.interactable = false;
        }

        if (GameManager.instance.possessiveknowledge >= bookflipspeedprice)
        {
            if (!bookflipspeedbuybutton.interactable)
                bookflipspeedbuybutton.interactable = true;
        }
        else
        {
            if (bookflipspeedbuybutton.interactable)
                bookflipspeedbuybutton.interactable = false;
        }
    }

}
