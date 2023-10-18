using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject underStandingBattle;
    float activetime = 5f;
    float time;

    float randomx; //전구 위치 랜덤 x
    int randomxdownpos; //음수 양수 정해줄거
    float randomy; //전구 위치 랜덤 y

    Transform resetpos;
    private void Awake()
    {
        time = activetime;
        resetpos = gameObject.transform.parent.transform;
    }
    

    private void OnEnable()
    {
        GameManager.instance.bulbactive = true;

        randomy = Random.Range(-1f, 3f);

        if(randomy >= 2.4)
        {
            randomx = Random.Range(-2.6f, 1.2f);
        }
        else 
        {
            if (randomy >= 1.7f)
            {
                randomxdownpos = Random.Range(0, 5);
                if (randomxdownpos <= 3)
                {
                    randomx = Random.Range(-2.6f, -1.8f);
                }
                else
                {
                    randomx = Random.Range(1f, 1.2f);
                }
            }
            else
            {
                randomx = Random.Range(-2.6f, -1.8f);
            }
        }

        //randomx = Random.Range(1.3f, 2.09f);
        //randomxdownpos = Random.Range(0, 2);
        

        //if(randomxdownpos == 0)
        //{
        //    randomx *= -1;
        //    transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
        //}
        transform.Translate(randomx, randomy, 0);
    }
    private void OnDisable()
    {
        GameManager.instance.bulbactive = false;
        time = activetime;
        transform.position = resetpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ClickThis(RareKnowledge rareKnowledge)
    {
        gameObject.SetActive(false);
        underStandingBattle.GetComponent<UnderStandingBattle>().Setting(rareKnowledge);
        underStandingBattle.SetActive(true);
    }

}
