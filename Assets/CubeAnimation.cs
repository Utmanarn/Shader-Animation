using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
    Transform cubeTransform;
    float counter, rotCounter;

    // Start is called before the first frame update
    void Start()
    {
        cubeTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 0.045f;
        rotCounter += 0.7f;
        cubeTransform.position += new Vector3(0 , Mathf.Sin(counter), 0) * 0.009f;

        cubeTransform.rotation = Quaternion.Euler(0, rotCounter, 0);
    }
}
