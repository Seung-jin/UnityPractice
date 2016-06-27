using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float speed;

    public bool isClicked;
    public int count;
    public Text clickCountText;

	// Use this for initialization
	void Start () {
        speed = 0.001f;

        count = 0;
        setClickCountText();
        isClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        //투명한 버튼이 클릭이 되었을 시
        if (isClicked)
        {
            speed += 0.01f;

            count++;
            isClicked = false;
            setClickCountText();
        }

        gameObject.transform.Translate(speed, 0, 0);
	}

    void setClickCountText()
    {
        clickCountText.text = "Click Count : " + count.ToString();
    }
}