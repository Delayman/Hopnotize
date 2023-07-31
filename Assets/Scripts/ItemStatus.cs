using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    public int ironKeyCount = 0;
    public bool isCollectGoldKey = false;

    public void CollectIronKey()
    {
        ironKeyCount++;
    }

    public void CollectGoldKey()
    {
        isCollectGoldKey = true;
    }
}
