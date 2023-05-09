/*************************************************
  * 名稱：NewBehaviourScript
  * 作者：RyanHsu
  * 功能說明：
  * ***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class NewBehaviourScript : MonoBehaviour
{

    public MySingleValue m_single = MySingleValue.GetInstance();
    public MyMultiValue m_multi;

    void Awake()
    {
        m_single.SetMono(this);
        m_multi ??= MyMultiValue.GetInstance(this);
    }

    void Start()
    {

    }

    private void OnDestroy()
    {
        MyMultiValue.RemoveInstance(this);
    }

    void OnValidate()
    {
        m_multi = MyMultiValue.GetInstance(this);
    }
}

//Singleton
[Serializable]
public class MySingleValue : SingletonMono<MySingleValue>
{
    public string key;
    [Range(0, 10f)] public float value;
}

//multiton
[Serializable]
public class MyMultiValue : MultitonMono<MyMultiValue>
{
    [Range(0, 10f)] public float value;
}