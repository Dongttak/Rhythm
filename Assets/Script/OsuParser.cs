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
        this.time = time-1480;
    }
}

public class OsuParser
{
    public static List<OsuHitObject> ParseOsuFile(string filePath)
    {
        List<OsuHitObject> hitObjects = new List<OsuHitObject>();

        if (!File.Exists(filePath))
        {
            Debug.LogError($"파일을 찾을 수 없습니다: {filePath}");
            return null;
        }

        string[] lines = File.ReadAllLines(filePath);
        bool hitObjectsSection = false;

        foreach (string line in lines)
        {
            if (line.StartsWith("[HitObjects]"))
            {
                hitObjectsSection = true;
                continue;
            }

            if (hitObjectsSection && !string.IsNullOrWhiteSpace(line))
            {
                OsuHitObject hitObject = ParseHitObject(line);
                if (hitObject != null)
                {
                    hitObjects.Add(hitObject);
                }
            }
        }

        if (hitObjects.Count == 0)
        {
            Debug.LogError("Osu 파일을 읽었지만 HitObjects 섹션이 비어 있습니다!");
        }

        return hitObjects;
    }

    private static OsuHitObject ParseHitObject(string line)
    {
        string[] values = line.Split(',');

        if (values.Length < 3)
        {
            Debug.LogError($"올바르지 않은 HitObject 데이터: {line}");
            return null;
        }

        float x = float.Parse(values[0]);
        float y = float.Parse(values[1]);
        float time = float.Parse(values[2]);

        return new OsuHitObject(x, y, time);
    }
}