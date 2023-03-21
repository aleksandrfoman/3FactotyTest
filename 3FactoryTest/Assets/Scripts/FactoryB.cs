using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryB : Factory
{
    [SerializeField] private FactoryInput factoryInput;
    [SerializeField] private FactoryOutput factoryOutput;
    protected override IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (factoryOutput.HaveSpace())
            {
                if(factoryInput.IsTakeFactroy())
                    OnTick.Invoke();
            }

        }
    }
}
