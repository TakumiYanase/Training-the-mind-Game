using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class ShowRanking : MonoBehaviour
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
    private Text[] m_rankingText = new Text[3];

    private int[] m_ranking = new int[3];

    const string SAVE_FILE_PATH = "Ranking.txt";

    void Start()
    {
        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<RankingData>(json);

        m_ranking[0] = data.first;
        m_ranking[1] = data.second;
        m_ranking[2] = data.third;

        m_rankingText[0].text = m_ranking[0].ToString();
        m_rankingText[1].text = m_ranking[1].ToString();
        m_rankingText[2].text = m_ranking[2].ToString();
    }
}
