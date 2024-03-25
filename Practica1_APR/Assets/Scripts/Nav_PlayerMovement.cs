using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Player_movement : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent agent; 

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.alive)
        {
            if (Input.GetMouseButton(0)) //Botón izquierdo del ratón 
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyFollow") {
            GameManager.Instance.UpdateVida(-1); 
        }
        if (other.tag == "EnemyPatrol")
        {
            GameManager.Instance.UpdateVida(-2);
        }
        
    }
    
}
