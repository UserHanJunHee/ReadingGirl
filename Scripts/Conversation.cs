using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{

    public static Conversation conversation;
    //List<ConversationContent[]> storytest = new List<ConversationContent[]>();

    //struct ConversationContent
    //{
    //    Sprite sprite;
    //    string mesagge;
    //}
    public Text nameText;
    public Text messageText;

    string girlname = "책 읽는 소녀";
    //string[] theotherpersonname = {"소년","수도원장"};
    string whoyoutaking;//위에 있는 소년 수도원장 누구인지 넣는 구문

    public Image leftImage;
    public Image rightImage;

    Color imageA100 = new Color(255, 255, 255, 1);
    Color imageA50 = new Color(255, 255, 255, 0.5f);

    //public Sprite[] sprites;
    string[][] youchoicethis;
    int messageindex = 0;//하나씩 글자 나오는 용도
    int checkendmessage = 0;//배열의 몇번째인지 확인 용도
    bool loadingmessage;//메세지를 하나씩 보여주고있는 장면중인가?
    bool ifyoustartleft;//좌측 애부더 말하는가
    public bool ingthis = false;
    //string[][] storytest1 = new string[][]
    //{
    //   new string[] { "말하기 테스트 입니다","한 마디 더 해보죠","두.. 마디 정도?" },
    //   new string[] { "말을 주고 받을줄 알아야하죠", "훌륭합니다." },
    //   new string[] { "이것으로 테스트는 끝입니다." }
    //};

    public List<string[][]> story = new List<string[][]>();
    public List<string[][]> completestory = new List<string[][]>();

    //ConversationContent[][] a;
    public bool starteventconversation = true;

    int j = 0;//앞
    int i = 0;//뒤
    
    

    private void Awake()
    {
        if (conversation == null)
        {
            conversation = this;
            MakingFirstStory();
            MakingCompleteStory();
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }

        //storytest1[][] =
        //{
        //    storytest1[0] = new string[] { "말하기 테스트 입니다" };
        //    storytest1[1] = new string[] { "말을 주고도 받을줄 알아야하죠", "훌륭합니다." };
        //    storytest1[2] = new string[] { "이것으로 테스트는 끝입니다." };
        //}
        //StartConversation(storytest1);

        //youchoicethis = storytest1;
        //Debug.Log(youchoicethis[i].Length);
        //StartConversation(storytest1, true, 0);
    }

    private void Update()
    {
        if(gameObject.activeSelf && starteventconversation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(loadingmessage)
                {
                    CancelInvoke();
                    messageindex = 0;
                    loadingmessage = false;
                    messageText.text = youchoicethis[j][i];
                }
                else
                {
                    messageText.text = "";
                    loadingmessage = true;
                    if (checkendmessage <= youchoicethis[j].Length-1)
                    {
                        i++;
                        checkendmessage++;
                        NextMessage();
                    }
                    else
                    {
                        Debug.Log(youchoicethis.Length);
                        if(j >= youchoicethis.Length-1)
                        {
                            ingthis = false;
                            gameObject.SetActive(false);
                            return;
                        }
                        i = 0;
                        j++;
                        checkendmessage = 0;
                        if (ifyoustartleft)
                        {
                            ifyoustartleft = false;
                            rightImage.color = imageA100;
                            leftImage.color = imageA50;
                            nameText.text = whoyoutaking;
                            NextMessage();
                        }
                        else
                        {
                            ifyoustartleft = true;
                            rightImage.color = imageA50;
                            leftImage.color = imageA100;
                            nameText.text = girlname;
                            NextMessage();
                        }
                        checkendmessage++;
                    }
                }

            }
        }
    }

    public void StartConversation(string[][] choicestory,string name,bool ifyoustartleft,Sprite sprite)
    {
        ingthis = true;
        youchoicethis = choicestory;
        whoyoutaking = name;
        this.ifyoustartleft = ifyoustartleft;
        rightImage.sprite = sprite;
        i = 0;
        j = 0;
        if (ifyoustartleft)
        {
            nameText.text = girlname;
            rightImage.color = imageA50;
            leftImage.color = imageA100;
        }
        else
        {
            nameText.text = whoyoutaking;
            rightImage.color = imageA100;
            leftImage.color = imageA50;
        }
        //messageText.text = youchoicethis[j][i];
        //NextMessage(choicestory[j][i]);
        messageText.text = "";
        gameObject.SetActive(true);
        loadingmessage = true;
        NextMessage();
        checkendmessage++;
        starteventconversation = true;

    }
    public void NextMessage()
    {
        if (messageText.text == youchoicethis[j][i])
        {
            messageindex = 0;
            return;
        }
        messageText.text += youchoicethis[j][i][messageindex];
        messageindex++;

        Invoke("NextMessage", 0.1f);
    }

    public void MakingFirstStory()
    {
        string[][] orphanages = new string[][]
        {
        new string[] { "여기는 너무 가난하고, 힘든 하루하루를 보내는 것 같구나","내 말이 맞니 꼬마야?" },
        new string[] { "... ... 시비 걸러 오셨어요?", "여긴 고아원이니 가난하고 힘든거에요." },
        new string[] { "그걸 내가 조금 도와줄 수 있지. 대신에..." },
        new string[] { "대신에 ...?" },
        new string[] { "일기라도 써서 주렴, 그 또한 책일테니." }
        };

        string[][] refugeecamp = new string[][]
        {
        new string[] { "... ..." },
        new string[] { "... ..." },
        new string[] { "... ..." },
        new string[] { "... ..." },
        new string[] { "... ..." },
        new string[] { "... ...?" },
        new string[] { "뭘 자꾸 쳐다보는 거야" },
        new string[] { "혹시 당신들 나라에서 가져온 책 있어?" },
        new string[] { "... ..." ,"무슨 말을 하고싶은거야"},
        new string[] { "적어도 굶어 죽게 해주진 않을께","사람들에게 물어봐 내게 주는만큼 나도 부흥을 줄게" },
        };

        story.Add(orphanages);
        story.Add(refugeecamp);

    }

    public void MakingCompleteStory()
    {
        string[][] orphanages = new string[][]
        {
        new string[] { "정말로 감사합니다." },
        new string[] { "감사는 됬고 일기는 쓰고있니?", "나한테는 그게 제일 중요해." },
        new string[] { "정말로 이런거로 보상이 되는거에요?","그보다 일기를 남이 읽는게 좀 부끄러운데" },
        new string[] { "이미 그런 계약이였잖니, 빨리 넘겨" ,"그리고 자주 쓰고 또 내게 주면 그게 내게 보상이야"},
        new string[] { "이상한 사람이네요" },
        new string[] { "그러게." }
        };

        string[][] refugeecamp = new string[][]
        {
        new string[] { "우리의 대우가 변했어" },
        new string[] { "... ..." },
        new string[] { "우리도 이 사회의 일원이 되었지" },
        new string[] { "... ..." },
        new string[] { "무시당하는 시선은 감사함으로 변했고" },
        new string[] { "... ..." },
        new string[] { "다시 출발 할 용기를 얻었다, 정말로 고맙다." },
        new string[] { "그래서 책은?" },
        new string[] { "감동이 없는 여자로군" ,"사실 난민들이 얼마나 많은 책을 가지고 있겠냐만은"},
        new string[] { "하지만 그 책이 그 어디에서도 구할 수 없는 책이지"},
        new string[] { "정답이야 그리고 이젠 당신꺼지","... ...","언제든 도움이 필요하면 말해 우린 이런걸로 은혜 갚았다 생각하는 사람들은 아니야."},
        new string[] { "그래 하지만 계약은 끝났어 수고해"},
        };

        completestory.Add(orphanages);
        completestory.Add(refugeecamp);
    }
    
}
