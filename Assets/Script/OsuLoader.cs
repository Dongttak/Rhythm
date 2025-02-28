using System.IO;
using UnityEngine;

public class OsuLoader : MonoBehaviour
{
    public string extractedPath; // .osz 압축이 풀린 폴더 경로
    private OsuParser osuParser;

    void Start()
    {
        string[] osuFiles = Directory.GetFiles(extractedPath, "*.osu");
        if (osuFiles.Length > 0)
        {
            string osuFilePath = osuFiles[0];  // 첫 번째 .osu 파일 사용
            string osuContent = File.ReadAllText(osuFilePath);
            osuParser = new OsuParser();
            OsuMapData mapData = osuParser.ParseOsuFile(osuContent);
            Debug.Log($"Loaded osu! map: {mapData.title} by {mapData.artist}");
        }
        else
        {
            Debug.LogError("No .osu files found!");
        }
    }
}