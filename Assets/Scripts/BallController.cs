using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float speed = 5f;  // 移动速度
    public Image panel;  // UI面板
    public Text endText;  // 结束文本
    public Text scoreText; // 分数文本

    private Rigidbody rb;  // 刚体组件
    private int score = 0; // 分数

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // 获取球体刚体组件
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  // 获取水平输入
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, speed);  // 更新球体速度

        if (transform.position.y <= -5)  // 如果球体位置低于-5
        {
            speed = 0;  // 停止移动
            panel.gameObject.SetActive(true);  // 显示面板
            endText.text = "Game Over";  // 显示失败文本
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")  // 如果碰撞物体标签为"Obstacle"
        {
            speed = 0;  // 停止移动
            panel.gameObject.SetActive(true);  // 显示面板
            endText.text = "Game Over";  // 显示失败文本
        }

        if (collision.gameObject.tag == "Goal")  // 如果碰撞物体标签为"Goal"
        {
            speed = 0;  // 停止移动
            panel.gameObject.SetActive(true);  // 显示面板
            endText.text = "You Win";  // 显示胜利文本
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") // 如果触碰到带有"Coin"标签的物体
        {
            score += 10; // 增加分数10
            scoreText.text = "分数：" + score; // 更新显示的分数文本
            Destroy(other.gameObject); // 销毁碰撞的物体
        }
    }

}

