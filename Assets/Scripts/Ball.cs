using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public int force = 100;
    public AudioSource audio;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GoBall();
	}
    void Update()
    {
        Vector2 velocity = rigidbody2D.velocity;
        if(velocity.x<9 && velocity.x > -9)
        {
            if (velocity.x > 0)
                velocity.x = 10;
            else if (velocity.x < 0)
                velocity.x = -10;
            rigidbody2D.velocity = velocity;
        }
    }
    //碰撞检测
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            //把Player y轴的速度赋给ball
            Vector2 velocity = rigidbody2D.velocity;    //取得小球当前速度
            velocity.y = velocity.y / 2 + col.rigidbody.velocity.y / 2;    //把player的y轴速度加给ball
            rigidbody2D.velocity = velocity;    //把更改后的velocity赋给ball
        }
        if (col.gameObject.name == "RightWall" || col.gameObject.name == "LeftWall")
        {
            GameManager.Instance.ChangeScore(col.gameObject.name);
        }
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        GoBall();
    }

    void GoBall()
    {
        int number = Random.Range(0, 2);
        if (number == 1)
        {
            rigidbody2D.AddForce(new Vector2(force, 10));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(-force, 10));
        }
    }
}
