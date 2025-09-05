using System.Threading;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    [SerializeField] private int Max = 10;
    private int count = 0;
    private float timer = 0f;


    void Update()
    {
        timer += Time.deltaTime;

        if(count < Max)
        {
            if (timer >= 1)
            {
                CreateCube();
                timer = 0f;
            }
        }
    }

    void CreateCube()
    {
        var randX = Random.Range(-10, 10);
        var randZ = Random.Range(-10, 10);
        Instantiate(Cube, new Vector3(randX, 0.5f, randZ), transform.rotation);
        count++;
    }
}
