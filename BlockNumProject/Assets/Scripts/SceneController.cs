using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Common;

public class SceneController : MonoBehaviour
{
    // タイトルに遷移
    public void NextTitle()
    {
        SceneManager.LoadScene(Define.SCENE_TITLE);
    }

    // カウントダウンに遷移
    public void NextReady()
    {
        SceneManager.LoadScene(Define.SCENE_READY);
    }

    // ランキングに遷移
    public void NextRanking()
    {
        SceneManager.LoadScene(Define.SCENE_RANKING);
    }

    // ステージセレクトに遷移
    public void NextStageSelect()
    {
        SceneManager.LoadScene(Define.SCENE_STAGESELECT);
    }

    // 任意ステージに遷移
    public void ChoiceStage(int num)
    {
        SceneManager.LoadScene(num + Define.STAGE_BEGIN);
    }

    // ランダムにステージ遷移
    public void RandomStage()
    {
        int randomNum = Random.Range(Define.STAGE_BEGIN, (Define.STAGE_END_RAND_ONLY));
        SceneManager.LoadScene(randomNum);
    }

    // ゲームを終了
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
