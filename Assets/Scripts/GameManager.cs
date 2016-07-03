using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    public Transform player1;
    public Transform player2;
    public Text score1Text;
    public Text score2Text;

    private BoxCollider2D rightWall;
    private BoxCollider2D leftWall;
    private BoxCollider2D upWall;
    private BoxCollider2D downWall;
    private int score1 = 0;
    private int score2 = 0;

    void Awake()
    {
        _instance = this;
    }

    void Start ()
    {
        ResetWall();
        ResetPlayer();
	}
    //初始围墙
    void ResetWall()
    {
        float width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x ;   
        float height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;  //将camera的本地坐标转化为世界坐标，camera从左下角开始（0,0）
        //右墙
        rightWall = transform.Find("RightWall").GetComponent<BoxCollider2D>();
        rightWall.transform.position =  new Vector3(width + 0.5f , 0 ,0);
        rightWall.size = new Vector2(1, height*2);   //因为转化成世界坐标后(0,0)是camera中心，所以要*2
        //左墙
        leftWall = transform.Find("LeftWall").GetComponent<BoxCollider2D>();
        leftWall.transform.position = new Vector3(-width -0.5f, 0 , 0);
        leftWall.size = new Vector2(1, height*2);
        //上墙
        upWall = transform.Find("UpWall").GetComponent<BoxCollider2D>();
        upWall.transform.position = new Vector3(0, height+ 0.5f, 0);
        upWall.size = new Vector2(width*2,1);
        //下墙
        downWall = transform.Find("DownWall").GetComponent<BoxCollider2D>();
        downWall.transform.position = new Vector3(0, -height-0.5f, 0);
        downWall.size = new Vector2(width*2, 1);
    } 
    //放置Player
    void ResetPlayer()
    {
        Vector3 player1Position= Camera.main.ScreenToWorldPoint(new Vector3(100, Screen.height / 2, 0)); //player1放置在距离屏幕左侧100像素的位置
        player1Position.z = 0;
        player1.position = player1Position;
        Vector3 player2Position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, Screen.height / 2, 0));
        player2Position.z = 0;
        player2.position = player2Position;
    }
    public void ChangeScore(string wallName)
    {
        if (wallName == "RightWall")
        {
            score1++;
        }
        else if (wallName == "LeftWall")
        {
            score2++;
        }
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }
    public void Restart()
    {
        score1 = 0;
        score2 = 0;
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
        GameObject.Find("Ball").SendMessage("Reset"); 
    }
}
