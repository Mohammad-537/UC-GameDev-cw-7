using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = Player.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!agent.hasPath)
        //{
        //    if(target != null)
        //    {
                agent.SetDestination(target.transform.position);
        //        anim.SetBool("isRunning", false);
        //        agent.isStopped = false;
        //    }
        anim.SetBool("isRunning", true);
        //}
    }
}
