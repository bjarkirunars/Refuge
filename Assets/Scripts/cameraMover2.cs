using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover2 : MonoBehaviour
{
    float m_timePassed;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timePassed = m_timePassed + Time.deltaTime;
        if (m_timePassed < 40 & m_timePassed > 0) {
            textObject.transform.Translate(0, 0.8f, 0);
        }
    }
}
