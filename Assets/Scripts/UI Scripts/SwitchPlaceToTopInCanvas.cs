using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlaceToTopInCanvas : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] GameObject parent;

    public void SwitchPositionToTop(GameObject go)
    {
        int childCount = parent.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.transform.GetChild(i);
            gameObjects.Add(child.gameObject);
        }

        List <GameObject> temp = new List<GameObject>();
        foreach (GameObject child in gameObjects)
        {
            if(child != go)
            {
                temp.Add(child);
            }
        }

        foreach (GameObject child in temp)
        {
            Instantiate(child).transform.parent = parent.transform;      
        }

        foreach (GameObject child in temp)
        {
            Destroy(child);
        }

        gameObjects.Clear();
    }
}
