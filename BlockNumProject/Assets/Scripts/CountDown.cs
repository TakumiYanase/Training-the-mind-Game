using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Common;

[RequireComponent(typeof(Text))]

public class CountDown : MonoBehaviour
{
    [Serializable]
    public struct RankingData
    {
        public int first;
        public int second;
        public int third;
        public int newScore;
    }

    [SerializeField]
    private Text m_countDownText = null;
    [SerializeField]
    private Image m_countDownImage = null;

    [SerializeField, Range(Define.COUNT_LIMITED_TIME_MIN, Define.COUNT_LIMITED_TIME_MAX), HeaderAttribute("Limited Time")]
    private float m_countTime = Define.COUNT_TIME_INIT;

    private int m_seconds = Define.COUNT_TIME_MAX;
    private int m_score = 0;
    private int[] m_ranking = new int[Define.RANKING_LIST_END];

    public void Awake()
    {
        m_countDownText = m_countDownText.GetComponent<Text>();

        // フォルダからロード
        var info = new FileInfo(Application.dataPath + Define.SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<RankingData>(json);

        m_ranking[0] = data.first;
        m_ranking[1] = data.second;
        m_ranking[2] = data.third;
    }

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
            RankingCheck(m_ranking[0], m_ranking[1], m_ranking[2], m_score);
            m_seconds = 0;
            m_countDownImage.gameObject.SetActive(false);
            m_countDownText.gameObject.SetActive(false);
            NextResult();
            Destroy(this.gameObject);
        }
    }

    public void RankingCheck(int rankingFirst, int rankingSecond, int rankingThird, int score)
    {
        var data = new RankingData();

        data.first = rankingFirst;
        data.second = rankingSecond;
        data.third = rankingThird;
        data.newScore = score;

        if (rankingFirst <= score)
        {
            data.third = data.second;
            data.second = data.first;
            data.first = score;
        }
        if (rankingSecond <= score && rankingFirst > score)
        {
            data.third = data.second;
            data.second = score;
        }
        if (rankingThird <= score && rankingSecond > score)
        {
            data.third = score;
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

    public void AddScore()
    {
        m_score++;
    }

    public void NextResult()
    {
        SceneManager.LoadScene(Define.SCENE_RESULT);
    }
}
