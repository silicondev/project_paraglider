using project_paraglider.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : VisualObject
{
    private int[][] _heights;

    public Chunk(int[][] heights)
    {
        _heights = heights;
    }

    // Start is called before the first frame update
    protected override void OnStart()
    {
        
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        
    }

    protected override void GenerateMesh(Mesh mesh)
    {

    }
}
