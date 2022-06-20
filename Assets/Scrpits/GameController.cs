using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Canvas gameWin;
    public void PlayAgain()
    {
        SceneManager.LoadScene("JoinGame");
    }

    public void WinGame()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            gameWin.enabled = true;
        }
    }
}
