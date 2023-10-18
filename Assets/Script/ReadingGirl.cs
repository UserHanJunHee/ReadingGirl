using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Rendering;

public class ReadingGirl : MonoBehaviour
{
    public int intelligence { get; set; } = 1;//공격력(이해력)
    public float intelligencecorrection { get; set; } = 0;//지능 보정치(공격력 퍼센티지용도 가구랑같이 합산)
    public float findingknowledge { get; set; } = 5000f;//희귀 지식 발견 확률 
    public float bookflipspeed { get; set; } = 1;
    public Texture2D clothes;
    
    [SerializeField]
    private GameObject[] girlclothespart;
    
    private void Awake()
    {

    }
    public void ChangeClothes(Texture2D clothes)
    {
        foreach (GameObject clothsepart in girlclothespart)
        {
            clothsepart.GetComponent<CubismRenderer>().MainTexture = clothes;
        }
    }


    public void FinishBookFlip()//책 읽는 도중엔 클릭이 안된다 애니메이션 끝나면 비활성화 해준다
        //애니메이션 이밴트는 본인이 소유한 스크립트에밖에 안된다 그래서 여기다 넣어줌
    {
        GameManager.instance.choicebook.progresslevel = 0;
        GameManager.instance.bookflip = false;
    }
}
