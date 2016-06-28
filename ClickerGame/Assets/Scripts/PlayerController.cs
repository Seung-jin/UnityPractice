﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

static class defineData
{
    public const int MaximumJump = 2;   //연속 점프 가능 횟수
    public const float BasicSpeed = 2.0f; //player 구체의 기본 스피드
}

public class PlayerController : MonoBehaviour {
    private float totalSpeed;   //player 구체의 총 스피드
    private float addSpeed;     //player 구체에 더해지는 스피드
    private float jump;
    private Rigidbody rigidbody;
    private Vector3 movement;

    public bool isSpeedClicked;
    public bool isJumpedClicked;
    public int jumpCount;
    public int count;
    public Text clickCountText;

	// Use this for initialization
	void Start () {
        totalSpeed = 0.0f;
        addSpeed = 0.0f;
        jump = 7.0f;
        jumpCount = 0;
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
            addSpeed += 0.7f;
            totalSpeed = defineData.BasicSpeed + addSpeed;
            Invoke("MinusAddSpeed", 1);

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

        //연속 점프는 2번까지만 가능
        if (jumpCount <= defineData.MaximumJump)
        {
            rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isJumpedClicked = false;
        }
        else if (jumpCount > defineData.MaximumJump)
        {
            isJumpedClicked = false;
            Invoke("JumpCountReset", 4);
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
        print("In Minus Add Speed??");
        if (addSpeed > 0.0f)
        {
            addSpeed -= 1.0f;
            if (addSpeed < 0.0f)
                addSpeed = 0.0f;
        }
    }
}