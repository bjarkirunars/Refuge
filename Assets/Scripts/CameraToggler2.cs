using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggler2 : MonoBehaviour
{
    float m_timePassed;
    public GameObject camera1;
    public GameObject camera2;
    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        m_timePassed = m_timePassed + Time.deltaTime;
        Debug.Log(m_timePassed);
        if (m_timePassed > 5) {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        if (m_timePassed < 8 & m_timePassed > 5) {
            camera2.transform.Translate(0, 0, 0.03f);
        }
    }
}
