using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevivalProject
{
    public string projectotherpersonname { get; set; }//부흥사업 대표의 이름
    public int acquisitionpersecond { get; set; }//초당 획득
    public int projectprice { get; set; }//부흥 사업 가격
    public int projectlevel { get; set; } = 0;//부흥 사업 진행 레벨
    public int maxprojectlevel { get; set; }//부흥 사업 만렙
    public bool youcanstartproject { get; set; }//부흥 사업 시작 가능 여부
    public bool youstartprojecttakingleft { get; set; }
    public bool youfinishprojecttakingleft { get; set; }
    public Sprite peoplesprite { get;  set; }//사람 이미지
    public Sprite projectimage { get; private set; }//부흥 사업 이미지
    public Sprite completprojectimage { get; private set; }//부흥 사업 완료 이미지

    public RevivalProject(Sprite projectimage,Sprite completprojectimage, Sprite peoplesprite, string projectotherpersonname,int acquisitionpersecond,int projectprice ,int maxprojectlevel, bool youcanstartproject,bool youstartprojecttakingleft, bool youfinishprojecttakingleft)
    {
        this.projectimage = projectimage;
        this.completprojectimage = completprojectimage;
        this.peoplesprite = peoplesprite;
        this.projectotherpersonname = projectotherpersonname;
        this.acquisitionpersecond = acquisitionpersecond;
        this.projectprice = projectprice;
        this.maxprojectlevel = maxprojectlevel;
        //this.checknum = checknum;
        this.youcanstartproject = youcanstartproject;
        this.youstartprojecttakingleft = youstartprojecttakingleft;
        this.youfinishprojecttakingleft = youfinishprojecttakingleft;
    }

    public void ClickButtonEffect()
    {
        GameManager.instance.acquisitionpersecondpossessiveknowlege -= acquisitionpersecond * projectlevel;
        projectlevel++;
        GameManager.instance.possessiveknowledge -= projectprice;
        projectprice = (int)((float)projectprice * (1f + 10f / 100f)); ;
        GameManager.instance.acquisitionpersecondpossessiveknowlege += acquisitionpersecond * projectlevel;
    }
}
