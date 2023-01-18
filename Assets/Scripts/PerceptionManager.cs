using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionManager : MonoBehaviour
{
    public ActionManager m_CharacterActionManager;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    // public GameObject m_SocialTarget;   // Points to an entity that has entered our SocialZone

    // Returns True if we have anyone inside our SocialZone
    // public bool HasSocialTarget()
    // {
    //     return m_SocialTarget != null;
    // }

    // public void IgnoreSocialTarget()
    // {
    //     m_SocialTarget = null;
    // }

    public void SensorInput(Sensor.SensorType type, GameObject subject, bool state = true)
    {
        switch(type)
        {
            case Sensor.SensorType.Far:
                m_CharacterActionManager.GazeTrack(subject);
                break;
            case Sensor.SensorType.Near:
                m_CharacterActionManager.GazeTrack(subject);
                // m_CharacterActionManager.WalkAway();
                break;
        //     case Sensor.SensorType.SocialZone:
        //         if (state == true)
        //         {
        //             Debug.Log("PM: Someone Entered Social Zone");
        //             m_SocialTarget = subject;       // Simply store the entering object as our SocialTarget
        //         } else {
        //             Debug.Log("PM: Someone Left Social Zone ");
        //             m_SocialTarget = null;          // Reset the SocialTarget 
        //         }
        //         break;
        }
    }
}
