using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigdataManager : MonoBehaviour {
    public static BigdataManager Instance = null;
    public List<Dictionary<string, object>> historyData;
    ArrayList arrayRank5 = new ArrayList();
    ArrayList arrayRank4 = new ArrayList();
    ArrayList arrayRank3 = new ArrayList();
    ArrayList arrayRank2 = new ArrayList();
    ArrayList arrayRank1 = new ArrayList();

    DBManagerScript DBManager;
    LottoReaderScript LottoReader;

    int count = 0;
    bool bonusCheck = false;

    public Text rank5CountText;
    public Text rank5HistoryText;
    public Text rank4CountText;
    public Text rank4HistoryText;
    public Text rank3CountText;
    public Text rank3HistoryText;
    public Text rank2CountText;
    public Text rank2HistoryText;
    public Text rank1CountText;
    public Text rank1HistoryText;

    public Text state;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        DBManager = GameObject.Find("DBManagerScript").GetComponent<DBManagerScript>();
        LottoReader = GameObject.Find("LottoReaderScript").GetComponent<LottoReaderScript>();
        historyData = LottoReader.data;
    }

    public void NumberCheck()
    {
        ArrayRankInit();
        if (DBManager.success)
        {
            Debug.Log("DB 연동 완료");
            historyData = DBManager.data;
            DBManager.success = false;
            state.text = "DB Connect";
        }

        int[] tmpNumArray;
        tmpNumArray = LottoManager.Instance.lottoArray;
        for (int i = 0; i < historyData.Count; i++)
        {
            for(int j = 0; j < tmpNumArray.Length; j++)
            {
                for (int k = 1; k <= 6; k++)
                {
                    if(tmpNumArray[j] == (int)historyData[i]["Num"+k])
                    {
                        count++;
                    }
                    if(tmpNumArray[j] == (int)historyData[i]["Bonus"])
                    {
                        bonusCheck = true;
                    }
                }
            }
            LottoRankCheck((int)historyData[i]["fdNum"], count, bonusCheck);
        }
        GuiDisplay();
    }

    void LottoRankCheck(int _fdNum, int _count, bool _bonus)
    {
        switch(count)
        {
            case 3:
                arrayRank5.Add(_fdNum);
                break;
            case 4:
                arrayRank4.Add(_fdNum);
                break;
            case 5:
                if (_bonus)
                {
                    arrayRank2.Add(_fdNum);
                }
                else
                {
                    arrayRank3.Add(_fdNum);
                }
                break;
            case 6:
                arrayRank1.Add(_fdNum);
                break;
                
        }
        count = 0;
        bonusCheck = false;
        
    }
    void GuiDisplay()
    {
        {
            string tmpHistory = "";

            if(arrayRank5.Count == 0)
                rank5CountText.text = "-";
            else
                rank5CountText.text = arrayRank5.Count.ToString() + "번 당첨 기록 확인";
            
            foreach (int histroy in arrayRank5)
            {
                tmpHistory = tmpHistory + histroy + "회. ";
            }
            if (tmpHistory == "") tmpHistory = "당첨 기록 없음";
            rank5HistoryText.text = tmpHistory;
        }
        {
            string tmpHistory = "";

            if (arrayRank4.Count == 0)
                rank4CountText.text = "-";
            else
                rank4CountText.text = arrayRank4.Count.ToString() + "번 당첨 기록 확인";

            foreach (int histroy in arrayRank4)
            {
                tmpHistory = tmpHistory + histroy + "회. ";
            }
            if (tmpHistory == "") tmpHistory = "당첨 기록 없음";
            rank4HistoryText.text = tmpHistory;
        }
        {
            string tmpHistory = "";

            if (arrayRank3.Count == 0)
                rank3CountText.text = "-";
            else
                rank3CountText.text = arrayRank3.Count.ToString() + "번 당첨 기록 확인";

            foreach (int histroy in arrayRank3)
            {
                tmpHistory = tmpHistory + histroy + "회. ";
            }
            if (tmpHistory == "") tmpHistory = "당첨 기록 없음";
            rank3HistoryText.text = tmpHistory;
        }
        {
            string tmpHistory = "";

            if (arrayRank2.Count == 0)
                rank2CountText.text = "-";
            else
                rank2CountText.text = arrayRank2.Count.ToString() + "번 당첨 기록 확인";

            foreach (int histroy in arrayRank2)
            {
                tmpHistory = tmpHistory + histroy + "회. ";
            }
            if (tmpHistory == "") tmpHistory = "당첨 기록 없음";
            rank2HistoryText.text = tmpHistory;
        }
        {
            string tmpHistory = "";

            if (arrayRank1.Count == 0)
                rank1CountText.text = "-";
            else
                rank1CountText.text = arrayRank1.Count.ToString() + "번 당첨 기록 확인";

            foreach (int histroy in arrayRank1)
            {
                tmpHistory = tmpHistory + histroy + "회. ";
            }
            if (tmpHistory == "") tmpHistory = "당첨 기록 없음";
            rank1HistoryText.text = tmpHistory;
        }
    }
    void ArrayRankInit()
    {
        arrayRank5.Clear();
        arrayRank4.Clear();
        arrayRank3.Clear();
        arrayRank2.Clear();
        arrayRank1.Clear();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
