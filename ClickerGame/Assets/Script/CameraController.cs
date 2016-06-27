using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 500, 700), "", GUIStyle.none)) {
            player.GetComponent<PlayerController>().isClicked = true;
        }
    }
}