using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_anim : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _boxAK;
    [SerializeField] private GameObject _boxAKOnHand;
    [SerializeField] private GameObject _springAK;
    [SerializeField] private MeshRenderer _springAKMesh;
    private int _ak_anim;
    private Animator _animationAK;

    void Start()
    {
        _animationAK = _player.GetComponent<Animator>();
    }
    
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.T))
        {
            AK_anim_switch();
        }

    if (Input.GetMouseButton(0))
        {   
            Shot_ak_switch();
        }
    else
        {
            switch (_ak_anim)
            {
                case 0:
             _animationAK.SetBool("Shot_ak_bool", false);
                    break; 
                case 1:
             _animationAK.SetBool("Shot_ak_bool", false);
                    break;   
                case 2:
             _animationAK.SetBool("Shot_ak_pryshina_off", false);
                    break;
                case 3:
             _animationAK.SetBool("Shot_ak_bool", false);
                    break;   
                case 4:
             _animationAK.SetBool("Shot_ak_bool", false);
                _ak_anim = 0;
                    break;    

            }
        }
    }
    void Shot_ak_switch()
    {   
        switch (_ak_anim)
            {
                case 0:
             _animationAK.SetBool("Shot_ak_bool", true);
                    break; 
                case 1:
             _animationAK.SetBool("Shot_ak_bool", true);
                    break;   
                case 2:
             _animationAK.SetBool("Shot_ak_pryshina_off",true);
                StartCoroutine(Shot_ak_spring_off());
                    break;
                case 3:
             _animationAK.SetBool("Shot_ak_bool", true);
                    break;   
                case 4:
             _animationAK.SetBool("Shot_ak_bool", true);
                _ak_anim = 0;
                    break;    

            }
    }
    void AK_anim_switch()
    {
            _ak_anim ++;
            switch (_ak_anim)
            {
                case 1:
             _animationAK.SetBool("Korop_down_ak_bool", true);
                StartCoroutine(Box_bool_true());
                StartCoroutine(Box_off());
                    break;
                case 2:
             _animationAK.SetBool("Pryshina_down_ak_bool", true);
                StartCoroutine(Spring_off());
                    break;       
                case 3:
             _animationAK.SetBool("Pryshina_up_ak_bool", true);
                StartCoroutine(Spring_on());
                    break;           
                case 4:
             _animationAK.SetBool("Korop_up_akk_bool", true);
                StartCoroutine(Box_on());
                StartCoroutine(Box_bool_up_true());
                StartCoroutine(Box_bool_up_true_2());
                _ak_anim = 0;
                    break;   
            }
    }

    IEnumerator Box_bool_true()
    {
        yield return new WaitForSeconds(2.3f);
        _boxAKOnHand.SetActive(false);
        _animationAK.SetBool("Korop_down_ak_bool", false);
        _animationAK.SetBool("Korop_up_akk_bool", false);
    }
    IEnumerator Box_bool_up_true()
    {
        yield return new WaitForSeconds(2f);
        _boxAKOnHand.SetActive(false);
        _animationAK.SetBool("Korop_up_akk_bool", false);
    }
    IEnumerator Box_bool_up_true_2()
    {
        yield return new WaitForSeconds(0.5f);
        _boxAKOnHand.SetActive(true);
    }
    IEnumerator Box_off()
    {
        yield return new WaitForSeconds(1.11f);
        _boxAK.SetActive(false);
        _boxAKOnHand.SetActive(true);
    }
    IEnumerator Box_on()
    {
        yield return new WaitForSeconds(1.65f);
        _boxAK.SetActive(true);
        _boxAKOnHand.SetActive(false);
    }
    IEnumerator Spring_off()
    {
        yield return new WaitForSeconds(1.52f);
        _springAK.SetActive(false);
        _springAKMesh.enabled = false;
        _animationAK.SetBool("Pryshina_down_ak_bool", false);

    }
    IEnumerator Shot_ak_spring_off()
    {
        yield return new WaitForSeconds(0.59f);
        _animationAK.SetBool("Shot_ak_pryshina_off", false);
    }
    IEnumerator Spring_on()
    {
        yield return new WaitForSeconds(1.16f);
        _springAK.SetActive(true);
        _springAKMesh.enabled = true;
        _animationAK.SetBool("Pryshina_up_ak_bool", false);
    }
}
