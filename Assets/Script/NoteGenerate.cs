using System;
using System.Collections.Generic;

[Serializable]
public class OsuHitObject
{
    public int x;        // 노트 위치 (X 좌표)
    public int y;        // 노트 위치 (Y 좌표)
    public int time;     // 노트 타이밍 (ms 단위)
    public int type;     // 노트 타입 (1: 일반, 2: 슬라이더, 8: 스피너)
}

[Serializable]
public class OsuMapData
{
    public string title;
    public string artist;
    public string audioFilename;
    public int previewTime;
    public List<OsuHitObject> hitObjects;
}