using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Transform m_DoorTransform;
    [SerializeField] Vector3 m_PositionOpenOffset;

    private Vector3 m_PositionClose;
    private Vector3 m_PositionOpen;

    bool m_IsOpening;
    float m_Alpha;
    private void Awake()
    {
        m_PositionClose = m_DoorTransform.position;
        m_PositionOpen = m_PositionOpenOffset + m_PositionClose;
    }

    private void Update()
    {
        if (m_IsOpening) m_Alpha += Time.deltaTime;
        else m_Alpha -= Time.deltaTime;

        m_Alpha = Mathf.Clamp(m_Alpha, 0, 1);

        m_DoorTransform.position = Vector3.Lerp(m_PositionClose, m_PositionOpen, m_Alpha);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "Player") other.GetComponent<Week6.Player>().Damage();
        
        Debug.Log("door has been trigger");
        m_DoorTransform.position = m_PositionClose + m_PositionOpenOffset;
        m_IsOpening = true;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("door is still being triggerd");
        
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("door is not being triggerd");
        m_DoorTransform.position = m_PositionClose;
        m_IsOpening = false;
    }
}
