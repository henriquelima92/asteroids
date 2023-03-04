using System.Collections;
using UnityEngine;

public class BigSaucerPool : EnemyPool
{
    private RandomAppearanceEnemyConfig _enemyConfig;
    private IEnumerator _createEnemyCoroutine;
    private float _timeToAppear;

    public override void SetWaveConfig(EnemyWaveConfig waveConfig)
    {
        if (waveConfig.RandomAppearanceEnemies.Count < 1)
        {
            return;
        }

        _enemyConfig = waveConfig.FindRandomAppearanceEnemy(EnemyType);
    }
    public override void StartEnemy(Enemy enemy = null)
    {
        SetNewTimeToAppear();
        _createEnemyCoroutine = CreateEnemies();
        StartCoroutine(_createEnemyCoroutine);
    }

    private IEnumerator CreateEnemies()
    {
        var time = 0f;
        while (true)
        {
            time += Time.deltaTime;

            if (time > _timeToAppear)
            {
                Debug.Log("Trying to instantiate");
                var canAppear = RandomUtility.CanDo(_enemyConfig.AppearanceProbability);

                if (canAppear)
                {
                    Debug.Log("Instantiating");
                    InstantiateSaucer();
                }

                SetNewTimeToAppear();
                time = 0f;
            }
            yield return null;
        }
    }

    private void InstantiateSaucer()
    {
        var direction = (Random.Range(0, 100) < 50) ? Vector2.right : Vector2.left;
        var speed = Random.Range(SpeedRange.Min, SpeedRange.Max);

        var yPosition = Random.Range(MapBoundaries.Top, MapBoundaries.Bottom);
        var xPosition = direction == Vector2.right ? MapBoundaries.Left : MapBoundaries.Right;
        var position = new Vector2(xPosition, yPosition);

        var saucerConfig = (CustomConfigData as SaucerCustomConfigData).Config;
        var saucer = GetFromPool() as Saucer;
        IMovement movement = new SaucerMovement(saucer.Rigidbody, speed, position, saucerConfig);

        var enemyShotPool = Instantiate(saucerConfig.Pool, saucer.transform);
        enemyShotPool.SetData(MapBoundaries, saucerConfig.ShotLifeSpan);
        IShot shooter = new BigSaucerShot(saucer.transform, saucerConfig.ShotSpeed, saucerConfig.ShotCadence, enemyShotPool, Players);

        saucer.InitializeSaucer(Players, movement, shooter);

        saucer.gameObject.SetActive(true);
        movement.SetMovingState(MovingState.Thrusting);
        movement.Move(direction, ForceMode2D.Impulse);
    }

    private void SetNewTimeToAppear()
    {
        var timeRangeToAppear = _enemyConfig.TimeToAppear;
        _timeToAppear = Random.Range(timeRangeToAppear.Min, timeRangeToAppear.Max);
        Debug.Log($"Time to appear {_timeToAppear}");
    }

    public override void StopEnemy()
    {
        if (_createEnemyCoroutine != null)
        {
            StopCoroutine(_createEnemyCoroutine);
        }
    }

}
