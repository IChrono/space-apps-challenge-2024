using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDescription(PlanetData planet) {
        dialog.SetActive(true);
        title.text=planet.description;
        description.text=planet.description;
    }

    public void HideDescription(){
        title.text=string.Empty;
        description.text=string.Empty;
        dialog.SetActive(false);
    }
}