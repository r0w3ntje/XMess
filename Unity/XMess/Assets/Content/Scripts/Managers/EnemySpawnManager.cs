using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    [Header("Prefabs")]
    [SerializeField] private GameObject enemyMutant;
    [SerializeField] private GameObject enemyNormal;

    [Header("Spawning")]
    [SerializeField] private List<Vector2> spawnPosition;
    [SerializeField] private float spawnDelay;

    [Header("Waves")]
    [SerializeField] private int wave;
    [SerializeField] private List<Wave> waves;

    [Header("UserInterface")]
    [SerializeField] private Text waveText;
    [SerializeField] private Text nextWaveText;

    private Coroutine waveRoutine;

    public void Start()
    {
        wave = 0;
        NextWaveCheck();
    }

    private void Update()
    {
        if (waveRoutine == null)
            NextWaveCheck();
    }

    private IEnumerator SpawnEnemies()
    {
        nextWaveText.enabled = true;
        nextWaveText.text = "Next wave in 3";
        yield return new WaitForSeconds(1f);
        nextWaveText.text = "Next wave in 2";
        yield return new WaitForSeconds(1f);
        nextWaveText.text = "Next wave in 1";
        yield return new WaitForSeconds(1f);
        nextWaveText.enabled = false;

        for (int i = 0; i < Mathf.RoundToInt(wave * 5f); i++)
        {
            if (PlayerHealth.Instance().isDead) break;

            GameObject enemyGo = null;

            float enemyChance = Random.Range(0f, 100f);
            if (enemyChance >= 80f)
            {
                enemyGo = enemyMutant;
            }
            else enemyGo = enemyNormal;

            var enemy = Instantiate(enemyGo);
            enemy.transform.position = GetSpawnPosition();

            yield return new WaitForSeconds(spawnDelay);
        }

        waveRoutine = null;
    }

    private Vector2 GetSpawnPosition()
    {
        return spawnPosition[Random.Range(0, spawnPosition.Count)];
    }

    public void NextWaveCheck()
    {
        if (PlayerHealth.Instance().isDead) return;

        var enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length <= 0 && waveRoutine == null)
        {
            NextWave();
        }
    }

    private void NextWave()
    {
        wave++;
        waveRoutine = StartCoroutine(SpawnEnemies());
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        waveText.text = "Wave " + wave;
        UserInterfaceManager.Instance().PopEffect(waveText.transform);
    }

    [System.Serializable]
    public class Wave
    {
        public int enemies;
    }
}