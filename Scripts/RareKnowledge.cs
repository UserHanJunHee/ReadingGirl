using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareKnowledge
{
    public int maxunderstandingpoint { get; set; }//최대 체력
    public string name { get; set; }//이름
    public string content { get; set; }//내용
    public string effect { get; set; }//효과
    public string acquisitionPlace { get;  set; }//획득 장소
    public float timer { get; set; }//전투 시간
    public bool acquisition { get; set; } = false; //습득 여부
    public Sprite[] sprites { get; set; }//스프라이트
    
    public RareKnowledge(Sprite[] sprites, int maxunderstandingpoint,string name,string content,string effec,string acquisitionPlace, float timer)
    {
        this.sprites = sprites;
        this.maxunderstandingpoint = maxunderstandingpoint;
        this.name = name;
        this.content = content;
        this.effect = effec;
        this.acquisitionPlace = acquisitionPlace;
        this.timer = timer;
    }

}
