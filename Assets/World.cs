using project_paraglider.System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private WorldSettings _settings = new WorldSettings();

    private int[][] _heights;

    private Chunk[][] _chunks;

    // Start is called before the first frame update
    void Start()
    {
        _heights = new int[_settings.Size][];
        for (int x = 0; x < _settings.Size; x++)
        {
            _heights[x] = new int[_settings.Size];
            for (int y = 0; y < _settings.Size; y++)
            {
                _heights[x][y] = (int)Math.Floor(Perlin.Noise(new Vector2(x, y)) * _settings.Magnitude);
            }
        }

        _chunks = new Chunk[_settings.Size / _settings.ChunkSize][];
        for (int x = 0; x < _settings.Size / _settings.ChunkSize; x++)
        {
            _chunks[x] = new Chunk[_settings.Size / _settings.ChunkSize];
            int[][] range = _heights.GetRange(x * _settings.ChunkSize, (x + 1) * _settings.ChunkSize);
            for (int y = 0; y < _settings.Size / _settings.ChunkSize; y++)
            {
                for (int i = 0; i < range.Length; i++)
                {
                    range[i] = range[i].GetRange(y * _settings.ChunkSize, (y + 1) * _settings.ChunkSize);
                }
                _chunks[x][y] = new Chunk(range);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
