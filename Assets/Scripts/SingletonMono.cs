/*************************************************
  * 名稱：SingletonMono
  * 作者：RyanHsu
  * 功能說明：
  * ***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMono<T> where T : SingletonMono<T>, new()
{
    #region Static
    static T _single;
    public static T GetInstance() => _single ??= new T();
    #endregion

    MonoBehaviour m_Mono;
    public MonoBehaviour mono { get => m_Mono; }
    public void SetMono(MonoBehaviour obj) => m_Mono = obj;

    protected SingletonMono() { }

}
