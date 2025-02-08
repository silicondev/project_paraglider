using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace project_paraglider.System
{
    public abstract class VisualObject : MonoBehaviour
    {
        protected MeshFilter _filter;

        protected abstract void OnStart();
        protected abstract void OnUpdate();
        protected abstract void GenerateMesh(Mesh mesh);

        // Start is called before the first frame update
        void Start()
        {
            OnStart();

            if (_filter == null)
            {
                var meshObj = new GameObject("mesh");
                meshObj.transform.parent = base.transform;
                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                _filter = meshObj.AddComponent<MeshFilter>();
                _filter.sharedMesh = new Mesh();
            }

            GenerateMesh(_filter.sharedMesh);
        }

        // Update is called once per frame
        void Update()
        {
            OnUpdate();
        }
    }
}
