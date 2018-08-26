using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public static BallManager Instance = null;
    public GameObject[] ball;

    Transform balls;
    // Use this for initialization
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        balls = GameObject.Find("Balls").transform;
    }
    private void Start()
    {
        
    }
    // 공 생성
    public void CreateBall()
    {
        int i = 0;
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        LottoManager.Instance.UINumberCount = 0;
        for (i = 1; i <= ball.Length; i++)
        {
            x = Random.Range(-0.075f, 0.075f);
            y = Random.Range(0.8f, 0.9f);
            z = Random.Range(-0.077f, 0.077f);
            GameObject pBall = Resources.Load("Prefabs/ball" + i) as GameObject;
            Instantiate(pBall, new Vector3(x, y, z), Quaternion.identity).transform.SetParent(balls);
        }
    }
    // 재시작 시 리턴 처리.
    public void ReturnBall()
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        for (int i = LottoManager.Instance.lottoArray.Length; i > 0; i--)
        {
            x = Random.Range(-0.075f, 0.075f);
            y = Random.Range(0.8f, 0.9f);
            z = Random.Range(-0.077f, 0.077f);
            GameObject pBall = Resources.Load("Prefabs/ball" + LottoManager.Instance.lottoArray[i - 1]) as GameObject;
            Instantiate(pBall, new Vector3(x, y, z), Quaternion.identity).transform.SetParent(balls);
        }
    }
    // 공 모두 삭제
    public void DeleteBalls()
    {
        Transform[] childList = GameObject.Find("Balls").transform.GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    Destroy(childList[i].gameObject);
                }
                
            }
        }
    }

    public void AddBall(int num)
    {
        Debug.Log("공 추가");
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        x = Random.Range(-0.075f, 0.075f);
        y = Random.Range(0.8f, 0.9f);
        z = Random.Range(-0.077f, 0.077f);
        GameObject pBall = Resources.Load("Prefabs/ball" + num) as GameObject;
        Instantiate(pBall, new Vector3(x, y, z), Quaternion.identity).transform.SetParent(balls);
    }
    public void DestroyBall(int num)
    {
        Debug.Log("공 삭제");
        GameObject ball = balls.Find("ball"+num+"(Clone)").gameObject;
        Destroy(ball);
    }

    public void BallInit()
    {

    }
    
}
