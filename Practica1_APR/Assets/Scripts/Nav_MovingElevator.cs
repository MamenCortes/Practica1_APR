using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_MovingElevator : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    private bool switching; 

    public float speed = 1.5f;
    private Transform target; 

    private float randomOffset;
    void Start()
    {
        randomOffset = Random.Range(0f, 2f);
    }

    void Update()
    {
        //Indicar hacia qué punto debe desplazarse
        if(switching == true)
        {
            target = pos1; 
        }else{
            target = pos2;
        }

        //Cambiar la dirección de movimiento cuando llegue a dicho punto
        if(transform.position == pos1.position)
        {
            switching = false; 
        }else if(transform.position == pos2.position)
        {
            switching = true;
        }

        //Mover la plataforma de un punto a otro. 
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }

    //Para que el jugador se mueva con la plataforma
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            other.transform.parent = this.transform; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            other.transform.parent = null;
        }
    }
}
