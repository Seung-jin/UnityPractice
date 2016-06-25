using UnityEngine;
using System.Collections;

public class BoardGameManager : MonoBehaviour {
    Rect rectangle_0 = new Rect(50, 300, 100, 30);
    Rect rectangle_1 = new Rect(200, 300, 100, 30);
    Rect rectangle_2 = new Rect(350, 300, 100, 30);
    Rect rectangle_3 = new Rect(500, 300, 100, 30);

    public GameObject Barrel_0;
    public GameObject Barrel_1;
    public GameObject Barrel_2;
    public GameObject Barrel_3;


    // Use this for initialization
    void Start () {
        int randomNum = Random.Range(0, 4);
        
        if(randomNum == 0)
            Barrel_0.GetComponent<BarrelScript>().IsFail = true;
        else if(randomNum == 1)
            Barrel_1.GetComponent<BarrelScript>().IsFail = true;
        else if(randomNum == 2)
            Barrel_2.GetComponent<BarrelScript>().IsFail = true;
        else if(randomNum == 3)
            Barrel_3.GetComponent<BarrelScript>().IsFail = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if(GUI.Button(rectangle_0, "button0"))
        {
            Barrel_0.GetComponent<BarrelScript>().IsClick = true;
            print("Clicked Button0");
        }

        if(GUI.Button(rectangle_1, "button1"))
        {
            Barrel_1.GetComponent<BarrelScript>().IsClick = true;
            print("Clicked Button1");
        }

        if(GUI.Button(rectangle_2, "button2"))
        {
            Barrel_2.GetComponent<BarrelScript>().IsClick = true;
            print("Clicked Button2");
        }

        if(GUI.Button(rectangle_3, "button3"))
        {
            Barrel_3.GetComponent<BarrelScript>().IsClick = true;
            print("Clicked Button3");
        }
    }
}
