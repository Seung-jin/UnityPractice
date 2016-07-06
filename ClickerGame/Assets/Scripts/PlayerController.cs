using UnityEngine;
using UnityEngine.UI;
using System.Collections;

static class defineData
{
    public const int MaximumJump = 2;   //연속 점프 가능 횟수
    public const float BasicSpeed = 2.0f; //player 구체의 기본 스피드
    public const float JumpForce = 8.0f;    //점프 시 위로 가해지는 힘
}

public class PlayerController : MonoBehaviour {
    private float totalSpeed;   //player 구체의 총 스피드
    private float addSpeed;     //player 구체에 더해지는 스피드
    private bool checkRun;      //player가 뛰고 있는 상태인지 체크
    private Rigidbody rigidbody;
    private Vector3 movement;
    private GameObject ground;
    private Animator playerAnimator;

    public bool isSpeedClicked;
    public bool isJumpedClicked;
    public int jumpCount;
    public int clickCount;
    public int coinCount;
    public Text clickCountText;
    public Text clickCoinText;

	// Use this for initialization
	void Start () {
        totalSpeed = 0.0f;
        addSpeed = 0.0f;
        checkRun = true;
        rigidbody = GetComponent<Rigidbody>();
        ground = GameObject.FindGameObjectWithTag("Ground");
        playerAnimator = GetComponent<Animator>();

        jumpCount = 0;
        clickCount = 0;
        coinCount = 0;
        updateClickCountText();
        isSpeedClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
        //투명한 버튼이 클릭이 되었을 시
        if (isSpeedClicked)
        {
            addSpeed += 1.0f;
            Invoke("MinusAddSpeed", 3);

            clickCount++;
            updateClickCountText();
            isSpeedClicked = false;
        }
        totalSpeed = defineData.BasicSpeed + addSpeed;

        //코인 갯수 업데이트
        clickCoinText.text = "Coin : " + coinCount.ToString();

        UpdateAnimator();
	}
    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void LateUpdate()
    {
        //땅에서 떨어지면 엔딩
        if (this.transform.position.y < -1)
        {
            Application.LoadLevel("GameOverScene");
        }
    }

    //클릭 갯수 업데이트
    void updateClickCountText()
    {
        clickCountText.text = "Click Count : " + clickCount.ToString();
    }


    //앞으로 움직이는 함수
    void Run()
    {
        movement.Set(totalSpeed, 0, 0);
        movement = movement.normalized * totalSpeed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }

    //점프 함수
    void Jump()
    {
        if (!isJumpedClicked)
            return;

        checkRun = false;

        //연속 점프는 2번까지만 가능
        if (jumpCount <= defineData.MaximumJump)
        {
            rigidbody.AddForce(Vector3.up * defineData.JumpForce, ForceMode.Impulse);
            isJumpedClicked = false;
        }
        else if (jumpCount > defineData.MaximumJump)
        {
            isJumpedClicked = false;
        }
    }

    //n초가 지난 후에 jumpCount를 초기화 해줌
    void JumpCountReset()
    {
        jumpCount = 0;
    }

    //스피드가 증가한 후 1초마다 addSpeed의 값을 빼줌
    void MinusAddSpeed()
    {
        if (addSpeed > 0.0f)
        {
            addSpeed -= 1.0f;
            if (addSpeed < 0.0f)
                addSpeed = 0.0f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //바닥에 부딪혔을 때 점프 카운트 설정
        if (other.gameObject == GameObject.FindGameObjectWithTag("Ground"))
        {
            checkRun = true;
            if (jumpCount < defineData.MaximumJump)
            {
                JumpCountReset();
            }
            else if (jumpCount >= defineData.MaximumJump)
            {
                jumpCount = 1;
                Invoke("JumpCountReset", 2);
            }
        }
    }

    void UpdateAnimator()
    {
        print("checkRun : " + checkRun);
        playerAnimator.SetBool("isRun", checkRun);
    }
}