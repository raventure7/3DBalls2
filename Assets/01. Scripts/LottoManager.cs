using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LottoManager : MonoBehaviour {
    public static LottoManager Instance = null;

    enum STATE
    {
        NONE,
        DEFAULT,
        READY,
        START,
        SAVE
    };

    STATE state = STATE.DEFAULT;

    //public GameObject[] ball;
    public int[] lottoArray = new int[6];
    public GameObject[] outputNumber = new GameObject[6];

    public Button btnStart; // 시작 버튼
    public Button btnExcept; // 제외수 버튼
    public Button btnBigdata;
    public Button btnSave;
    public GameObject pnExcept; // 제외 수 활성화 패널
    public GameObject pnBigdata; // 빅 데이터 패널


    public GameObject iconStart;
    public GameObject iconExcept;
    public GameObject iconBigdata;
    public GameObject iconSaveList;

    public int UINumberCount;

    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start () {
        // 공 생성

        BallManager.Instance.CreateBall();
        LottoInit();
        iconStart.SetActive(false);
        iconExcept.SetActive(false);
        iconBigdata.SetActive(false);
        iconSaveList.SetActive(false);

        btnSave.gameObject.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {

        if (Hole.Instance.count == 0 || UINumberCount == 6)
        {
            if (UINumberCount == 6)
            {
                UINumberCount = UINumberCount + 1;
                state = STATE.READY;
                
            }
            if(UINumberCount == 0)
            {
                btnSave.gameObject.SetActive(false);
            }
        }
        ButtonDisplay();

    }
    // 로또 상황별 버튼 처리
    public void ButtonDisplay()
    {
        //Debug.Log(state);
        switch(state)
        {
            case STATE.NONE:
                break;

            case STATE.DEFAULT:
                btnSave.gameObject.SetActive(false);

                iconStart.SetActive(true);
                iconExcept.SetActive(true);
                iconBigdata.SetActive(false);

                ButtonSetting(true, btnStart, "가능");
                ButtonSetting(true, btnExcept, "가능");
                ButtonSetting(false, btnBigdata, "추첨후가능");

                state = STATE.NONE;
                break;

            case STATE.START:
                iconStart.SetActive(false);
                iconExcept.SetActive(false);
                iconBigdata.SetActive(false);


                ButtonSetting(false, btnStart, "추첨중");
                ButtonSetting(false, btnExcept, "추첨중불가");
                ButtonSetting(false, btnBigdata, "추첨후가능");


                break;
            case STATE.READY:
                btnSave.gameObject.SetActive(true);
                
                iconStart.SetActive(true);
                iconExcept.SetActive(true);
                iconBigdata.SetActive(true);

                ButtonSetting(true, btnStart, "가능");
                ButtonSetting(true, btnExcept, "가능");
                ButtonSetting(true, btnBigdata, "가능");


                state = STATE.NONE;
                break;

        }
    }

    void ButtonSetting(bool state, Button button, string text)
    {
        if(state == true)
        {
            button.GetComponent<Button>().interactable = true;
            button.transform.Find("TextState").GetComponent<Text>().color = new Color32(69, 79, 255, 255);
       
        }
        else
        {
            button.GetComponent<Button>().interactable = false;
            button.transform.Find("TextState").GetComponent<Text>().color = new Color32(173, 173, 173, 255);
        }
        if(text != "")
        {
            button.transform.Find("TextState").GetComponent<Text>().text = text;
        }
    }

    // 시작 버튼 처리
    public void LottoStart()
    {
        // 캡슐 시작
        
        if(lottoArray[0] != 0)
        {
            Debug.Log("볼 다시 넣기");
            BallManager.Instance.ReturnBall();
        }
        LottoInit();
        Hole.Instance.start = true;
        state = STATE.START;
    }
    /*
     * 제외수 버튼 처리
     */
    public void PopupOpenExcept()
    {
        if (lottoArray[0] != 0)
        {
            Debug.Log("볼 다시 넣기");
            BallManager.Instance.ReturnBall();
            DeleteTopPanelBall();
            state = STATE.DEFAULT;
        }
        pnExcept.SetActive(true);
    }
    public void PopupCloseExcept()
    {
        pnExcept.SetActive(false);
    }
    /*
     * 빅데이터 버튼 처리
     */
    public void PopupOpenBigdata()
    {
        pnBigdata.SetActive(true);
        BigdataManager.Instance.NumberCheck();
    }
    public void PopupCloseBigdata()
    {
        pnBigdata.SetActive(false);
    }

    // 초기화 처리
    void LottoInit()
    {

        Hole.Instance.count = 0;
        Goal.Instance.count = 0;
        DeleteTopPanelBall();
    }
    

    // 탑 패널 U.I 표기 및 삭제
    public void AddTopPanelBall(int num)
    {
        outputNumber[UINumberCount].GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Prefabs/2D/ball_" + num) as Sprite;
        UINumberCount++;
    }
    public void DeleteTopPanelBall()
    {
        UINumberCount = 0;
        int i = 0;
        for (i = 0; i < lottoArray.Length; i++)
        {
            lottoArray[i] = 0;
        }

        for (i = 0; i < outputNumber.Length; i++)
        {
            outputNumber[i].GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Prefabs/UI/UI_Fill_Sky") as Sprite;
        }
    }
    // state 변경
    public void SetState(int val)
    {
        if(val == 0)
        {
            state = STATE.DEFAULT;
            Debug.Log(state);
        }

    }
}
