using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0) * 1);
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.GetComponent<PlayerController>().coinCount++;
            Destroy(this.gameObject);
        }
    }
}