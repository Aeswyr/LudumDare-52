using UnityEngine;

public class Utils
{
    public static RaycastHit2D Raycast(Vector3 start, Vector2 dir, float dist, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(start, dir, dist, mask);
        //Very good Pascal
        Debug.DrawRay(start, dir * dist, Color.green);
        return hit;
    }


    /// <summary>
    /// Remaps a percentage to a value based on a given range
    /// </summary>
    /// <param name="percent"></param> percentage from min to max of range
    /// <param name="minOut"></param> lower bound of output range
    /// <param name="maxOut"></param> upper bound of output range
    /// <returns></returns>
    public static float RemapPercent(float percent, float minOut, float maxOut)
    {
        float outRange = maxOut - minOut;
        float outValue = outRange * percent + minOut;

        return outValue;
    }
}