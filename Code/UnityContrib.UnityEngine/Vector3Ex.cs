﻿using UnityEngine;

namespace UnityContrib.UnityEngine
{
    /// <summary>
    /// Provides a set of helper methods for working with the <see cref="T:UnityEngine.Vector3"/> struct.
    /// </summary>
    public static class Vector3Ex
    {
        /// <summary>
        /// Returns a random position around the specified center <paramref name="position"/>.
        /// 
        /// The Y component of the random position will always be the same as the center position.
        /// </summary>
        /// <param name="position">
        /// The center position to generate a random position around.
        /// </param>
        /// <param name="distance">
        /// The distance from the center position to the generated random position.
        /// </param>
        /// <returns>
        /// The generated random position.
        /// </returns>
        /// <example>
        /// public void Example()
        /// {
        ///     var center = Vector3(100.0f, 100.0f, 100.0f);
        ///     var around = center.Around(20.0f);
        /// }
        /// </example>
        public static Vector3 Around(this Vector3 position, float distance)
        {
            var vector = RandomEx.Vector3XZ() * distance + position;
            return vector;
        }

        /// <summary>
        /// Returns a random position inside a box.
        /// </summary>
        /// <param name="position">
        /// The center of the box.
        /// </param>
        /// <param name="x">
        /// The width of the box.
        /// </param>
        /// <param name="y">
        /// The height of the box.
        /// </param>
        /// <param name="z">
        /// The depth of the box.
        /// </param>
        /// <returns>
        /// The random position inside the box.
        /// </returns>
        /// <example>
        /// public void Example()
        /// {
        ///     var center = Vector3(100.0f, 100.0f, 100.0f);
        ///     var within = center.Within(20.0f, 30.0f, 40.0f);
        /// }
        /// </example>
        public static Vector3 Within(this Vector3 position, float x, float y, float z)
        {
            position.x += (Random.value * 2.0f - 1.0f) * x;
            position.y += (Random.value * 2.0f - 1.0f) * y;
            position.z += (Random.value * 2.0f - 1.0f) * z;
            return position;
        }

        /// <summary>
        /// Returns the slope of the specified <paramref name="normal"/> in radians.
        /// </summary>
        /// <param name="normal">
        /// The normal who's slope to calculate.
        /// </param>
        /// <param name="up">
        /// The up direction.
        /// </param>
        /// <returns>
        /// The slope in radians.
        /// </returns>
        public static float CalculateSlopeRad(this Vector3 normal, Vector3 up)
        {
            return Mathf.Abs(Vector3.Dot(up, normal));
        }

        /// <summary>
        /// Returns the slope of the specified <paramref name="normal"/> in radians.
        /// </summary>
        /// <param name="normal">
        /// The normal who's slope to calculate.
        /// </param>
        /// <returns>
        /// The slope in radians.
        /// </returns>
        public static float CalculateSlopeRad(this Vector3 normal)
        {
            return normal.CalculateSlopeRad(Vector3.up);
        }

        /// <summary>
        /// Returns the slope of the specified <paramref name="normal"/> in degrees.
        /// 
        /// Based on Y being the up component.
        /// </summary>
        /// <param name="normal">
        /// The normal who's slope to calculate.
        /// </param>
        /// <param name="up">
        /// The up direction.
        /// </param>
        /// <returns>
        /// The slope in degrees.
        /// </returns>
        public static float CalculateSlopeDeg(this Vector3 normal, Vector3 up)
        {
            return normal.CalculateSlopeRad(up) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Returns the slope of the specified <paramref name="normal"/> in degrees.
        /// 
        /// Based on Y being the up component.
        /// </summary>
        /// <param name="normal">
        /// The normal who's slope to calculate.
        /// </param>
        /// <returns>
        /// The slope in degrees.
        /// </returns>
        public static float CalculateSlopeDeg(this Vector3 normal)
        {
            return normal.CalculateSlopeRad() * Mathf.Rad2Deg;
        }
    }
}
