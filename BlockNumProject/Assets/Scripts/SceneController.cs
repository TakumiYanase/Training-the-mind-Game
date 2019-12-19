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
        SceneManager.LoadScene("TitleScene");
    }

    // カウントダウンに遷移
    public void NextReady()
    {
        SceneManager.LoadScene("ReadyScene");
    }

    // ランキングに遷移
    public void NextRanking()
    {
        SceneManager.LoadScene("RankingScene");
    }

    // ステージセレクトに遷移
    public void NextStageSelect()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    // 任意ステージに遷移
    public void ChoiceStage(int num)
    {
        SceneManager.LoadScene("Stage" + (num) + "Scene");
    }

    // ランダムにステージ遷移
    public void RandomStage()
    {
        int randomNum = Random.Range(FIRST_STAGE, (LAST_STAGE + 1));

        SceneManager.LoadScene("Stage" + (randomNum) + "Scene");
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
