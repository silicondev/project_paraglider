using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSettings
{
    [Range(2, 2048)]
    public int Size = 256;
    [Range(2, 1024)]
    public int ChunkSize = 16;
    [Range(1, 1024)]
    public int Magnitude = 128;
}
