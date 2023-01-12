using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TMPro;

namespace SRH.Toolkit
{
    [AddComponentMenu("SRH/Effects/Type Writer Effect")]
    public class TypeWriterEffect : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0.05f, 0.5f), Tooltip("The time it takes to type between each character.")] private float timeBetweenChars = 0.1f;
        [SerializeField, Range(0.05f, 0.5f), Tooltip("The time it takes to type between each token.")] private float timeOnTokens = 0.1f;
        [SerializeField, Tooltip("Executes the typing effect on the Start method if true.")] private bool typeOnStart = false;

        [Header("Events")]
        [SerializeField, Tooltip("Invokes just before the type starts.")] private UnityEvent onStart;
        [SerializeField, Tooltip("Invokes every on character being typed.")] private UnityEvent onType;
        [SerializeField, Tooltip("Invokes just after the type ends.")] private UnityEvent onEnd;

        private Text textComponent;
        private TextMeshProUGUI tmpComponent;

        private char[] tokens = new char[] { ',', '.', '?', '!', ';', ':' };

        private string text;
        private float extraTime = 0;
        private bool isExtra = false;

        void Start()
        {
            if (typeOnStart)
                StartTypingEffect();
        }

        /// <summary>
        /// Starts the type writer effect.
        /// </summary>
        public void StartTypingEffect()
        {
            if (TryGetComponent<Text>(out textComponent))
                GetText();
            else if (TryGetComponent<TextMeshProUGUI>(out tmpComponent))
                GetTMPText();

            StartCoroutine(TypeTextEffect());
        }

        private void GetText()
        {
            text = textComponent.text;

            textComponent.text = "";
        }

        private void GetTMPText()
        {
            text = tmpComponent.text;

            tmpComponent.text = "";
        }

        private IEnumerator TypeTextEffect()
        {
            onStart.Invoke();

            if (textComponent != null)
            {
                foreach (char c in text)
                {
                    textComponent.text += c;
                    onType.Invoke();

                    foreach (char token in tokens)
                    {
                        if (c == token && isExtra == false)
                            isExtra = true;
                    }

                    if (isExtra)
                    {
                        extraTime += timeOnTokens;
                        isExtra = false;
                    }
                    else
                    {
                        extraTime = 0;
                    }

                    yield return new WaitForSeconds(timeBetweenChars + extraTime);
                }

                onEnd.Invoke();
            }
            else if (tmpComponent != null)
            {
                foreach (char c in text)
                {
                    tmpComponent.text += c;
                    onType.Invoke();

                    foreach (char token in tokens)
                    {
                        if (c == token && isExtra == false)
                            isExtra = true;
                    }

                    if (isExtra)
                    {
                        extraTime += timeOnTokens;
                        isExtra = false;
                    }
                    else
                    {
                        extraTime = 0;
                    }

                    yield return new WaitForSeconds(timeBetweenChars + extraTime);
                }

                onEnd.Invoke();
            }
            else
            {
                Debug.LogError("No Text or Text Mesh Pro component founded on this object!");
            }
        }
    }
}
