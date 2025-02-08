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
        public Mesh Mesh
        {
            get => _filter?.sharedMesh;
            set
            {
                if (_filter != null)
                    _filter.sharedMesh = value;
            }
        }

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
                Mesh = new Mesh();
            }

            GenerateMesh(Mesh);
        }

        // Update is called once per frame
        void Update()
        {
            OnUpdate();
        }

        public void AddChild(VisualObject obj)
        {
            obj.transform.parent = base.transform;
        }
    }
}
