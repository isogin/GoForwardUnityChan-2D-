using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
     }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる(左に移動させている)
        transform.Translate(this.speed * Time.deltaTime, 0, 0);


        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

    }





    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "BlockTag" || other.gameObject.tag == "GroundTag")
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        
    }
}
