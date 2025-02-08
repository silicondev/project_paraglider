using project_paraglider.System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BlockFace : VisualObject
{
    private Vector3 _direction;
    private float _size;

    public BlockFace(Vector3 direction, float size)
    {
        _direction = direction;
        _size = size;
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
        float half = _size * .5f;

        /*
        FACE
        0---1
        |   |
        2---3
        */

        Vector3[] vertices =
        {
            (Vector3.up * half) + (_direction * half) + (Vector3.left * half),
            (Vector3.up * half) + (_direction * half) + (Vector3.right * half),
            (Vector3.down * half) + (_direction * half) + (Vector3.left * half),
            (Vector3.down * half) + (_direction * half) + (Vector3.right * half),
        };

        int[] triangles =
        {
            // FRONT
            0, 2, 1,
            1, 2, 3
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
