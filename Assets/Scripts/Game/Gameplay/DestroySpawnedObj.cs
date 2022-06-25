using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Gameplay.Common;
using Game.Gameplay.Targets;
using Game.Gameplay.Player;
namespace Game.Gameplay
{
    public class DestroySpawnedObj : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerKiller>() ||
                collision.gameObject.GetComponent<Target>() ||
                collision.gameObject.GetComponent<Aid>())
                Destroy(collision.gameObject);
        }
    }
}

