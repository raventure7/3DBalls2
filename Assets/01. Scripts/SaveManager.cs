using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveManager : MonoBehaviour {
    public static SaveManager Instance = null;
    public int[] tmpLottoArray = new int[6];
    [Serializable]
    public class LottoSave
    {
        public int head;
        public int num1;
        public int num2;
        public int num3;
        public int num4;
        public int num5;
        public int num6;
    }
    public List<LottoSave> LottoSaveList = new List<LottoSave>();
    public GameObject puSave;
    public GameObject[] Img = new GameObject[6];

    int lastHead;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        puSave.SetActive(false);
        Load();
    }


    public void Save()
    {
        Debug.Log("SAVE");
        AddData();
        var binaryFormatter = new BinaryFormatter();
        var memoryStream    = new MemoryStream();
        // 바이트 배열로 저장
        binaryFormatter.Serialize(memoryStream, LottoSaveList);
        PlayerPrefs.SetString("SaveList", Convert.ToBase64String(memoryStream.GetBuffer()));
        Load();
        puSave.SetActive(true);
        for(int i = 0; i < Img.Length; i++)
        {
            Img[i].GetComponent<Image>().sprite =
                Resources.Load<Sprite>("Prefabs/2D/ball_" + tmpLottoArray[i]) as Sprite;
        }
    }
    public void Load()
    {
        var saveData = PlayerPrefs.GetString("SaveList");
        if(!string.IsNullOrEmpty(saveData))
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream(Convert.FromBase64String(saveData));

            //가져온 데이터를 다시 바이트 배열 변환
            //사용하기 위해 다시 리스트로 캐스팅
            LottoSaveList = (List<LottoSave>)binaryFormatter.Deserialize(memoryStream);
        }
        else
        {
            LottoSaveList = new List<LottoSave>();
        }
    }
    
    public void AddData()
    {
        
        
        foreach(var val in LottoSaveList)
        {
            lastHead = val.head;
        }
        int tmpHead = lastHead + 1;

        //정렬
        int k = 0;
        tmpLottoArray = LottoManager.Instance.lottoArray;
        foreach (int sort in tmpLottoArray.OrderBy(sorted => sorted))
        {
            tmpLottoArray[k++] = sort;
        }

        LottoSaveList.Add(new LottoSave
        {
            head = tmpHead,
            num1 = tmpLottoArray[0],
            num2 = tmpLottoArray[1],
            num3 = tmpLottoArray[2],
            num4 = tmpLottoArray[3],
            num5 = tmpLottoArray[4],
            num6 = tmpLottoArray[5]
        });
    }
    public void Close()
    {
        puSave.SetActive(false);
        LottoManager.Instance.SetState(0); //상태 NONE
    }

    public void DeleteData(int num)
    {
        Debug.Log(num);
        for(int i = 0; i<=LottoSaveList.Count-1; i++)
        {
            if (LottoSaveList[i].head == num)
                LottoSaveList.Remove(LottoSaveList[i]);
        }
        /*
        foreach(var val in LottoSaveList)
        {
            if(val.head == num)
            {
                LottoSaveList.Remove(val);
            }
        }
        */
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, LottoSaveList);
        PlayerPrefs.SetString("SaveList", Convert.ToBase64String(memoryStream.GetBuffer()));
    }

    public void Clear()
    {
        LottoSaveList.Clear();
        var binaryFormatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        // 바이트 배열로 저장
        binaryFormatter.Serialize(memoryStream, LottoSaveList);
        PlayerPrefs.SetString("SaveList", Convert.ToBase64String(memoryStream.GetBuffer()));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
