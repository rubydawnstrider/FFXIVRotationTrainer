using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static IList<GameObject> FindChildrenWithTag(this GameObject parent, string tag)
    {
        var children = new List<GameObject>();

        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.CompareTag(tag))
            {
                children.Add(child.gameObject);
            }
        }

        return children;
    }
}
