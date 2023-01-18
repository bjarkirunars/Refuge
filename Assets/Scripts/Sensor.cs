using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public enum SensorType { 
        Near,
        Far,
        SocialZone
    };

    public PerceptionManager m_PerceptionManager;

    public SensorType m_MySensorType;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sensor Triggered!");
        GameObject subject;
        if (other.tag == "Player")
        {
            subject = other.gameObject.transform.GetChild(0).gameObject;
        }
        else subject = other.gameObject;
        m_PerceptionManager.SensorInput(m_MySensorType, subject);
        
    }

    // Overrides this event callback
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Sensor Exit Triggered!");
        m_PerceptionManager.SensorInput(m_MySensorType, other.gameObject, false);
    }
}
