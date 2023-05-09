/*************************************************
  * 名稱：MultitonMono
  * 作者：RyanHsu
  * 功能說明：
  * ***********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MultitonMono<T> where T : MultitonMono<T>, new()
{
    #region Static

    static Dictionary<MonoBehaviour, T> _dic = new Dictionary<MonoBehaviour, T>();
    public static T GetInstance(MonoBehaviour mono)
    {
        if (!_dic.TryGetValue(mono, out T value))
        {
            value = new T();
            _dic.Add(mono, value);
        }
        return value;
    }
    public static void RemoveInstance(MonoBehaviour mono) => _dic.Remove(mono);

    #endregion

    protected MultitonMono() { }

}
