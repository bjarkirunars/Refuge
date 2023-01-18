using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover1 : MonoBehaviour
{
    float m_timePassed;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timePassed = m_timePassed + Time.deltaTime;
        if (m_timePassed < 12 & m_timePassed > 1) {
            mainCamera.transform.Translate(0, 0, 0.015f);
        }
    }
}
