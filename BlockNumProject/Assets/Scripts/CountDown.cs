using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class CountDown : MonoBehaviour
{
    [Serializable]
    public struct RankingData
    {
        public int first;
        public int second;
        public int third;
    }

    [SerializeField]
    private Text m_countDownText;

    [SerializeField, Range(5.0f, 500.0f), HeaderAttribute("Limited Time")]
    private float m_countTime = 300.0f;

    private int m_seconds = 9999;

    private int m_score = 0;

    private int[] m_ranking = new int[3];

    // 保存するファイル
    const string SAVE_FILE_PATH = "Ranking.txt";

    void Start()
    {
        m_countDownText = m_countDownText.GetComponent<Text>();

        // フォルダからロード
        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<RankingData>(json);

        m_ranking[0] = data.first;
        m_ranking[1] = data.second;
        m_ranking[2] = data.third;
    }

    void Update()
    {
        GameObject.Find("CountDown(Clone)").GetComponent<Canvas>().worldCamera = Camera.main;

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
        }
    }

    public void RankingCheck(int rankingFirst, int rankingSecond, int rankingThird, int score)
    {
        var data = new RankingData();

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
        var path = Application.dataPath + "/" + SAVE_FILE_PATH;
        var writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    public void AddScore()
    {
        m_score++;
    }
}
