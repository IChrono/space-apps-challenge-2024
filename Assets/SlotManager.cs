using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] public SnapInteractable[] slots;

    int currentActiveSlot = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleActiveSlot(int slotIndex) {
        for(int i = 0; i < slots.Length; i++) {
            if(i != slotIndex) {
                slots[i].transform.parent.gameObject.SetActive(currentActiveSlot != -1);
            }
        }
        if(currentActiveSlot == -1) {
            currentActiveSlot = slotIndex;
        } else {
            currentActiveSlot = -1;
        }
    }
}
