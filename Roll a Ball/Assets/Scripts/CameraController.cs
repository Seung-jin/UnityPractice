using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        //카메라와 플레이어 사이의 거리
        offset = transform.position - player.transform.position;
	}
	
    //카메라 위치 업데이트는 Update()가 아닌 LateUpdate()로
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
