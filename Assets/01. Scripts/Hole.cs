﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hole : MonoBehaviour {
    public static Hole Instance = null;

    public Slider sdSpeedSetting;

    public bool start;
    public bool hook;
    public int count;
    Collider tempOther;

    float speed = 0.15f;
    float nextDelayTime = 1.0f;
    float _nextDelayTime;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Use this for initialization
    void Start () {
        _nextDelayTime = nextDelayTime;
        start = false;
        hook = false;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(start == true && count >= 1)
        {
            //tempOther.transform.rotation = Quaternion.identity;
            //tempOther.transform.Translate(Vector3.up * speed * Time.deltaTime);
            //tempOther.transform.Rotate(0, 5, 0);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(start == true)
        {
            if (hook == false && count <= 5)
            {
                //Debug.Log(other.gameObject.name);
                LottoManager.Instance.lottoArray[count] = other.gameObject.GetComponent<Ball>().number; //배열에 추첨 번호 넣기.
                //LottoManager.Instance.lottoCount++;
                //other.gameObject.GetComponent<SphereCollider>().enabled = false;

                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                other.transform.Rotate(Vector3.zero);
                other.transform.position = gameObject.transform.position;
                other.transform.rotation = Quaternion.identity;
                tempOther = other;
                hook = true;
                other.gameObject.GetComponent<Ball>().hooked = true;
                count++;
                StartCoroutine("NextDelay");
            }
        }

    }
    // 로또 번호 뽑기 추첨 딜레이
    IEnumerator NextDelay()
    {
        yield return new WaitForSeconds(_nextDelayTime);
        hook = false;
    }
    public void SpeedSetting()
    {

        //float _speed = speed / 50.0f;
        //float _nextDelayTime = nextDelayTime / 40.0f;
        //speed = _speed * sdSpeedSetting.value * 100;
        _nextDelayTime = nextDelayTime * sdSpeedSetting.value;
        
        Debug.Log(sdSpeedSetting.value);
    }
}
