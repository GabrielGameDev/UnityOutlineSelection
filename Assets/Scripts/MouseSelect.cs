using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    public float maxDistance = 100;
    OutlineObject outlineObject;   

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxDistance))
		{
            if(outlineObject != null)
			{
                if(outlineObject.transform != hit.transform)
				{
                    outlineObject.Deselect();
				}
			}

            outlineObject = hit.transform.GetComponent<OutlineObject>();
            if(outlineObject != null)
			{
                outlineObject.Select();
			}
		}
		else
		{
            if(outlineObject != null)
			{
                outlineObject.Deselect();
			}
            outlineObject = null;
		}
    }
}
