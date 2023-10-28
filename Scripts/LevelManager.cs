using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    //重生时间
    public float waitToRespawn;
    //宝石数量
    public int gemsCollected;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        PlayerController.instance.gameObject.SetActive(true);

        //重生在记录点或者原点
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        //恢复血量
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        //刷新血量条
        UIController.instance.UpdateHealthDisplay();
    }
}
