using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    //Array de GameObjects que possuem NavMesh
    public GameObject[] agents;

    private void Start() 
    {
        //Preenchendo a array com objetos que possuem a tag "AI"
        agents = GameObject.FindGameObjectsWithTag("AI");            
    }
    private void Update() 
    {
        //Executa função ao apertar o botão "0" do mouse (botão esquerdo)
        if (Input.GetMouseButton(0))
        {
            //Criando um raycast
            RaycastHit hit;

            //Executa função caso Raycast atinja algum colisor
            //O Raycast é disparado em direção a posição do mouse
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                //Executa uma função para cada objeto dentro da array "agents"
                foreach(GameObject a in agents)
                {
                    //Obtém o componente "AIControl" e manipula seu "NavMeshAgent", definindo seu novo destino
                    a.GetComponent<AIControl>().agent.SetDestination(hit.point);
                }                
            }
        }   
    }
}
