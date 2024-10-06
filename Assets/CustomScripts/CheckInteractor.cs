using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class CheckInteractor : MonoBehaviour
{
    [HideInInspector] public Planet selectedPlanet;
    [SerializeReference] public DialogManager dialogManager;
    
    void Awake(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cione(){
        print("f");
    }

    void OnTriggerEnter(Collider other){
        if(other.TryGetComponent<Planet>(out selectedPlanet)) {
;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.TryGetComponent<Planet>(out Planet exitingPlanet)){
            if(exitingPlanet.planet.id == selectedPlanet.planet.id);
            // dialogManager.ShowDescription();
        }
    }
}
