using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float speed;
    private float jump;
    private Rigidbody rigidbody;
    private Vector3 movement;

    public bool isSpeedClicked;
    public bool isJumpedClicked;
    public int count;
    public Text clickCountText;

	// Use this for initialization
	void Start () {
        speed = 1f;
        jump = 7.0f;
        rigidbody = GetComponent<Rigidbody>();

        count = 0;
        updateClickCountText();
        isSpeedClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        //투명한 버튼이 클릭이 되었을 시
        if (isSpeedClicked)
        {
            speed += 0.7f;

            count++;
            updateClickCountText();
            isSpeedClicked = false;
        }
	}

    void updateClickCountText()
    {
        clickCountText.text = "Click Count : " + count.ToString();
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run()
    {
        movement.Set(speed, 0, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (!isJumpedClicked)
            return;

        rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
        isJumpedClicked = false;
    }
}