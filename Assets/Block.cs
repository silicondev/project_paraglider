using project_paraglider.System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : VisualObject
{
    [Range(1, 100)]
    public int Size = 1;

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
        float half = Size * .5f;

        /*
        LAYER 1
        0---1
        |   |
        2---3

        LAYER 2
        4---5
        |   |
        6---7
        */

        Vector3[] vertices =
        {
            (Vector3.up * half) + (Vector3.forward * half) + (Vector3.left * half),
            (Vector3.up * half) + (Vector3.forward * half) + (Vector3.right * half),
            (Vector3.down * half) + (Vector3.forward * half) + (Vector3.left * half),
            (Vector3.down * half) + (Vector3.forward * half) + (Vector3.right * half),

            (Vector3.up * half) + (Vector3.back * half) + (Vector3.left * half),
            (Vector3.up * half) + (Vector3.back * half) + (Vector3.right * half),
            (Vector3.down * half) + (Vector3.back * half) + (Vector3.left * half),
            (Vector3.down * half) + (Vector3.back * half) + (Vector3.right * half)
        };

        int[] triangles =
        {
            // FRONT
            0, 2, 1,
            1, 2, 3,

            // BACK
            5, 6, 4,
            5, 7, 6,

            // RIGHT
            1, 3, 5,
            5, 3, 7,

            // LEFT
            4, 6, 0,
            0, 6, 2,

            // TOP
            4, 0, 5,
            5, 0, 1,

            // BOTTOM
            2, 6, 3,
            3, 6, 7
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
