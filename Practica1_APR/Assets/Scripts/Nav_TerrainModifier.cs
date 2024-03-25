using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;
using JetBrains.Annotations;

public class Nav_TerrainModifier : MonoBehaviour
{
    //Cuando el jugador entre en esta región, aumentar su velocidad.
    private NavMeshModifier _meshSurface;
    public float speedModifier = 5; 
    void Start()
    {
        _meshSurface = GetComponent<NavMeshModifier>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

        //Asegurarme de que other es de tipo agente
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            //Asegurarme de que el agente se ve afectado por este tipo de agente
            if (_meshSurface.AffectsAgentType(agent.agentTypeID))
            {
                //multiplico la velocidad del agente por el coste del mi área
                agent.speed *= speedModifier;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            //Asegurarme de que el agente se ve afectado por este tipo de agente
            if (_meshSurface.AffectsAgentType(agent.agentTypeID))
            {
                //divido la velocidad del agente por el coste del mi área para que vuelva a ser la original
                agent.speed /= speedModifier;
            }
        }
    }
}
