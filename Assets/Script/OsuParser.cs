using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class OsuParser : MonoBehaviour
{
    public TextAsset osuFile; // Unity에 `.osu` 파일 추가
    public OsuMapData mapData;

    void Start()
    {
        mapData = ParseOsuFile(osuFile.text);
        Debug.Log($"Loaded osu! map: {mapData.title} by {mapData.artist}");
    }

    public OsuMapData ParseOsuFile(string fileContent)
    {
        OsuMapData map = new OsuMapData();
        map.hitObjects = new List<OsuHitObject>();

        string[] lines = fileContent.Split('\n');
        bool hitObjectSection = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[Metadata]"))
                continue;
            if (line.StartsWith("[HitObjects]"))
            {
                hitObjectSection = true;
                continue;
            }

            if (hitObjectSection)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3) continue;

                OsuHitObject hitObject = new OsuHitObject
                {
                    x = int.Parse(parts[0]),
                    y = int.Parse(parts[1]),
                    time = int.Parse(parts[2]),
                    type = int.Parse(parts[3])
                };

                map.hitObjects.Add(hitObject);
            }
        }

        return map;
    }
}