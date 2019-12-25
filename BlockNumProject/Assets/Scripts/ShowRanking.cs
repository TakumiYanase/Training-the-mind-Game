using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

using Common;

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
    private Text[] m_rankingText = new Text[Define.RANKING_LIST_END];

    private int[] m_ranking = new int[Define.RANKING_LIST_END];

    public void Awake()
    {
        // フォルダからロード
        var info = new FileInfo(Application.dataPath + Define.SAVE_FILE_PATH);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var data = JsonUtility.FromJson<RankingData>(json);

        m_ranking[0] = data.first;
        m_ranking[1] = data.second;
        m_ranking[2] = data.third;

        for (int i = 0; i < Define.RANKING_LIST_END; i++)
        {
            m_rankingText[i].text = m_ranking[i].ToString();
        }
    }
}
