using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallButton : MonoBehaviour {
    public int number;
    public bool state;
    Button btn;
    Image btnImage;
    // Use this for initialization
    void Start () {
        state = true;
        btn = gameObject.GetComponent<Button>();
        btnImage = gameObject.GetComponent<Image>();
        btn.onClick.AddListener(BtnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void BtnClick()
    {
        if(state == true)
        {
            btnImage.color = new Color32(116, 116, 116, 178);
            BallManager.Instance.DestroyBall(number);
            state = false;
        }
        else
        {
            btnImage.color = new Color32(255,255,255,255);
            BallManager.Instance.AddBall(number);
            state = true;
        }
    }

}
