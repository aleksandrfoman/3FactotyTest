using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCleaner : Factory
{
    
    [SerializeField] private FactoryInput factoryInput1;
    [SerializeField] private FactoryInput factoryInput2;
    [SerializeField] private FactoryInput factoryInput3;
    protected override IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if(factoryInput1.IsTakeFactroy() || factoryInput2.IsTakeFactroy() || factoryInput3.IsTakeFactroy())
                        OnTick.Invoke();
        }
    }
}
