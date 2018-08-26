using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExceptManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // 초기화
    public void ExceptInit()
    {
        Transform[] childList = GameObject.Find("ExButtons").transform.GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    childList[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    childList[i].GetComponent<BallButton>().state = true;
                }
                //    Destroy(childList[i].gameObject);
            }
        }
        BallManager.Instance.DeleteBalls();
        BallManager.Instance.CreateBall();
    }

    // 랜덤 뽑기
    public void RndBalls()
    {
        Debug.Log("랜덤 제외수");
        ExceptInit();
        StartCoroutine("RndBallsDelay");
    }
    IEnumerator RndBallsDelay()
    {
        yield return new WaitForSeconds(0.2f);
        BallManager.Instance.RndBalls();
    }
}
