using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture
{
    public int level { get; private set; }= 0;
    public int maxlevel { get; private set; }
    public Sprite[] sprites { get; private set; }//모양
    public int[] price { get; private set; }//가격
    public float[] effect { get;private set; }//효과
    public int label { get; private set; }
    public GameObject gameObject;
    public Furniture(Sprite[] sprites, int[] price, float[] effect, int label , GameObject gameObject)
    {
        this.sprites = sprites;
        this.price = price;
        this.effect = effect;
        this.label = label;
        this.maxlevel = price.Length - 1;
        this.gameObject = gameObject;
    }

    public void Effect()
    {
        switch(label)
        {
            case 0:
                GameManager.instance.bed_intelligence += effect[level];
                GameManager.instance.RecalculationFinalIntelligence();
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[level];
        level++;
    }

    //protected virtual void Effect()
    //{

    //}
}

//public class Bed : Furniture
//{
//    public Bed(Sprite[] sprites, int[] price, float[] effect) : base(sprites, price, effect)
//    {
        
//    }

//    protected override void Effect()
//    {
//        GameManager.instance.bed_intelligence += effect[level];
//    }
//}
