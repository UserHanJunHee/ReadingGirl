using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //게임 매니저 싱글톤
    public static GameManager instance;

    public GameObject coversation;

    //리딩걸
    [SerializeField]
    ReadingGirl readingGirl;
    Animator girl;// 소녀 애니메이터
    Animator book;// 책 애니메이터
    Animator eye;//눈 깜빡임

    //public GameObject plusTextPrefab;//클릭시 나오는 + 마크
    public GameObject clickeffectPrefab;//클릭시 나오는 반짝임 효과


    //상태
    public bool bookflip = false;//책을 넘기는 중
    public bool bulbactive = false;//전구 활성화
    public bool uiactiove = false;//유아이 열었을때 클릭 안되게 막아주는 용도
    public bool bookmessageboxactive = false;

    //스탯 숫자,보정, 지식 관련

    public int possessiveknowledge = 0; // 가진 지식 (돈)
    public int acquisitionpersecondpossessiveknowlege = 0;//초당 획득 지식
    public float bed_intelligence = 0;//침대 지식 보정
    private float finalFindRare = 0f;//지식 발견 계산 도합
    public int finalIntelligence = 0; //지식 보정 계산 도합
    public int understandingbattlebnonus = 5;//지식 배틀 보상 보정치

    public float gainsecondtimeknowlege = 0;//카운팅용 초당 획등
    public float gainsecondtimelimit = 1;// 리미트 타임



    //책 관련된 내용은 이 밑에 적혀있다.

    public Texture2D[] bookstexture;//북 텍스쳐 모음

    public List<Book> booklist = new List<Book>();//만들어놓은 책 보관하는곳
    public Book choicebook;//본인이 고른 책

    //책 메세지
    public GameObject bookmessagebox;
    
    private string[] fairytalemessage = { "안갯속에 갇힌 성이 보인다면, 그곳으로 걸어가야 놀라운 꿈을 실현할 수 있습니다.", "등자만큼 간단한 발명품은 많지 않지만, 또 등자만큼 역사에 촉매 같은 영향을 준 발명품도 많지 않다.", "사랑이 낳은 속임수로구나. 상징적인 이별의 포옹이야.", "별을 보고 항로를 정해라, 지나가는 모든 배의 등불 말고.", "모든 것에는 한계가 있다. 철이 교육받았다고 금이 되진 않는다.", "일반인은 고장나지 않은 것은 고치지 말아야 한다고 믿죠. 하지만 엔지니어는 고장나지 않은 것은 아직 특징이 충분하지 않다고 믿습니다." };
    private string[] novelmessage = {"'기사가 있었네. 용맹한 자였지'", "지혜가 아니라 권한이 법을 만든다네.", "그게 무역의 긍정적인 면이겠지. 전 세계가 함께 뒤섞이는 것 말이야.", "수천 명의 사람이 사랑 없이 살아왔지만, 그 누구도 물 없이 살 수는 없었다." , "전술이란 당신이 가진 것으로 할 수 있는 것을 의미합니다.", "교육의 목적은 비어있는 머리를 열려있는 머리로 바꾸는 것이다.", "방황하는 모든 이들이 길을 잃는 것은 아니다.", "용맹은 자신이 두려워하고 있는 것을 본인만이 아는 것이다.", "튼튼한 경제는 튼튼하고 교양 있는 노동자로부터 시작된다." , "삶을 위한 가장 중요한 필수품이 빵이라면, 여가는 근접한 2위일세." };

    //희귀 지식 소환 부분(전구)

    public GameObject bulb;//전구
    public bool understandingbattleactive = false;

    //희귀지식 마이페이지에 쌓는 부분
    public GameObject storeMyPageRareKnowledge;

    public GameObject rightTap;
    public Transform storeMyPageRareKnowledgeTransform;
    public Image rightImage;
    public Text rareKnowledgeName;
    public Text rareKnowledgeContent;

    //희귀 지식 리스트 (ex동화책 희귀지식을 쫙 만들고 이 리스트를 책 만들때 넣는다)

    public List<RareKnowledge> fairytale = new List<RareKnowledge>();
    public List<RareKnowledge> novel = new List<RareKnowledge>();


    //희귀 지식 스프라이트 부분

    //동화책
    public Sprite[] reality_of_fairytale_sprite;
    public Sprite[] mild_legend_sprite;
    //소설책
    public Sprite[] Ideal_life_sprite;



    //부흥 사업 관련
    public GameObject revivalprojectprefab;
    public Sprite[] reviavalapeplesprite;
    public Sprite[] reviavalprojectSprite;
    public Sprite[] reviavalprojectCompletSprite;
    public Transform reviavalprojecttransform;
    public List<RevivalProject> revivalproject = new List<RevivalProject>();

    //가구 관련

    public Transform furnituretransform;
    public List<Furniture> furnitureslist = new List<Furniture>();
    public GameObject furnitureitem;

    //침대

    public GameObject gobed;
    public Sprite[] bedsprite;
    int[] bedprice = {1000,2000 };
    float[] bedeffect = { 10, 20 };


    Vector2 mousepos; //누른 위치에 숫자 나오게 하기 위한 용도

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(!coversation.activeSelf)
        {
            coversation.SetActive(true);
        }

        Screen.SetResolution(Screen.width, Screen.width * Screen.width / Screen.height, true);

        FristMakeRareKnowleges();
        Book fairyTaleBook = new FairyTaleBook(bookstexture[1],fairytale,fairytalemessage);
        //fairyTaleBook.ChangeBookTexture();


        Book novelBook = new Novel(bookstexture[0],novel,novelmessage);


        booklist.Add(fairyTaleBook);
        booklist.Add(novelBook);

        choicebook = booklist[0];
        choicebook.ChangeBookTexture();

        FistMakeStoreRareKnowlege();

        RecalculationFinalIntelligence();
        RecalculationFinalFindRare();
        FirstMakeRevivalProject();
        FirstMakeFurniture();

        girl = GameObject.Find("girl").GetComponent<Animator>();
        book = GameObject.Find("book").GetComponent<Animator>();
        eye = GameObject.Find("eye").GetComponent<Animator>();
    }

    void Update()
    {
        //if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))//터치구문
        //    return;

        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log("Damm");
        //    return;

        if(acquisitionpersecondpossessiveknowlege != 0 && !Conversation.conversation.ingthis)
        {
            //public float gainsecondtimeknowlege = 0;//카운팅용 초당 획등
            //public float gainsecondtimelimit = 1;// 리미트 타임
            gainsecondtimeknowlege += Time.deltaTime;
            if(gainsecondtimeknowlege >= gainsecondtimelimit)
            {
                gainsecondtimeknowlege = 0;
                possessiveknowledge += acquisitionpersecondpossessiveknowlege;
            }
        }

        if (Input.GetMouseButtonDown(0) && !bookflip && EventSystem.current.IsPointerOverGameObject() == false && !understandingbattleactive && !uiactiove && !Conversation.conversation.ingthis)//유아이 클릭이 아닐시
        {
            mousepos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousepos);
            Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);
            // mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            if (bulbactive)
            {
                //Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);

                Ray2D ray = new Ray2D(clickPos, Vector2.zero);
                RaycastHit2D rayHit = Physics2D.Raycast(ray.origin, ray.direction);


                if (rayHit.collider != null)//이 게임에 콜라이더는 전구밖에 없다.
                {
                    int i = Random.Range(0, choicebook.rareKnowledges.Count);
                    if (bookmessagebox.activeSelf)
                        bookmessagebox.SetActive(false);
                    bulb.GetComponent<Bulb>().ClickThis(choicebook.rareKnowledges[i]);
                    
                    Debug.Log("Find");
                }
                else
                {
                    //Instantiate(plusTextPrefab, new Vector3(mousepos.x, mousepos.y, 0), Quaternion.identity);//이건 ui캔버스 위치
                    //Instantiate(clickeffectPrefab, new Vector3(clickPos.x, clickPos.y, 0), Quaternion.identity);//이건 게임 위치
                    Instantiate(clickeffectPrefab, new Vector3(mousepos.x, mousepos.y, 0), Quaternion.identity);
                    choicebook.progresslevel += finalIntelligence;
                }

                //Collider2D clickColl = Physics2D.OverlapPoint(clickPos);
                //if (clickColl.gameObject != null)
                //    Debug.Log("Find");
            }
            else
            {
                //Instantiate(plusTextPrefab, new Vector3(mousepos.x, mousepos.y, 0), Quaternion.identity);//이건 ui캔버스 위치
                //Instantiate(clickeffectPrefab, new Vector3(clickPos.x, clickPos.y, 0), Quaternion.identity);//이건 게임 위치
                Instantiate(clickeffectPrefab, new Vector3(mousepos.x, mousepos.y, 0), Quaternion.identity);
                choicebook.progresslevel += finalIntelligence;
            }


                //plustext.transform.parent = canvastest.transform;//캔버스로 이동시킴

                //Instantiate(testtext);



            if (choicebook.progresslevel >= choicebook.maxprogresslevel)
            {
                int iTemp = Random.Range(100, 10001);
                float fValue = (float)iTemp * 0.01f;//소수점 2자리만 나오게끔 한거임


                Debug.Log($"확률보정 : {finalFindRare}");
                Debug.Log($"확률 : {fValue}");
                if (fValue <= finalFindRare)
                {
                    bookflip = true;

                    //choicebook.progresslevel = 0;
                    choicebook.Reward();
                    Debug.Log($"확률 뚫음");

                    if(!bulb.activeSelf)
                        bulb.SetActive(true);

                    int messagerandom = Random.Range(0, choicebook.message.Length);
                    if (!bookmessagebox.activeSelf)
                    {
                        //int messagerandom = Random.Range(0, choicebook.message.Length);
                        UIManager.uIManager.BookMessageBoxTextChange(choicebook.message[messagerandom]);
                        bookmessagebox.SetActive(true);
                    }
                    else
                    {
                        bookmessagebox.GetComponent<BookMessageBox>().TimerResrt();
                        UIManager.uIManager.BookMessageBoxTextChange(choicebook.message[messagerandom]);
                        
                    }


                    girl.SetTrigger("BookFlip");
                    book.SetTrigger("BookFlip");

                }
                else
                {

                    bookflip = true;
                    //choicebook.progresslevel = 0;
                    choicebook.Reward();

                    //girl.SetFloat("TestSpeed", testspeed);//피러미터 바꿔주는거임 애니메이터에서 속도를 이걸로 쓴다고 설정해 주는 부분이 있음 책 넘기는 속도에 영향을 끼치기 위한 용도
                    //book.SetFloat("TestSpeed", testspeed);
                    //testspeed++;


                    //choicebook = booklist[1];책 바꾸는거 테스트용
                    //choicebook.ChangeBookTexture();

                    int messagerandom = Random.Range(0, choicebook.message.Length);
                    if (!bookmessagebox.activeSelf)
                    {
                        //int messagerandom = Random.Range(0, choicebook.message.Length);
                        UIManager.uIManager.BookMessageBoxTextChange(choicebook.message[messagerandom]);
                        bookmessagebox.SetActive(true);
                    }
                    else
                    {
                        bookmessagebox.GetComponent<BookMessageBox>().TimerResrt();
                        UIManager.uIManager.BookMessageBoxTextChange(choicebook.message[messagerandom]);
                    }


                    girl.SetTrigger("BookFlip");
                    book.SetTrigger("BookFlip");

                }
                
            }
        }
        eye.SetBool("BookFlip", bookflip);
    }


    public void RecalculationFinalIntelligence()//클릭당 지식 재 계산
    {
        float a = readingGirl.intelligence * (1f + (readingGirl.intelligencecorrection+bed_intelligence) / 100f);
        finalIntelligence = (int)a;
        //finalIntelligence = readingGirl.intelligence*(1f+readingGirl.intelligencecorrection/100f);
    }
    public void RecalculationFinalFindRare()//레어 발견 확률 재 계산
    {
        //Debug.Log(10f * (1f + 10f / 100f));
        finalFindRare = choicebook.rareKnowledgeProbability * (1f+readingGirl.findingknowledge/100f);
    }
    private void FristMakeRareKnowleges()//레어 지식 생성 (시작할때 함)
    {
        RareKnowledge realityofFairytale = new RareKnowledge(reality_of_fairytale_sprite, 50,"동화 속 현실","아름다운 이야기만 있는곳은 아니였다.","지능+1","동화책에서 습득 가능",7f);
        fairytale.Add(realityofFairytale);
        RareKnowledge mildLegend = new RareKnowledge(mild_legend_sprite, 40,"만들어진 전설","허황된 전설 만들어진 이야기","이해력+1", "동화책에서 습득 가능", 8f);
        fairytale.Add(mildLegend);




        RareKnowledge IdealLife = new RareKnowledge(Ideal_life_sprite, 60,"이상적인 삶","하루를 걱정 없이 산다는 것.","지혜 +1","소설책에서 획득 가능", 10f);
        novel.Add(IdealLife);
    }

    private void FistMakeStoreRareKnowlege()
    {
        for(int i = 0; i < booklist.Count; i++)
        {
            for(int f = 0; f < booklist[i].rareKnowledges.Count; f++)
            {
                GameObject mypagerare = Instantiate(storeMyPageRareKnowledge);
                mypagerare.GetComponent<MyPageRareKnowledge>().StartSetting(booklist[i].rareKnowledges[f], storeMyPageRareKnowledgeTransform,rightTap,rightImage,rareKnowledgeName,rareKnowledgeContent);
            }
        }
    }

    private void FirstMakeRevivalProject()
    {
        RevivalProject orphanages = new RevivalProject(reviavalprojectSprite[0], reviavalprojectCompletSprite[0],reviavalapeplesprite[0],"소년", 3,100,10,true,true,false);
        revivalproject.Add(orphanages);
        RevivalProject refugeecamp = new RevivalProject(reviavalprojectSprite[1], reviavalprojectCompletSprite[1], reviavalapeplesprite[1], "난민", 3, 100, 10, false,false,false);
        revivalproject.Add(refugeecamp);
        int checknum = 0;
        foreach (RevivalProject i in revivalproject)
        {
            GameObject revivaleprojectprefab = Instantiate(revivalprojectprefab);
            revivaleprojectprefab.GetComponent<RevivalProjectContent>().SettingThisScript(i, reviavalprojecttransform,checknum);
            checknum++;
        }
        //for(int i = 0; i < revivalproject.Count; i++)
        //{
        //    GameObject revivaleprojectprefab = Instantiate(revivalprojectprefab);
        //    revivaleprojectprefab.GetComponent<RevivalProjectContent>().SettingThisScript(revivalproject[i], reviavalprojecttransform);
        //}

    }

    private void FirstMakeFurniture()
    {
        Furniture bed = new Furniture(bedsprite,bedprice,bedeffect,0,gobed);

        furnitureslist.Add(bed);

        foreach (Furniture i in furnitureslist)
        {
            GameObject furniture = Instantiate(furnitureitem);
            furniture.GetComponent<FurnitureContent>().SettingFurniture(i, furnituretransform);
        }

    }
    public void ChoiceBook(int i)
    {
        choicebook = booklist[i];
        choicebook.progresslevel = 0;
        RecalculationFinalFindRare();
        choicebook.ChangeBookTexture();
    }


    public void BookFlipSpeedAnimator()
    {
        girl.SetFloat("BookFlipSpeed", readingGirl.bookflipspeed);
        book.SetFloat("BookFlipSpeed", readingGirl.bookflipspeed);
    }

}
