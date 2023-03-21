using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Factory : MonoBehaviour
{
    [SerializeField]
    protected float time;
    [HideInInspector]
    public UnityEvent OnTick;

    private void Awake()
    {
        StartCoroutine(Loop());
    }

    protected virtual IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            OnTick.Invoke();
        }
    }
}
