using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TimeCount : MonoBehaviour
{
    [Serializable]
    public struct SaveData
    {
        public int first;
        public int second;
        public int third;

        public void Dump()
        {
            Debug.Log("First = " + first);
            Debug.Log("Second = " + second);
            Debug.Log("Third = " + third);
        }
    }

    // 保存するファイル
    const string SAVE_FILE_PATH = "Ranking.txt";

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (seconds <= 0)
        {
            // Assetsフォルダからロード
            var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
            var reader = new StreamReader(info.OpenRead());
            var json = reader.ReadToEnd();
            var data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("読み込みました");
        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        // Sキーでセーブ実行
    //        var data = new SaveData();
    //        data.first = 5;
    //        data.second = 7;
    //        data.third = 7;
    //        // JSONにシリアライズ
    //        var json = JsonUtility.ToJson(data);
    //        // Assetsフォルダに保存する
    //        var path = Application.dataPath + "/" + SAVE_FILE_PATH;
    //        var writer = new StreamWriter(path, false);
    //        writer.WriteLine(json);
    //        writer.Flush();
    //        writer.Close();

    //        Debug.Log("保存しました");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        // Lキーでロード実行
    //        // Assetsフォルダからロード
    //        var info = new FileInfo(Application.dataPath + "/" + SAVE_FILE_PATH);
    //        var reader = new StreamReader(info.OpenRead());
    //        var json = reader.ReadToEnd();
    //        var data = JsonUtility.FromJson<SaveData>(json);

    //        Debug.Log("読み込みました");
    //    }
    //}
}
