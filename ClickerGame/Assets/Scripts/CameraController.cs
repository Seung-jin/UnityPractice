using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {
    private Vector3 offset;

    public GameObject player;
    
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnGUI()
    {
        if(GUI.Button(new Rect(0, 0, 500, 700), "", GUIStyle.none)) {
            player.GetComponent<PlayerController>().isSpeedClicked = true;
        }

        if (GUI.Button(new Rect(1150, 400, 50, 50), "Jump"))
        {
            if (player.GetComponent<PlayerController>().jumpCount < 3)
            {
                player.GetComponent<PlayerController>().isJumpedClicked = true;
                player.GetComponent<PlayerController>().jumpCount++;
            }
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}