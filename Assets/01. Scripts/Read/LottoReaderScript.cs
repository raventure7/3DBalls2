using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LottoReaderScript : MonoBehaviour {

    public List<Dictionary<string, object>> data;
    int count = 0;

    bool bonusCheck = false;
    int[] arr = new int[] { 8, 10, 15, 30, 41, 42 };


    private void Awake()
    {
        data = CSVReader.Read("csv/lotto");
    }
    // Use this for initialization
    void Start () {
        //Debug.Log(data.Count);
        /*
        for (int i = 0; i < 806; i++)
        {
            for(int j = 0; j < arr.Length; j++)
            {
                for (int k = 1; k <= 6; k++)
                {
                    if (arr[j] == (int)data[i]["Num" + k])
                    {
                        count++;
                    }
                    if (arr[j] == (int)data[i]["Bonus"])
                    {
                        //Debug.Log((int)data[i]["fdNum"] + "]보너스 맞음" + arr[j]);
                        bonusCheck = true;
                    }

                }
            }
            //LottoRankCheck((int)data[i]["fdNum"], count, bonusCheck);
            //count = 0;
            //bonusCheck = false;
        }
        Debug.Log("종료");
        */
	}
    /*
	void LottoRankCheck(int _fdNum, int _count, bool _bonus)
    {
        //Debug.Log("[" + _fdNum+ "]" + "[" + _count + "]" + "[" + _bonus + "]");
        switch(count)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                Debug.Log("[" + _fdNum + "] 5등 :" + _count + "개가 맞음");
                break;
            case 4:
                Debug.Log("[" + _fdNum + "] 4등 :" + _count + "개가 맞음");
                break;
            case 5:
                if(_bonus)
                {
                    Debug.Log("[" + _fdNum + "] 2등 :" + _count + "개가 맞음 + (보너스)");
                    
                }
                else
                {
                    Debug.Log("[" + _fdNum + "] 3등 :" + _count + "개가 맞음");
                }
                
                break;
            case 6:
                Debug.Log("[" + _fdNum + "] 1등 :" + _count + "개가 맞음");
                break;
        }
        count = 0;
        bonusCheck = false;
    }
    */
    // Update is called once per frame
    void Update () {
		
	}
}
