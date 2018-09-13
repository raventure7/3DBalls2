using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour {
    private void Awake()
    {
        //Screen.SetResolution(720, 1280, false);
        //Screen.SetResolution(450, 800, false);
        //Screen.SetResolution(1280, 1280, false);
        //Screen.SetResolution(Screen.width, (Screen.width * 16) / 10, true);
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
    }
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
