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
        var meshList = new List<CombineInstance>()
        {
            new CombineInstance()
            {
                mesh = mesh,
                transform = base.transform.localToWorldMatrix
            }
        };

        for (int x = 0; x < _heights.Length; x++)
        {
            for (int y = 0; y < _heights[x].Length; y++)
            {

                meshList.Add(CombineFace(new BlockFace(Vector3.up, 1)));

                if (x > 0)
                    meshList.Add(CombineFace(new BlockFace(Vector3.left, 1)));

                if (y > 0)
                    meshList.Add(CombineFace(new BlockFace(Vector3.back, 1)));

                if (x < _heights.Length - 1)
                    meshList.Add(CombineFace(new BlockFace(Vector3.right, 1)));

                if (y < _heights[x].Length - 1)
                    meshList.Add(CombineFace(new BlockFace(Vector3.forward, 1)));
            }
        }

        Mesh.CombineMeshes(meshList.ToArray(), true, false, true);
    }

    private CombineInstance CombineFace(BlockFace face)
    {
        face.gameObject.SetActive(false);
        return new CombineInstance()
        {
            mesh = face.Mesh,
            transform = face.transform.localToWorldMatrix
        };
    }
}
