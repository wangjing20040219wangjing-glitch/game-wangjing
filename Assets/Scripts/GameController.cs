using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index); //加载场景
    }

    public void QuitGame()
    {
        Application.Quit(); // 退出游戏
    }

}
