using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
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
        if (m_timePassed < 11 & m_timePassed > 3.5) {
            mainCamera.transform.Translate(0, 0, 0.02f);
        }
    }
}
