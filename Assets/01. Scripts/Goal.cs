using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public static Goal Instance = null;

    int[] lottoArrayTemp = new int[6];
    public int count;

    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        count = 1;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(count <= 6)
        {
            int number = other.gameObject.GetComponent<Ball>().number;
            Destroy(other.gameObject); // 해당 오브젝트 삭제.
            LottoManager.Instance.AddTopPanelBall(number);
            count++;
        }

    }


}
