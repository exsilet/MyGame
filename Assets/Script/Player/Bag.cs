using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    public int MoneyCount { get;  set; }
    public static Bag Instance { get; private set; }

    public event UnityAction<int> MoneyChanged;
    private void Start()
    {
        Instance = this;
    }

    public void AddMoney(int count)
    {
        MoneyCount += count;
        MoneyChanged?.Invoke(count);
    }


    private void OnDesrtoy()
    {
        Instance = null;
    }
}
