using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Rendering;

public class Book
{
    private GameObject[] bookpart = { GameObject.Find("book_front"), GameObject.Find("book_back") };

    public int progresslevel { get; set; } = 0;//현재 체력
    public int maxprogresslevel { get; private set; }//최대 체력
    public float rareKnowledgeProbability { get; private set; }//레어 발견 확률
    public List<RareKnowledge> rareKnowledges{get;set;}//레어 지식 리스트 
    public int compensatoryKnowledge { get; private set; }//보상 지식
    public string[] message { get; set; }//화면 중단에 나오는 메세지 책마다 가지고 있는 메세지
    private Texture2D booktexture;

    public Book(Texture2D booktexture, List<RareKnowledge> rareKnowledges, string[] message, int maxprogresslevel, float rareKnowledgeProbability, int compensatoryKnowledge)
    {
        this.booktexture = booktexture;
        this.rareKnowledges = rareKnowledges;
        this.maxprogresslevel = maxprogresslevel;
        this.rareKnowledgeProbability = rareKnowledgeProbability;
        this.compensatoryKnowledge = compensatoryKnowledge;
        this.message = message;
    }

    public void Reward()
    {
        GameManager.instance.possessiveknowledge += compensatoryKnowledge;
    }
    public void Reward(int i)//보정치 받으면서 올른다 희귀지식 보스전 할때 이걸 소환한다
    {
        GameManager.instance.possessiveknowledge += compensatoryKnowledge*i;
    }

    //public void RareKnowlegeActive()
    //{
    //    int random = UnityEngine.Random.Range(0,rareKnowledges.Count);


    //}

    public void ChangeBookTexture()
    {
        progresslevel = 0;
        foreach (GameObject bp in bookpart)
        {
            bp.GetComponent<CubismRenderer>().MainTexture = this.booktexture;
        }
    }
}



public class FairyTaleBook : Book
{
    public FairyTaleBook(Texture2D booktexture, List<RareKnowledge> rareKnowledges, string[] message, int maxprogresslevel = 10, float rareKnowledgeProbability = 2, int compensatoryKnowledge = 10) : base(booktexture, rareKnowledges,message, maxprogresslevel, rareKnowledgeProbability, compensatoryKnowledge)
    {
    }
}


public class Novel : Book
{
    public Novel(Texture2D booktexture, List<RareKnowledge> rareKnowledges, string[] message, int maxprogresslevel=30, float rareKnowledgeProbability = 1.5f, int compensatoryKnowledge = 50) : base(booktexture,rareKnowledges, message, maxprogresslevel, rareKnowledgeProbability, compensatoryKnowledge)
    {
    }
}