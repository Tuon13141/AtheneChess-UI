using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModeBoxController : MonoBehaviour
{
    private List<GameObject> modeDescriptionBoxes = new List<GameObject>();
    public GameObject modeDescriptionBox;

    public void OnClicked()
    {      
        modeDescriptionBoxes = GameObject.FindGameObjectsWithTag("Mode Description").ToList();
        foreach (GameObject go in modeDescriptionBoxes)
        {
            if (go != modeDescriptionBox)
            {
                go.SetActive(false);
            }      
        }

        if(!modeDescriptionBox.activeSelf)
        {
            modeDescriptionBox.SetActive(true);
        }
        else
        {
            modeDescriptionBox.SetActive(false);
        }
    }

}
