using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory3 : Factory
{
    [SerializeField] private FactoryInput factoryInput1;
    [SerializeField] private FactoryInput factoryInput2;
    [SerializeField] private FactoryOutput factoryOutput;
    protected override IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (factoryOutput.HaveSpace())
            {
                if (factoryInput1.IsFactoryHaveItems() && factoryInput2.IsFactoryHaveItems())
                {
                    if(factoryInput1.IsTakeFactroy() && factoryInput2.IsTakeFactroy())
                        OnTick.Invoke();
                }
            }

        }
    }
}
