using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //물리 작업 수행 전 호출, 물리 효 과 코드를 적음
    void FixedUpdate()
    {
        //Input.GetAxis : 플레이어가 방향키를 눌렀는지 알 수 있다
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //움직이는 방향 결정
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
    }
}