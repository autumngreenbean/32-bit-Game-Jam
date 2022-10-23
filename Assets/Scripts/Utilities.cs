using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    /// <summary>
    /// Maps a value from one range to another. 
    /// </summary>
    /// <param name="from">The original value.</param>
    /// <param name="fromMin">The original range minimum.</param>
    /// <param name="fromMax">The original range maximum.</param>
    /// <param name="toMin">The new range minimum.</param>
    /// <param name="toMax">The new range maximum.</param>
    /// <returns>
    /// Float value mapped to the new range.
    /// </returns>
    public static float Map(float from, float fromMin, float fromMax, float toMin,  float toMax)
    {
        var fromAbs  =  from - fromMin;
        var fromMaxAbs = fromMax - fromMin;      
    
        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;
    
        return to;
    }
}
