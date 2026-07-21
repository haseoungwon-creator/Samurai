using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager
{
    private static Dictionary<float, WaitForSeconds> dictionary = new();

    public static WaitForSeconds Wait(float time)
    {
        if(dictionary.TryGetValue(time, out WaitForSeconds wait))
        {
            return wait;
        }

        WaitForSeconds newWait = new WaitForSeconds(time);
        dictionary.Add(time, newWait);
        return newWait;
    }
}
