using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public GameObject Img1;
    public GameObject Img2;
    public GameObject Img3;
    public GameObject Img4;
    public GameObject Img5;
    public GameObject Img6;


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
    }
    public void Load()
    {
        var saveData = PlayerPrefs.GetString("SaveList");
        Debug.Log(saveData);
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
        int tmpHead = LottoSaveList.Count + 1;
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

	
	// Update is called once per frame
	void Update () {
		
	}
}
