using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public float Flap = 10;
    public float Speed = 5;
    public Text Score;
    public Text HighScore;
    public Camera Camera;

    private int topScore=0;

	// Use this for initialization
	void Start ()
    {
        Reset();
	}

    private void Reset()
    {
        transform.position = new Vector3(0, 4, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(Speed, 0, 0);
    }

    void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<Rigidbody>().AddForce(0, Flap, 0);
            GetComponent<Animator>().SetTrigger("Fly");
            GetComponent<AudioSource>().Play();
        }

        int score = Mathf.FloorToInt(transform.position.x);
        if(score > topScore)
        {
            topScore = score;
        }

        Score.text = "Score: " + score;
        HighScore.text = "High Score: " + topScore;

        Camera.transform.position = new Vector3(transform.position.x, Camera.transform.position.y, Camera.transform.position.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
       Reset();
    }
}
