using System.Collections;
using UnityEngine;

namespace Content.Scripts
{
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
}
