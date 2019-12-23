using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    const int FIRST_STAGE = 1;
    const int LAST_STAGE = 25;

    // タイトルに遷移
    public void NextTitle()
    {
        SceneManager.LoadScene(0);
    }

    // カウントダウンに遷移
    public void NextReady()
    {
        SceneManager.LoadScene(1);
    }

    // ランキングに遷移
    public void NextRanking()
    {
        SceneManager.LoadScene(2);
    }

    // ステージセレクトに遷移
    public void NextStageSelect()
    {
        SceneManager.LoadScene(3);
    }

    // 任意ステージに遷移
    public void ChoiceStage(int num)
    {
        SceneManager.LoadScene(num + 4);
    }

    // ランダムにステージ遷移
    public void RandomStage()
    {
        int randomNum = Random.Range(FIRST_STAGE, (LAST_STAGE + 1));

        SceneManager.LoadScene(randomNum + 4);
    }

    public void ExitGame()
    {
        Quit();
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}
