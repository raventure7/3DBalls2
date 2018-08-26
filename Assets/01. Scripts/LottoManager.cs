using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LottoManager : MonoBehaviour {
    public static LottoManager Instance = null;

    enum STATE
    {
        READY,
        START
    };

    STATE state = STATE.READY;

    //public GameObject[] ball;
    public int[] lottoArray = new int[6];
    public GameObject[] outputNumber = new GameObject[6];

    public Button btnStart; // 시작 버튼
    public Button btnExcept; // 제외수 버튼
    public Button btnBigdata;
    public GameObject pnExcept; // 제외 수 활성화 패널
    public GameObject pnBigdata; // 빅 데이터 패널

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

    }
	
	// Update is called once per frame
	void Update () {

        if (Hole.Instance.count == 0 || UINumberCount == 6)
        {
            btnStart.GetComponent<Button>().interactable = true;
            btnStart.GetComponentInChildren<Text>().text = "추첨시작";

            btnExcept.GetComponent<Button>().interactable = true;
            btnExcept.GetComponentInChildren<Text>().text = "제외수";
            if(UINumberCount == 6)
            {
                state = STATE.READY;
            }
        }
        else
        {
            if(state == STATE.START)
            {
                btnStart.GetComponent<Button>().interactable = false;
                btnStart.GetComponentInChildren<Text>().text = "추첨중";

                btnExcept.GetComponent<Button>().interactable = false;
                btnExcept.GetComponentInChildren<Text>().text = "불가";
            }
            //Debug.Log(Hole.Instance.count + ":" + UINumberCount);

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

    }
    public void PopupCloseBigdata()
    {

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

}
