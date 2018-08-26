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
}
