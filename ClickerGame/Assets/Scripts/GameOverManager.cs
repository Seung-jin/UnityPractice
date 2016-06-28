using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(530, 250, 150, 70), "Retry!!"))
        {
            Application.LoadLevel("MainScene");
        }
    }
}