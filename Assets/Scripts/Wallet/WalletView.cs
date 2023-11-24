using Scripts.Abstarct;
using TMPro;
using UnityEngine;

namespace Wallet
{
    public class WalletView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _balanceText;
        
        public void OnGoldChanged(int newValue)
        {
            _balanceText.text = newValue.ToString();
        }
    }
}