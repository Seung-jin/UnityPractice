using UnityEngine;
using UnityEngine.UI;
using System.Collections;

static class StaticNumber
{
    public const int MaxPickUp = 12;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
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

    //플레이어가 오브젝트와 충돌했을 때
    void OnTriggerEnter(Collider other)
    {
        //CompareTag : 태그를 확인
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //게임 오브젝트 활성화 여부
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= StaticNumber.MaxPickUp)
        {
            winText.text = "You Win!!";
        }
    }
}