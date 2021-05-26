using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private Image aimImage;
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue, 1.0f);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,60)== true)
        
        {
            Debug.Log(hit.transform.gameObject.tag);
            string hitName = hit.transform.gameObject.tag;
            if(hitName=="Enemy")
            {
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
