using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPoolBar : MonoBehaviour
{
    [SerializeField] Image bar;
    ValuePool targetPool;

    public void Show(ValuePool targetPool)
    {
        this.targetPool = targetPool;
        gameObject.SetActive(true);
    }

    public void Clear()
    {
        this.targetPool = null;
        gameObject.SetActive(false);
    }


    private void Update()
    {
        if (targetPool == null)
            return;
        bar.fillAmount =  Mathf.InverseLerp(0f, targetPool.maxValue.value, targetPool.currentValue);
    }
}
