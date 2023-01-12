using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRH.Toolkit
{
    /// <summary>
    /// Allows you to switch animations over code.
    /// </summary>
    public class AnimationManager
    {
        private string m_CurrentAnimState;
        private Animator m_Animator;

        /// <summary>
        /// Initializes the Animation Manager
        /// </summary>
        /// <param name="animator">The animator component.</param>
        public AnimationManager(Animator animator)
        {
            this.m_Animator = animator;
        }

        /// <summary>
        /// Changes the current animation.
        /// </summary>
        /// <param name="state">The next animation's name.</param>
        /// <param name="layerIndex">The layer index of the animation.</param>
        /// <param name="overwrite">Determines whether the animation overwrite the animation if the same.</param>
        public void ChangeAnimationState(string state, int layerIndex = 0, bool overwrite = true)
        {
            if (state == m_CurrentAnimState && !overwrite)
                return;

            if (!m_Animator.HasState(layerIndex, Animator.StringToHash(state)))
            {
                Debug.LogError($"Animator does not have '{state}' as an animation state.", m_Animator.gameObject);
                return;
            }

            if (m_Animator != null)
            {
                m_Animator.Play(state);
                m_CurrentAnimState = state;
            }
            else
            {
                Debug.LogError($"Animator is null");
                return;
            }
        }

        /// <summary>
        /// Returns the current animation state.
        /// </summary>
        public string GetCurrentAnimationState()
        {
            return m_CurrentAnimState;
        }
    }
}