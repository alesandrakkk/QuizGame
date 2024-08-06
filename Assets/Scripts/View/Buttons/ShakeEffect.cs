using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace View
{
    [RequireComponent(typeof(Button))]
    public class ShakeEffect : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private Vector3 punch = new Vector3(15f, 0f, 0f);
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private int vibrato = 10;
        [SerializeField] private float elasticity = 1f;
        [SerializeField] private bool snapping = true;
        //[SerializeField] private Image imageColor;
      
        public void Notify(bool correct)
        {
            if(!snapping || correct)
            {
                //imageColor.DOColor(Color.green, duration).SetLoops(-1, LoopType.Yoyo);
     
                return;
            }

            transform.DOKill();
            transform.DOPunchPosition(punch, duration, vibrato, elasticity, false);

            //imageColor.DOColor(Color.red, duration).SetLoops(-1, LoopType.Yoyo);
                       
        }

       
    }
}
