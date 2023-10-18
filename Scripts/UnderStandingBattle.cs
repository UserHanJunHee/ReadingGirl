using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderStandingBattle : MonoBehaviour
{
    int understandingstartpoint = 0;//시작체력(현재체력)
    SpriteRenderer content;//(스프라이트 변경용)
    float changepoint;//어느 기점으로 스프라이트가 변하는가 세팅에서 계산
    RareKnowledge rareKnowledge;//레이지식을 활성화될때 전해 받음
    float endtimer = 2f; //처리 완료하면 딜레이 후 사라지게 하는 용도
    float timer;
    bool finish = false;//클리어
    bool stopchangesprite = false;//스프라이트 그만 바꾸게 하는 용도

    [SerializeField]
    private GameObject timerslider;

    private void Awake()
    {
        content = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        GameManager.instance.understandingbattleactive = true;
        content.sprite = rareKnowledge.sprites[0];
        timerslider.SetActive(true);
    }
    private void OnDisable()
    {
        GameManager.instance.understandingbattleactive = false;
        timerslider.SetActive(false);
        understandingstartpoint = 0;
        finish = false;
        stopchangesprite = false;
        endtimer = 2f;
    }
    private void Update()
    {
        if (!finish)
        {
            timer -= Time.deltaTime;
            timerslider.GetComponent<Slider>().value = timer;
            if (timer<= 0)
            {
                finish = true;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                understandingstartpoint += GameManager.instance.finalIntelligence;

                Debug.Log(understandingstartpoint);

                if (!stopchangesprite)
                    ChangeSprite();

                if (understandingstartpoint >= rareKnowledge.maxunderstandingpoint)
                {
                    finish = true;
                    //int a = rareKnowledge.sprites.Length;         
                    content.sprite = rareKnowledge.sprites[rareKnowledge.sprites.Length-1];
                    GameManager.instance.choicebook.Reward(GameManager.instance.understandingbattlebnonus);
                    if (!rareKnowledge.acquisition)
                        rareKnowledge.acquisition = true;
                }
            }
        }
        else
        {
            endtimer -= Time.deltaTime;
            if (endtimer <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Setting(RareKnowledge rareKnowledge)
    {
        this.rareKnowledge = rareKnowledge;
        changepoint = (float)rareKnowledge.maxunderstandingpoint / rareKnowledge.sprites.Length;
        timer = rareKnowledge.timer;
        timerslider.GetComponent<Slider>().maxValue = rareKnowledge.timer;
    }
    public void ChangeSprite()
    {
        float i = understandingstartpoint / changepoint;
        int a = (int)Mathf.Floor(i);
        Debug.Log($"a{a}");

        if (a < rareKnowledge.sprites.Length-1)
            content.sprite = rareKnowledge.sprites[a];
        else
            stopchangesprite = true;
    }

}
