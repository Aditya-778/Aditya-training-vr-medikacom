using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerQuest : MonoBehaviour
{
    [SerializeField] private EndlessQuestController _endlessQuest;
    [SerializeField] private Module4.QuestController _questController;
    private GameObject _NpcGameobject;

    public UnityEvent onNpcTrigger;
    public GameObject objecttospawn;
    public Transform spwnpoint;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Npc")) {
            _NpcGameobject = other.gameObject;
            _endlessQuest.GenerateQuest();
            _questController.OpenQuest(); 
            onNpcTrigger.Invoke();
            spawnobject();
        }
    }

    public void DestroyNpc() {
        var gameobjectToDestroy = _NpcGameobject;
        Destroy(gameobjectToDestroy);
    }

    public void spawnobject()
    {
        Instantiate(objecttospawn, spwnpoint.position, Quaternion.identity);
    }


}
