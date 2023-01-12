using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRH
{
    public static class Extensions
    {
        #region Transform
        /// <summary>
        /// Returns requested component, if the requested component is not attached then it adds said component and returns it.
        /// </summary>
        public static T GetOrAddComponent<T>(this Transform transform) where T : Component
        {
            if (transform.TryGetComponent<T>(out T requestedComponent))
                return requestedComponent;

            return transform.gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Destroys all children of this transform.
        /// </summary>
        public static void DestroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
                UnityEngine.Object.Destroy(child.gameObject);
        }
        #endregion Transform

        #region GameObject
        /// <summary>
        /// Returns requested component, if the requested component is not attached then it adds said component and returns it.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent<T>(out T requestedComponent))
                return requestedComponent;

            return gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Destroys all children of this transform.
        /// </summary>
        public static void DestroyChildren(this GameObject gameObject)
        {
            foreach (Transform child in gameObject.transform)
                UnityEngine.Object.Destroy(child.gameObject);
        }
        #endregion GameObject

        #region Colour
        /// <summary>
        /// Checks if two colours are similar based on a threshold that uses their RGB values.
        /// </summary>
        /// <param name="a">The first colour.</param>
        /// <param name="b">The second colour.</param>
        /// <param name="threshold">The amount that the colours can be apart until they are considered not similar.</param>
        /// <returns></returns>
        public static bool AreSimilar(this Color a, Color b, float threshold)
        {
            return Mathf.Abs(a.r - b.r) < threshold && Mathf.Abs(a.g - b.g) < threshold && Mathf.Abs(a.b - b.b) < threshold;
        }

        /// <summary>
        /// Requires TextMeshPro. Returns the text parsed with colour so it can be shown with colour in TextMeshPro.
        /// </summary>
        public static string WithColor(this string text, Color colour)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGB(colour)}>{text}</color>";
        }

        /// <summary>
        /// Returns the original color with the alpha overwritten by the alpha value.
        /// </summary>
        public static Color WithAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
        #endregion Colour

        #region Int
        /// <summary>
        /// Gets the value as a percentage.
        /// </summary>
        public static float GetPercentage(this int value, float total)
        {
            return (value / total) * 100;
        }

        /// <summary>
        /// Gets the average of a list of ints.
        /// </summary>
        public static float Average(this List<int> values)
        {
            float amount = 0;

            foreach (var value in values)
            {
                amount += value;
            }

            return (float)(amount / values.Count);
        }

        /// <summary>
        /// Gets the average of an array of ints.
        /// </summary>
        public static float Average(this int[] values)
        {
            float amount = 0;

            foreach (var value in values)
            {
                amount += value;
            }

            return (float)(amount / values.Length);
        }
        #endregion Int

        #region Float
        /// <summary>
        /// Gets the value as a percentage.
        /// </summary>
        public static float GetPercentage(this float value, float total)
        {
            return (value / total) * 100;
        }

        /// <summary>
        /// Gets the average of a list of floats.
        /// </summary>
        public static float Average(this List<float> values)
        {
            float amount = 0;

            foreach (var value in values)
            {
                amount += value;
            }

            return (float)(amount / values.Count);
        }

        /// Gets the average of an array of floats.
        /// </summary>
        public static float Average(this float[] values)
        {
            float amount = 0;

            foreach (var value in values)
            {
                amount += value;
            }

            return (float)(amount / values.Length);
        }
        #endregion Float

        #region Double
        /// <summary>
        /// Gets the value as a percentage.
        /// </summary>
        public static float GetPercentage(this double value, float total)
        {
            return (float)(value / total) * 100;
        }

        /// <summary>
        /// Gets the average of a list of doubles.
        /// </summary>
        public static float Average(this List<double> values)
        {
            float amount = 0;

            foreach (var value in values)
            {
                amount += (float)value;
            }

            return (float)(amount / values.Count);
        }

        /// <summary>
        /// Gets the average of an array of doubles.
        /// </summary>
        public static float Average(this double[] values)
        {
            float amount = 0;

            foreach (var value in values)
            {
                amount += (float)value;
            }

            return (float)(amount / values.Length);
        }
        #endregion Double

        #region Random
        /// <summary>
        /// Returns a random element in the array.
        /// </summary>
        public static T Random<T>(this T[] list)
        {
            return list[UnityEngine.Random.Range(0, list.Length - 1)];
        }

        /// <summary>
        /// Returns a random element in the list.
        /// </summary>
        public static T Random<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Returns a random character in the string.
        /// </summary>
        public static char Random(this string text)
        {
            char[] letters = text.ToCharArray();

            return letters[UnityEngine.Random.Range(0, letters.Length)];
        }
        #endregion Random
    }
}