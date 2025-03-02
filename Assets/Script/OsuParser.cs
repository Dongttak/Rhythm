using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OsuHitObject
{
    public float x;     // 노트의 X 위치
    public float y;     // 노트의 Y 위치
    public float time;  // 노트가 떨어지는 타이밍 (ms)

    public OsuHitObject(float x, float y, float time)
    {
        this.x = x;
        this.y = y;
        this.time = time;
    }
}

public class OsuParser
{
    public static List<OsuHitObject> ParseOsuFile(string osuFilePath)
    {
        List<OsuHitObject> hitObjects = new List<OsuHitObject>();

        if (!File.Exists(osuFilePath))
        {
            Debug.LogError("파일을 찾을 수 없습니다: " + osuFilePath);
            return hitObjects;
        }

        string[] lines = File.ReadAllLines(osuFilePath);
        bool hitObjectsSection = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[HitObjects]")) // 🎯 HitObjects 섹션 시작
            {
                hitObjectsSection = true;
                continue;
            }

            if (hitObjectsSection && !string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 3)
                {
                    float x = float.Parse(parts[0]);    // X 좌표
                    float y = float.Parse(parts[1]);    // Y 좌표
                    float time = float.Parse(parts[2]); // 타이밍 (ms)

                    hitObjects.Add(new OsuHitObject(x, y, time));
                }
            }
        }

        Debug.Log("총 " + hitObjects.Count + "개의 노트를 파싱했습니다.");
        return hitObjects;
    }
}