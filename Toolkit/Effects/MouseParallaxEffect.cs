using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRH.Toolkit
{
    [AddComponentMenu("SRH/Effects/Mouse Parallax Effect")]
    public class MouseParallaxEffect : MonoBehaviour
    {
        [SerializeField] private float m_Modifer = -1;

        private Vector3 m_Pos;
        private Vector3 m_StartPos;

        private Camera m_Camera;

        private void Start()
        {
            m_StartPos = transform.position;
            m_Camera = Camera.main;
        }

        private void Update()
        {
            var pos = m_Camera.ScreenToViewportPoint(Input.mousePosition);
            pos.z = 0;

            transform.position = pos;
            transform.position = new Vector3(m_StartPos.x + (pos.x * m_Modifer), m_StartPos.y + (pos.y * m_Modifer), 0);
        }
    }
}
