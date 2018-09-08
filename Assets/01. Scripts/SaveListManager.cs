using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveListManager : MonoBehaviour {
    public static SaveListManager Instance = null;

    public GameObject saveItem;

    int saveCount = 0;
    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start () {
        //SaveLoad();
    }

    void OnEnable()
    {
        UIClear();
        SaveLoad();
    }
    void OnDisable()
    {

    }
    public void SaveLoad()
    {
        SaveManager.Instance.Load(); // 세이브 로드
        saveCount = SaveManager.Instance.LottoSaveList.Count;
        Debug.Log("세이브 카운터 개수 : " + saveCount);
        int[] saveLottoArray = new int[6];
        if (saveCount >= 1)
        {
            for (int i = saveCount; i > 0; i--)
            {

                int head = SaveManager.Instance.LottoSaveList[i - 1].head;
                saveLottoArray[0] = SaveManager.Instance.LottoSaveList[i - 1].num1;
                saveLottoArray[1] = SaveManager.Instance.LottoSaveList[i - 1].num2;
                saveLottoArray[2] = SaveManager.Instance.LottoSaveList[i - 1].num3;
                saveLottoArray[3] = SaveManager.Instance.LottoSaveList[i - 1].num4;
                saveLottoArray[4] = SaveManager.Instance.LottoSaveList[i - 1].num5;
                saveLottoArray[5] = SaveManager.Instance.LottoSaveList[i - 1].num6;

                GameObject _saveItem = Instantiate(saveItem) as GameObject;
                for (int j = 0; j<= saveLottoArray.Length-1; j++)
                {
                    
                    _saveItem.transform.Find("Panel/Img_"+ (j + 1)).GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("Prefabs/2D/ball_" + saveLottoArray[j]) as Sprite;
                    

                }

                //_saveItem.transform.Find("Panel/Img_1").GetComponent<Image>().sprite =
                 //Resources.Load<Sprite>("Prefabs/2D/ball_1") as Sprite;


                _saveItem.transform.Find("Panel/Button").GetComponent<Button>().onClick.AddListener(delegate
                {
                    SaveRemove(head);
                    //SaveManager.Instance.DeleteData(head);
                });

                _saveItem.transform.name = "SaveNumbers";
                _saveItem.transform.SetParent(GameObject.Find("Canvas/UI_POPUP_Savelist/Div1/Scroll View/Viewport/Content").transform);
                _saveItem.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

    }
    public void SaveClear()
    {
        UIClear();

        SaveManager.Instance.Clear();

        SaveLoad();
    }

    public void SaveRemove(int num)
    {
        UIClear();
        SaveManager.Instance.DeleteData(num);
        SaveLoad();
    }

    public void UIClear()
    {

        Transform[] childList = GameObject.Find("Canvas/UI_POPUP_Savelist/Div1/Scroll View/Viewport/Content").GetComponentsInChildren<Transform>(true);
        Debug.Log("자식 개수 :" + childList.Length);
        if (childList != null)
        {
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i].name == "SaveNumbers")
                    Destroy(childList[i].gameObject);
            }
        }


    }
    

    // Update is called once per frame
    void Update () {
		
	}
}
