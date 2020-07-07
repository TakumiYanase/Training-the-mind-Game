//==============================================================================================
/// File Name	: CountDown
/// Summary		: カウントダウン遷移・スコア保存
/// 
/// Author      : Takumi Yanase (柳瀬 拓臣)
//==============================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common;
//==============================================================================================
[RequireComponent(typeof(Text))]

public class CountDown : MonoBehaviour
{
    //------------------------------------------------------------------------------------------
    // member variable
    //------------------------------------------------------------------------------------------
    [SerializeField]
    private Text m_countDownText = null;
    [SerializeField]
    private Image m_countDownImage = null;

    [SerializeField, Range(Define.COUNT_LIMITED_TIME_MIN, Define.COUNT_LIMITED_TIME_MAX), HeaderAttribute("Limited Time")]
    private float m_countTime = Define.COUNT_TIME_INIT;

    private int m_seconds = Define.COUNT_TIME_MAX;
    private int m_score = 0;
    private int[] m_scoreData = new int[Define.RANKING_LIST_END];
    private int[] m_year = new int[Define.RANKING_LIST_END];
    private int[] m_month = new int[Define.RANKING_LIST_END];
    private int[] m_day = new int[Define.RANKING_LIST_END];

    //------------------------------------------------------------------------------------------
    // Awake
    //------------------------------------------------------------------------------------------
    public void Awake()
    {
        // フォルダからロード
        var info = new FileInfo(Application.dataPath + Define.SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<ScoreUtility.RankingData>(json);

        m_scoreData[0] = data.first;
        m_scoreData[1] = data.second;
        m_scoreData[2] = data.third;

        m_year[0] = data.yearFirst;
        m_year[1] = data.yearSecond;
        m_year[2] = data.yearThird;

        m_month[0] = data.monthFirst;
        m_month[1] = data.monthSecond;
        m_month[2] = data.monthThird;

        m_day[0] = data.dayFirst;
        m_day[1] = data.daySecond;
        m_day[2] = data.dayThird;
    }

    //------------------------------------------------------------------------------------------
    // Update
    //------------------------------------------------------------------------------------------
    public void Update()
    {
        GameObject.Find(Define.COUNT_DOWN_PREFAB).GetComponent<Canvas>().worldCamera = Camera.main;

        // カウントダウン
        if (m_countTime > 0)
        {
            m_countTime -= Time.deltaTime;
            m_seconds = (int)m_countTime;
            m_countDownText.text = m_seconds.ToString();
        }

        if (m_seconds <= 0)
        {
            RankingCheck();
            m_seconds = 0;
            m_countDownImage.gameObject.SetActive(false);
            m_countDownText.gameObject.SetActive(false);
            NextResult();
            Destroy(this.gameObject);
        }
    }

    //------------------------------------------------------------------------------------------
    // RankingCheck
    //------------------------------------------------------------------------------------------
    public void RankingCheck()
    {
        var data = new ScoreUtility.RankingData();
        DateTime dateNow = System.DateTime.Now;

        data.first = m_scoreData[0];
        data.second = m_scoreData[1];
        data.third = m_scoreData[2];
        data.newScore = m_score;

        data.yearFirst = m_year[0];
        data.yearSecond = m_year[1];
        data.yearThird = m_year[2];

        data.monthFirst = m_month[0];
        data.monthSecond = m_month[1];
        data.monthThird = m_month[2];

        data.dayFirst = m_day[0];
        data.daySecond = m_day[1];
        data.dayThird = m_day[2];

        if (data.first <= m_score)
        {
            data.third = data.second;
            data.second = data.first;
            data.first = m_score;

            data.yearThird = data.yearSecond;
            data.yearSecond = data.yearFirst;
            data.yearFirst = dateNow.Year;

            data.monthThird = data.monthSecond;
            data.monthSecond = data.monthFirst;
            data.monthFirst = dateNow.Month;

            data.dayThird = data.daySecond;
            data.daySecond = data.dayFirst;
            data.dayFirst = dateNow.Day;
        }
        if (data.second <= m_score && data.first > m_score)
        {
            data.third = data.second;
            data.second = m_score;

            data.yearThird = data.yearSecond;
            data.yearSecond = dateNow.Year;

            data.monthThird = data.monthSecond;
            data.monthSecond = dateNow.Month;

            data.dayThird = data.daySecond;
            data.daySecond = dateNow.Day;
        }
        if (data.third <= m_score && data.second > m_score)
        {
            data.third = m_score;

            data.yearThird = dateNow.Year;

            data.monthThird = dateNow.Month;

            data.dayThird = dateNow.Day;
        }

        // JSONにシリアライズ
        var json = JsonUtility.ToJson(data);
        // Assetsフォルダに保存する
        var path = Application.dataPath + Define.SAVE_FILE_PATH;
        var writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    //------------------------------------------------------------------------------------------
    // AddScore
    //------------------------------------------------------------------------------------------
    public void AddScore()
    {
        m_score++;
    }

    //------------------------------------------------------------------------------------------
    // NextResult
    //------------------------------------------------------------------------------------------
    public void NextResult()
    {
        SceneManager.LoadScene(Define.SCENE_RESULT);
    }
}
