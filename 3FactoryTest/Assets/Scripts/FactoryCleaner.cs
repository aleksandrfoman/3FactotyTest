using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCleaner : Factory
{
    protected override IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            TakeItems();
            OnTick.Invoke();
        }
    }
}
