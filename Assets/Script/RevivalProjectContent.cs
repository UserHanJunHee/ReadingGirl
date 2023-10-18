using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevivalProjectContent : MonoBehaviour
{
    RevivalProject revivalProject;
    GameObject levelbuttonactive;
    Button levelupbutton;
    Text levelupbuttonText;
    Image projectimage;


    int checknum;

    bool changecolor = false;
    bool startproject = false;
    bool nextrevivalProjectOpen = false;
    bool completeProject = false;
    private void Awake()
    {
        levelbuttonactive = transform.GetChild(0).gameObject;
        levelupbutton = transform.GetChild(0).GetComponent<Button>();
        levelupbuttonText = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        projectimage = GetComponent<Image>();
    }
    private void Update()
    {
        if(gameObject.activeSelf && !completeProject)
        {
            if(revivalProject.youcanstartproject)
            {
                if(!changecolor)
                {
                    changecolor = true;
                    projectimage.color = new Color(255, 255, 255);
                    levelupbuttonText.text = $"{revivalProject.projectprice}";
                    //projectimage.color = new Color(0, 0, 0);
                }
                if (revivalProject.maxprojectlevel >= revivalProject.projectlevel)
                {
                    if (GameManager.instance.possessiveknowledge >= revivalProject.projectprice)
                    {
                        levelupbutton.interactable = true;
                    }
                    else
                    {
                        levelupbutton.interactable = false;
                    }
                }
                else
                {
                    completeProject = true;
                    projectimage.sprite = revivalProject.completprojectimage;
                    levelbuttonactive.SetActive(false);
                    Conversation.conversation.StartConversation(Conversation.conversation.completestory[checknum], revivalProject.projectotherpersonname, revivalProject.youfinishprojecttakingleft, revivalProject.peoplesprite);
                }
            }
        }
    }


    public void ProjectLevelUPButton()
    {
        revivalProject.ClickButtonEffect();
        levelupbuttonText.text = $"{revivalProject.projectprice}";

        if(!startproject)
        {
            startproject = true;
            //최초 스토리 나오는 구문
            Conversation.conversation.StartConversation(Conversation.conversation.story[checknum],revivalProject.projectotherpersonname, revivalProject.youstartprojecttakingleft, revivalProject.peoplesprite);
        }
        else if(revivalProject.projectlevel >= revivalProject.maxprojectlevel/2 && !nextrevivalProjectOpen)
        {    
            nextrevivalProjectOpen = true;
            if(checknum != GameManager.instance.revivalproject.Count-1)
            {
                GameManager.instance.revivalproject[checknum + 1].youcanstartproject = true;
            }
        }
    }
    public void SettingThisScript(RevivalProject revivalProject, Transform parenttransform,int checknum)
    {
        this.revivalProject = revivalProject;
        this.checknum = checknum;
        projectimage.sprite = revivalProject.projectimage;
        this.transform.SetParent(parenttransform);
        if (this.revivalProject.youcanstartproject)
        {
            levelupbutton.interactable = true;
            levelupbuttonText.text = $"{revivalProject.projectprice}";
        }
        else
        {
            projectimage.color = new Color(0, 0, 0);
            levelupbutton.interactable = false;
            levelupbuttonText.text = $"미 발견";
        }
    }
}
