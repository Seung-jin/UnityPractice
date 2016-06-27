using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool isClicked;

    public int count;
    public Text clickCountText;

	// Use this for initialization
	void Start () {
        count = 0;
        setClickCountText();
        isClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isClicked)
        {
            count++;
            setClickCountText();
            isClicked = false;
        }
	}

    void setClickCountText()
    {
        clickCountText.text = "Click Count : " + count.ToString();
    }
}