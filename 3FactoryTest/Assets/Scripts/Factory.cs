using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Factory : MonoBehaviour
{
    [SerializeField]
    protected float time;
    [HideInInspector]
    public UnityEvent OnTick;
    [HideInInspector]
    public UnityEvent<String> OnUpdateUi; 
    [SerializeField] 
    protected FactoryOutput[] factoryOutputs; 
    [SerializeField] 
    protected FactoryInput[] factoryInputs;
    
    private static readonly string InputEmptyStr = "Input Empty";
    private static readonly string OutputFullStr = "Output Full";

    private void Awake()
    {
        StartCoroutine(Loop());
    }

    private void Start()
    {
        OnUpdateUi.Invoke(GetAlertText());
    }

    protected virtual IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (IsHaveInput() && !IsOutputFull())
            {
                TakeItems();
                OnTick.Invoke();
            }
            OnUpdateUi.Invoke(GetAlertText());
        }
    }

    protected void TakeItems()
    {
        foreach (var input in factoryInputs)
        {
            input.TakeItem();
        }
    }
    
    protected bool IsHaveInput()
    {
        foreach (var input in factoryInputs)
        {
            if (!input.IsFactoryHaveItems())
            {
                return false;
            }
        }
        return true;
    }

    private string GetAlertText()
    {
        if (IsInputFull())
        {
            return InputEmptyStr;
        }
        if(IsOutputFull())
        {
            return OutputFullStr;
        }
        return string.Empty;
    }
    
    
    protected bool IsInputFull()
    {
        foreach (var input in factoryInputs)
        {
            if (!input.IsFactoryHaveItems())
            {
                return true;
            }
        }
        return false;
    }
    
    protected bool IsOutputFull()
    {
        foreach (var input in factoryOutputs)
        {
            if (!input.IsHaveSpace())
            {
                return true;
            }
        }
        return false;
    }
    
}
