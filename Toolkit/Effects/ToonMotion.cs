/*
    Script taken from https://gist.github.com/mnogue/e2f029537e5985e7e864588cd9bedd05
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRH.Toolkit
{
    [AddComponentMenu("SRH/Animation/Toon Motion")]
    public class ToonMotion : MonoBehaviour
    {
        private class Snapshot
        {
            public Transform m_Transform;
            public Vector3 m_Position;
            public Quaternion m_Rotation;
            public Vector3 m_Scale;

            public Snapshot(Transform transform)
            {
                this.m_Transform = transform;
                this.Update();
            }

            public void Update()
            {
                this.m_Position = this.m_Transform.position;
                this.m_Rotation = this.m_Transform.rotation;
                this.m_Scale = this.m_Transform.localScale;
            }
        }

        private Dictionary<int, Snapshot> m_Snapshots;
        private float m_UpdateTime = 0f;

        [Range(1, 60)]
        [SerializeField] private int m_FPS = 24;

        private void Start()
        {
            m_Snapshots = new Dictionary<int, Snapshot>();
        }

        private void LateUpdate()
        {
            if ((Time.time - m_UpdateTime) > (1f / m_FPS))
            {
                SaveSnapshot(transform);
                m_UpdateTime = Time.time;
            }

            foreach (KeyValuePair<int, Snapshot> item in m_Snapshots)
            {
                if (item.Value.m_Transform != null)
                {
                    item.Value.m_Transform.position = item.Value.m_Position;
                    item.Value.m_Transform.rotation = item.Value.m_Rotation;
                    item.Value.m_Transform.localScale = item.Value.m_Scale;
                }
            }
        }

        private void SaveSnapshot(Transform parent)
        {
            if (parent == null) return;
            int childrenCount = parent.childCount;

            for (int i = 0; i < childrenCount; ++i)
            {
                Transform target = parent.GetChild(i);
                int uid = target.GetInstanceID();

                m_Snapshots[uid] = new Snapshot(target);
                SaveSnapshot(target);
            }
        }
    }
}