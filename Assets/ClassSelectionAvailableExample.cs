using Gtec.UnityInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Gtec.UnityInterface.BCIManager;

public class ClassSelectionAvailableExample : MonoBehaviour
{
    private uint _selectedClass = 0;
    private bool _update = false;
    public ERPFlashController3D _flashColl;
    public GameObject player;
    
    private Dictionary<int, Renderer> selectedObjects;


    void Start()
    {
        //attach to class selection available event
        BCIManager.Instance.ClassSelectionAvailable += OnClassSelectionAvailable;
        selectedObjects = new Dictionary<int, Renderer>();
        List<ERPFlashObject3D> appObjects = _flashColl.ApplicationObjects;

        // get selected "button"
        foreach (ERPFlashObject3D controller in appObjects){
            Renderer[] renderers = controller.GameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers){
                if (renderer.gameObject.name == "Selected"){
                    selectedObjects.Add(controller.ClassId, renderer);
                }
            }
        }

        // hide on start
        foreach(KeyValuePair<int, Renderer> kvp in selectedObjects){
            kvp.Value.gameObject.SetActive(false);
        }
    }

    void OnApplicationQuit()
    {
        //detach from class selection available event
        BCIManager.Instance.ClassSelectionAvailable -= OnClassSelectionAvailable;
    }

    void Update() {
        if(_update) {

            // hide prev. selection
            foreach(KeyValuePair<int, Renderer> kvp in selectedObjects){
                kvp.Value.gameObject.SetActive(false);
            }

            // display selected item
            if((int)_selectedClass != 0){
                selectedObjects[(int)_selectedClass].gameObject.SetActive(true);
            }

            switch (_selectedClass) {
                case 0:
                    break;
                case 1: // down
                    player.GetComponent<Cube>().moveCube("down");
                    break;
                case 2: // left
                    player.GetComponent<Cube>().moveCube("left");
                    break;
                case 3: // right
                    player.GetComponent<Cube>().moveCube("right");
                    break;
                case 4: // up
                    player.GetComponent<Cube>().moveCube("up");
                    break;

            }
            _update = false;
        } 
    }

    /// <summary>
    /// This event is called whenever a new class selection is available. Th
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClassSelectionAvailable(object sender, EventArgs e)
    {
        ClassSelectionAvailableEventArgs ea = (ClassSelectionAvailableEventArgs)e;
       _selectedClass = ea.Class;
        _update = true;
        Debug.Log(string.Format("Selected class: {0}", ea.Class));
    }
}
