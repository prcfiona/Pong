using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public KeyCode upKey;
    public KeyCode downKey;
    public float speed=15;

    private Rigidbody2D rigidbody2D;
    private AudioSource audio;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

	void Update ()
    {
        if (Input.GetKey(upKey))
        {
            rigidbody2D.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(downKey))
        {
            rigidbody2D.velocity = new Vector2(0, -speed);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0,0);
        }

	}

    void OnCollisionEnter2D()
    {
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.Play();
    }
}
