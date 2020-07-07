//==============================================================================================
/// File Name	: SceneController
/// Summary		: シーン管理
/// 
/// Author      : Takumi Yanase (柳瀬 拓臣)
//==============================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;
//==============================================================================================

public class SceneController : MonoBehaviour
{
    //------------------------------------------------------------------------------------------
    // NextTitle
    //------------------------------------------------------------------------------------------
    public void NextTitle()
    {
        SceneManager.LoadScene(Define.SCENE_TITLE);
    }

    //------------------------------------------------------------------------------------------
    // NextReady
    //------------------------------------------------------------------------------------------
    public void NextReady()
    {
        SceneManager.LoadScene(Define.SCENE_READY);
    }

    //------------------------------------------------------------------------------------------
    // NextRanking
    //------------------------------------------------------------------------------------------
    public void NextRanking()
    {
        SceneManager.LoadScene(Define.SCENE_RANKING);
    }

    //------------------------------------------------------------------------------------------
    // NextStageSelect
    //------------------------------------------------------------------------------------------
    public void NextStageSelect()
    {
        SceneManager.LoadScene(Define.SCENE_STAGESELECT);
    }

    //------------------------------------------------------------------------------------------
    // ChoiceStage
    //------------------------------------------------------------------------------------------
    public void ChoiceStage(int num)
    {
        SceneManager.LoadScene(num + Define.STAGE_BEGIN);
    }

    //------------------------------------------------------------------------------------------
    // RandomStage
    //------------------------------------------------------------------------------------------
    public void RandomStage()
    {
        int randomNum = Random.Range(Define.STAGE_BEGIN, (Define.STAGE_END_RAND_ONLY));
        SceneManager.LoadScene(randomNum);
    }

    //------------------------------------------------------------------------------------------
    // ExitGame
    //------------------------------------------------------------------------------------------
    public void ExitGame()
    {
        Quit();
    }

    //------------------------------------------------------------------------------------------
    // Quit
    //------------------------------------------------------------------------------------------
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}
